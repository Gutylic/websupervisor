<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-cargaAutomatica.aspx.cs" Inherits="Supervisor._2_cargaAutomatica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Panel 1<br />
            <br />
                No tiene permisos
            <br />
            ---------------------------------------------------------------------------------------------------------------<br />            
            Panel 2<br />
            
            <div id="Formulario_Supervisor" runat="server">
                <div>
                    <h3 class="titulo_formulario">Formulario</h3>
                    <p class="titulo_formulario">
                        <table style="width:100%;">
                            <tr>
                                <td>mercado pago</td>
                                <td>paypal</td>
                            </tr>
                            <tr>
                                <td>archivo:
                                    <asp:TextBox ID="TextBox_Archivo_MercadoPago" runat="server" Height="16px" Width="249px"></asp:TextBox>
                                </td>
                                <td>archivo:
                                    <asp:TextBox ID="TextBox_Archivo_Paypal" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="BtnMercadoPago" runat="server" Text="Mercado Pago" OnClick="BtnMercadoPago_Click" />
                                </td>
                                <td>pasar de U$D a $:
                                    <asp:TextBox ID="TextBox_DolarPeso" runat="server" Width="158px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="BtnPaypal" runat="server" Text="PayPal" OnClick="BtnPaypal_Click" />
                                </td>
                            </tr>
                        </table>
                    </p>
                </div>
            </div>

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
             No tiene permisos

        </div>
    </form>
</body>
</html>
