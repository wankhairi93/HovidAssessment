<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataRecord.aspx.cs" Inherits="WebApplication1.DataRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowDeleting="GridView1_RowDeleting"
                DataKeyNames="UserID">

                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                    <asp:BoundField DataField="UserNo" HeaderText="UserNo" />
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" />

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
