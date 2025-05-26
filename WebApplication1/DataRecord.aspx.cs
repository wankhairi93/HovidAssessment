using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DataRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            GridView1.DataSource = GetLoadData();
            GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            GridViewRow row = GridView1.Rows[e.RowIndex];
            string userName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string userNo = ((TextBox)row.Cells[2].Controls[0]).Text;
            string createDate = ((TextBox)row.Cells[3].Controls[0]).Text;

            try
            {
                UpdateUser(userId, userName, userNo, Convert.ToDateTime(createDate).ToString("yyyy-MM-dd HH:mm:ss"));
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully updated!');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "!');", true);
            }

            GridView1.EditIndex = -1;
            LoadData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            try
            {
                DeleteUser(userId);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully delete!');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "!');", true);
            }
            LoadData();        
        }
        #region Database
        private DataSet GetLoadData()
        {
            DataSet ds = new DataSet();
            Database db = new Database();
            try
            {
                ds = db.LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
            return ds;
        }
        private void DeleteUser(int userid)
        {
            Database db = new Database();
            try
            {
                db.DeleteData(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
        }
        private void UpdateUser(int userid, string username, string userno, string createdate)
        {
            Database db = new Database();
            try
            {
                db.UpdateData(userid,username,userno,createdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Disconnect();
            }
        }
        #endregion
    }
}