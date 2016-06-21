<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-ejerciciosActualizar.aspx.cs" Inherits="Supervisor._2_ejerciciosActualizar" %>

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
            <br />
            <asp:Button ID="BtnActualizarEjercicio" runat="server" Text="Actualizar Ejercicio" OnClick="BtnActualizarEjercicio_Click" />
            <br />
            <br />
            <asp:Button ID="BtnRecargarTablaAno" runat="server" Text="Recargar Tabla Ano" OnClick="BtnRecargarTablaAno_Click" />
            <br />
            <br />
            <asp:Button ID="BtnRecargarTablaMateria" runat="server" Text="Recargar Tabla Materia" OnClick="BtnRecargarTablaMateria_Click"  />
            <br />
            <br />
            <asp:Button ID="BtnRecargarTablaColegio" runat="server" Text="Recargar Tabla Colegio" OnClick="BtnRecargarTablaColegio_Click" />
            <br />
            <br />
            <asp:Button ID="BtnRecargarTablaTema" runat="server" Text="Recargar Tabla Tema" OnClick="BtnRecargarTablaTema_Click" />
            <br />
            <br />
            <asp:Button ID="BtnRecargarTablaProfesor" runat="server" Text="Recargar Tabla Profesor" OnClick="BtnRecargarTablaProfesor_Click" />
        </div>
    </form>
</body>
</html>
