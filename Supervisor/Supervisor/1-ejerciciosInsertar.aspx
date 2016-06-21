<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-ejerciciosInsertar.aspx.cs" Inherits="Supervisor._1_ejerciciosInsertar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload_Ejercicio" runat="server" />
        <br />
        </br>
        <asp:Button ID="BtnSubirEjerciciio" runat="server" Text="Subir Ejercicio" OnClick="BtnSubirEjerciciio_Click" />
    </div>
    </form>
</body>
</html>
