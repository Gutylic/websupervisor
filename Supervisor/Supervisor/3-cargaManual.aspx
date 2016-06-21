<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3-cargaManual.aspx.cs" Inherits="Supervisor._3_cargaManual" %>

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
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Usuario" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Usuario">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Usuario") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="creditoUsuario" HeaderText="Credito" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoSOS" HeaderText="SOS" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoReal" HeaderText="Prestamo" />

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
                    <label>Carga</label>
                    <asp:TextBox ID="Carga_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>   
                <div>
                    <label>Tipo de Movimiento</label>
                    <asp:DropDownList ID="DropDownListMovimiento_Supervisor" runat="server">
                        <asp:ListItem Value="0" Text="Cargar plata"></asp:ListItem>
                        <asp:ListItem Value="24" Text="Devolver plata"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                 
            </div>

            <div>
                <asp:Button ID="Boton_Actualizar_Supervisor" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Supervisor_Click" />                
                <asp:Button ID="Boton_Excel_Supervisor" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Supervisor_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Supervisor" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Supervisor_Click" />
            </div>

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
            
            <asp:GridView ID="GridView_Dios" runat="server" AutoGenerateColumns="false">
                
                <Columns>
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="creditoUsuario" HeaderText="Credito" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoSOS" HeaderText="SOS" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoReal" HeaderText="Prestamo" />

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

        </div> 

    </form>
</body>
</html>
