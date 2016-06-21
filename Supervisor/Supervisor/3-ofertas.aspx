<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3-ofertas.aspx.cs" Inherits="Supervisor._3_ofertas" %>

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
            <asp:RadioButtonList CellSpacing="5" ID="RadioButtonList_Ofertas_Administrador" runat="server">
                                              
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Proxima Carga" Value="1" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento Carga" Value="2" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Regalo Carga" Value="3" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1" Value="4" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en igual producto" Value="5" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;gratis" Value="6" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento en el Segundo" Value="7" Enabled="false"></asp:ListItem>
                
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento dias de compra" Value="8" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;aumento todas compras" Value="9" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento Compra" Value="10" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Impresion Gratis" Value="11" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Video Gratis" Value="12" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Ejercicios Gratis" Value="13" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Explicaciones Gratis" Value="14" Enabled="false"></asp:ListItem>

                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Sin Ofertas" Value="50" Enabled="false"></asp:ListItem>
                
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:RadioButton ID="Bonificacion_Registro_Administrador" Enabled="false" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Registrarse" runat="server" />
        </div>
        <div>
            <asp:RadioButton ID="Bonificacion_Por_Cantidad_Administrador" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Ser Cliente Habitué" Enabled="false" runat="server" />
        </div>
        <div>    
            <asp:RadioButton ID="Bonificacion_Por_PrestamoSOS_Administrador" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Prestamo SOS" Enabled="false" runat="server"/>   
        </div>    
            


        <br />
        <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
            <div>
                <asp:RadioButtonList CellSpacing="5" ID="RadioButtonList_Ofertas_Supervisor" runat="server">
                                              
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Proxima Carga" Value="1" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento Carga" Value="2" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Regalo Carga" Value="3" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1" Value="4" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;2 x 1 en igual producto" Value="5" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;gratis" Value="6" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento en el Segundo" Value="7" ></asp:ListItem>
                
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Aumento dias de compra" Value="8" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;aumento todas compras" Value="9" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Descuento Compra" Value="10" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Impresion Gratis" Value="11" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Video Gratis" Value="12" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Ejercicios Gratis" Value="13" ></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Explicaciones Gratis" Value="14" ></asp:ListItem>

                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;Sin Ofertas" Value="50" ></asp:ListItem>
                
            </asp:RadioButtonList>
            </div>

            <div>
                <asp:RadioButton ID="Bonificacion_Registro_Supervisor" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Registrarse" runat="server" />
            </div>
            <div>
                <asp:RadioButton ID="Bonificacion_Por_Cantidad_Supervisor" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Ser Cliente Habitué" runat="server" />
            </div>
            <div>    
                <asp:RadioButton ID="Bonificacion_Por_PrestamoSOS_Supervisor" Text="&nbsp;&nbsp;&nbsp;&nbsp;Bonificación por Prestamo SOS" runat="server"/>   
            </div>
            <div>
                <asp:Button ID="BtnActualizar_Supervisor" runat="server" Text="Actualizar" OnClick="BtnActualizar_Supervisor_Click" />
            </div>

            <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
            <asp:GridView ID="GridView_Dios" runat="server" AutoGenerateColumns="false">
                
                <Columns>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Empresa" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_1PrestamoSOS" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_2Registro" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_3ProximaCarga" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_4AumentoCarga" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_5RegaloCarga" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_6DosXUno" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_7DosXUnoIgualProducto" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_8Gratis" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_9DescuentoSegundo" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_10BonificaciónHabitue" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_11AumentoDiasCompras" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_12AumentoDiasTodasCompras" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_13DescuentoCompra" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_14ImpresionGratis" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_15VideosGratis" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_16EjerciciosGratis" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_17ExplicacionesGratis" HeaderText="Empresa" />
                             
                </Columns>

            </asp:GridView>

            <div id="Centro_Dios" runat="server" visible="false">
                <asp:LinkButton ID="Anterior_Dios" runat="server" OnClick="Anterior_Dios_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Dios" runat="server" OnClick="Siguiente_Dios_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>

            <div id="Extremo_Dios" runat="server">
                <asp:LinkButton ID="Anterior_Dios_Ultimo" Visible="false" runat="server" OnClick="Anterior_Dios_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Dios_Primero" runat="server" OnClick="Siguiente_Dios_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>
            <br />

            <div>                             
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />                
            </div>
        
    </form>
</body>
</html>
