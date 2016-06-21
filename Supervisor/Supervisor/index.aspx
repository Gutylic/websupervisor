<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Supervisor.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Usuario:
        <asp:TextBox ID="TxtAdministrador" runat="server" Width="287px"></asp:TextBox>
        <br />
        Password:
        <asp:TextBox ID="TxtContrasena" runat="server" Width="277px"></asp:TextBox>
        <br />
        <asp:Button ID="BtnIngreso" runat="server" Text="Ingresar" OnClick="BtnIngreso_Click" Width="348px" />
    
    </div>
    </form>
</body>
</html>
