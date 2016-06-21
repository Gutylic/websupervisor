<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paginaMaestra.aspx.cs" Inherits="Supervisor.paginaMaestra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 232px;
        }
        .auto-style2 {
            width: 181px;
        }
        .auto-style3 {
            width: 232px;
            height: 30px;
        }
        .auto-style4 {
            width: 181px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
    
        <asp:Button ID="BtnPanel_1Administrador" runat="server" Text="Administrador" OnClick="BtnPanel_1Administrador_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnPanel_1Usuario" runat="server" Text="Usuarios" OnClick="BtnPanel_1Usuario_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnPanel_1Empresa" runat="server" Text="Empresa" OnClick="BtnPanel_1Empresa_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Button ID="BtnPanel_2Comentario" runat="server" Text="Comentario Administrador" OnClick="BtnPanel_2Comentario_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnPanel_2ComentarioUsuario" runat="server" Text="Comentario Usuario" OnClick="BtnPanel_2ComentarioUsuario_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnPanel_2Precios" runat="server" Text="Precios" OnClick="BtnPanel_2Precios_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Button ID="BtnPanel_3Control" runat="server" Text="Control Administradores" OnClick="BtnPanel_3Control_Click" />
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnPanel_3Oferta" runat="server" Text="Oferta" OnClick="BtnPanel_3Oferta_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnPanel_4ValorOferta" runat="server" Text="Valor Oferta" OnClick="BtnPanel_4ValorOferta_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnCompraVideos" runat="server" Text="compra ejercicios" OnClick="BtnCompraVideos_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnInsertarEjercicio" runat="server" Text="Insertar Ejercicio" OnClick="BtnInsertarEjercicio_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnTarjetaPrepaga" runat="server" Text="Tarjeta Prepaga" OnClick="BtnTarjetaPrepaga_Click"  />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnCompraEjercicios" runat="server" Text="compra videos" OnClick="BtnCompraEjercicios_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnActualizarEjercicio" runat="server" Text="Actualizar Ejercicio" OnClick="BtnActualizarEjercicio_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnCargaAutomatica" runat="server" Text="Carga Automatica" OnClick="BtnCargaAutomatica_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnCargaManual" runat="server" Text="Carga Manual" OnClick="BtnCargaManual_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnFacturacion" runat="server" Text="Facturacion" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnMovimiento" runat="server"  Text="Movimientos" OnClick="BtnMovimiento_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnExplicacionesPedidas" runat="server" Text="Explicaciones" OnClick="BtnExplicacionesPedidas_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="BtnCategoria" runat="server" Text="Categoria" OnClick="BtnCategoria_Click" />
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="BtnEjerciciosPedidos" runat="server" Text="Ejercicios" OnClick="BtnEjerciciosPedidos_Click" />
                </td>
                <td class="auto-style4">
                </td>
                <td class="auto-style5">
                    </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
