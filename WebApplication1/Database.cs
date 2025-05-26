using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Database
    {
        #region Variable
        string ConnDB = ConfigurationManager.AppSettings["ConnString"].ToString();
        SqlConnection conn = default(SqlConnection);
        SqlCommand cmd = default(SqlCommand);
        SqlDataAdapter da = default(SqlDataAdapter);
        SqlTransaction trans = default(SqlTransaction);
        public Database()
        {
            conn = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            conn = new SqlConnection(ConnDB);
            if (conn.State == ConnectionState.Closed) conn.Open();
            cmd.Connection = conn;
        }
        public void Disconnect()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Dispose();
        }
        #endregion
        #region Transaction SQL
        public void SetTransaction()
        {
            trans = conn.BeginTransaction();
            cmd.Transaction = trans;
        }
        public string SetCommit()
        {
            string result = string.Empty;
            try
            {
                trans.Commit();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public void RollBack()
        {
            trans.Rollback();
        }
        #endregion
        #region Execute Data
        public DataSet ExecuteFillDS(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.CommandText = query;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (ds == null) ds = new DataSet();
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return ds;
        }
        public DataSet ExecuteFillDS(string query, string table)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.CommandText = query;
                da.SelectCommand = cmd;
                da.Fill(ds, table);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (ds == null) ds = new DataSet();
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return ds;
        }
        public DataTable ExecuteFillDT(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = ExecuteFillDS(query);
                if (ds != null)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (dt == null) dt = new DataTable();
            }
            return dt;
        }
        public DataTable ExecuteFillDT(string query, string table)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = ExecuteFillDS(query, table);
                if (ds != null)
                    dt = ds.Tables[table];
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                if (dt == null) dt = new DataTable();
            }
            return dt;
        }
        public string ExecuteNonQuery(string query, bool returnInt = false)
        {
            string result = string.Empty;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.CommandText = query;
                if (returnInt)
                    result = Convert.ToString(cmd.ExecuteNonQuery());
                else
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return result;
        }
        public string ExecuteScalar(string query)
        {
            string result = string.Empty;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.CommandText = query;
                object resp = cmd.ExecuteScalar();
                if (resp != null)
                    result = Convert.ToString(resp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return result;
        }
        #endregion
        #region Parameter
        public string SQLV(string data, bool sqlLike = false)
        {
            return (sqlLike ? "'%" + data.Replace("'", "''") + "%'" : "'" + data.Replace("'", "''") + "'");
        }
        public string SQLN(string data, bool sqlLike = false)
        {
            return (sqlLike ? "N'%" + data.Replace("'", "''") + "%'" : "N'" + data.Replace("'", "''") + "'");
        }
        #endregion
        #region Register
        public void CreateRegister(string username, string userno)
        {
            try
            {
                string query = "EXEC [dbo].[sp_UserInformation_Insert] @UserName = N'" + username + "', @UserNo = '" + userno + "'";
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet LoadData()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "EXEC [dbo].[sp_UserInformation_Select]";
                ds = ExecuteFillDS(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public void DeleteData(int userid)
        {
            try
            {
                string query = "EXEC [dbo].[sp_UserInformation_Delete] @UserID = '" + userid + "'";
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateData(int userid, string username, string userno, string createdate)
        {
            try
            {
                string query = "EXEC [dbo].[sp_UserInformation_Update] @UserID = '" + userid + "', @UserName = N'" + username + "', @UserNo = '" + userno + "', @CreateDate = '" + createdate + "'";
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}