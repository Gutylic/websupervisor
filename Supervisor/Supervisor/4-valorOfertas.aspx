<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4-valorOfertas.aspx.cs" Inherits="Supervisor._4_valorOfertas" %>

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
            <div>
                <label>prestamo SOS en $</label>
                <asp:Label ID="LblPrestamoSOS_Administrador" runat="server" ></asp:Label>
            </div>
            <div>
                <label>Registro en $</label>
                <asp:Label ID="LblRegistro_Administrador" runat="server" ></asp:Label>
            </div>
            <div>
                <label>proxima carga en enteros (duplicar...)</label>
                <asp:Label ID="LblProximaCarga_Administrador" runat="server" ></asp:Label>
            </div>
            <div>
                <label>Aumento carga en enteros (duplicar...)</label>                
                <asp:Label ID="LblAumentoCarga_Administrador" runat="server" ></asp:Label>
            </div>
            <div>
                <label>Regalo recarga en $</label> 
                <asp:Label ID="LblRegaloCarga_Administrador" runat="server" ></asp:Label>
            </div>             
            <div>
                <label>Descuento 2do %</label>
                <asp:Label ID="LblDescuentoSegundo_Administrador" runat="server" ></asp:Label>
            </div>   
            <div>
                <label>Descuento compra %</label>
                <asp:Label ID="LblDescuentoCompra_Administrador" runat="server" ></asp:Label>
            </div>         
            <div>
                <label>Aumento dias (dias)</label>
                <asp:Label ID="LblAumentoCompraDias_Administrador" runat="server" ></asp:Label>
            </div>      
            <div>
                <label>Aumento dias todo (dias)</label> 
                <asp:Label ID="LblAumentoTodoComprasDias_Administrador" runat="server" ></asp:Label>
            </div>
                
        </div>

        <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
        <div>

            <div>
                <label>prestamo SOS en $</label>
                <asp:TextBox ID="TxtPrestamoSOS_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Registro en $</label>
                <asp:TextBox ID="TxtRegistro_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>proxima carga en enteros (duplicar...)</label>
                <asp:TextBox ID="TxtProximaCarga_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Aumento carga en enteros (duplicar...)</label>
                <asp:TextBox ID="TxtAumentoCarga_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Regalo recarga en $</label>
                <asp:TextBox ID="TxtRegaloCarga_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Descuento 2do %</label>
                <asp:TextBox ID="TxtDescuentoSegundo_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Aumento dias (dias)</label>
                <asp:TextBox ID="TxtAumentoCompraDias_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Aumento dias todo (dias)</label>
                <asp:TextBox ID="TxtAumentoTodoComprasDias_Supervisor" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Descuento compra %</label>
                <asp:TextBox ID="TxtDescuentoCompra_Supervisor" runat="server"></asp:TextBox>
            </div>

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
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_1ValorPrestamoSOS" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_2ValorRegistro" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_3ValorProximaCarga" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_4ValorAumentoCarga" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_5ValorRegaloCarga" HeaderText="Empresa" />                   
                   
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_9ValorDescuentoSegundo" HeaderText="Empresa" />
                   
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_11ValorAumentoDiasCompras" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_12ValorAumentoDiasTodasCompras" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="oferta_13ValorDescuentoCompra" HeaderText="Empresa" />

                             
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
