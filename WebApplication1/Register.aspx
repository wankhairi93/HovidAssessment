<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td colspan="6" style="text-align: center;"><strong>Register</strong></td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 25%;">&nbsp;</td>
                    <td style="text-align: right; width: 25%;">User Name :</td>
                    <td style="text-align: left; width: 25%;">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" style="width: 25%">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 25%;">&nbsp;</td>
                    <td style="text-align: right;">User No :</td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtUserNo" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2" style="width: 25%">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 25%;">&nbsp;</td>
                    <td style="text-align: right;"></td>
                    <td style="text-align: left;">
                        <asp:Button runat="server" ID="btnSubmit" Text="Create" OnClick="btnSubmit_Click"/>
                    </td>
                    <td colspan="2" style="width: 25%">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
