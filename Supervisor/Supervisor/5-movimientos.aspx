<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5-movimientos.aspx.cs" Inherits="Supervisor._5_movimientos" %>

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
            no tiene permisos                       
            <br />
            ---------------------------------------------------------------------------------------------------------------<br />            
            Panel 2<br />
           <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Movimiento" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Movimiento") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaMovimiento" HeaderText="fecha" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="tipoMovimiento" HeaderText="Tipo Movimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="debe" HeaderText="Debe" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="haber" HeaderText="Haber" />
                                       
                </Columns>
                
            </asp:GridView>

            <div id="Centro_Supervisor" runat="server" visible="false">
                <asp:LinkButton ID="Anterior_Supervisor" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Supervisor" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>

            <div id="Extremo_Supervisor" runat="server">
                <asp:LinkButton ID="Anterior_Supervisor_Ultimo" Visible="false" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Supervisor_Primero" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>
            <br />

            <div id="Formulario_Supervisor" runat="server" visible="false">
                <div>
                    <h3 class="titulo_formulario">Formulario</h3>
                </div>
                <div>
                    <label>correo</label>
                    <asp:Label ID="Correo_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Telefono</label>
                    <asp:Label ID="Telefono_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Facebook</label>
                    <asp:Label ID="nameFacebook_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Movimiento:</label>
                    <asp:Label ID="tipoMovimiento_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>               
                 <div>
                    <label>Fecha</label>
                    <asp:Label ID="Fecha_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Debe</label>
                    <asp:Label ID="Debe_Supervisor" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Haber</label>
                    <asp:Label ID="Haber_Supervisor" runat="server"></asp:Label>
                </div>

            </div>

            <div>        
                <asp:Button ID="Boton_Borrar_Supervisor" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Supervisor_Click" />
                <asp:Button ID="Boton_Excel_Supervisor" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Supervisor_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Supervisor" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Supervisor_Click" />
            </div>

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
             
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Movimiento" AutoGenerateColumns="false">
                
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnDios" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Movimiento") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaMovimiento" HeaderText="fecha" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="tipoMovimiento" HeaderText="Tipo Movimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="debe" HeaderText="Debe" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="haber" HeaderText="Haber" />
                                       
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

            <div id="Formulario_Dios" runat="server" visible="false">
                <div>
                    <h3 class="titulo_formulario">Formulario</h3>
                </div>
                <div>
                    <label>correo</label>
                    <asp:Label ID="Correo_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Telefono</label>
                    <asp:Label ID="Telefono_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Facebook</label>
                    <asp:Label ID="nameFacebook_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Movimiento:</label>
                    <asp:Label ID="tipoMovimiento_Dios" Width="100%" runat="server"></asp:Label>
                </div>               
                 <div>
                    <label>Fecha</label>
                    <asp:Label ID="Fecha_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Debe</label>
                    <asp:Label ID="Debe_Dios" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Haber</label>
                    <asp:Label ID="Haber_Dios" runat="server"></asp:Label>
                </div>

            </div>


            <div>                              
                <asp:Button ID="Boton_Borrar_Dios" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Dios_Click" />
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Dios" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Dios_Click" />
            </div>

        </div>
    </form>
</body>
</html>
