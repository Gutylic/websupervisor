<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-tarjetaPrepaga.aspx.cs" Inherits="Supervisor._1_tarjetaPrepaga" %>

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
                    <label>Tarjeta:</label>
                    <asp:TextBox ID="TxtTarjetaPrepaga_Administrador" runat="server"></asp:TextBox>
                    <br />
                    <br />
                <div>                                    
                    <asp:Button ID="BtnBuscarTarjeta_Administrador" runat="server" Text="Buscar Tarjeta" OnClick="BtnBuscarTarjeta_Administrador_Click" />
                </div>    
                <div id="Formulario_Administrador" runat="server" visible="false">
                <div>
                    <h3 class="titulo_formulario">Formulario</h3>
                </div>
                <div>
                    <label>Codigo Tarjeta:</label>
                    <asp:TextBox ID="codigoTarjeta_Administrador" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Valor Tarjeta $:</label>
                    <asp:TextBox ID="valorTarjeta_Administrador" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Vencimiento:</label>
                    <asp:TextBox ID="vencimientoTarjeta_Administrador" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Administrador" Enabled="false" runat="server" />
                </div>
            </div>
                                              
                    <br />
                    <asp:Button ID="BtnCerrarFormulario" runat="server" Text="X" OnClick="BtnCerrarFormulario_Click" />
                                              
            <br />
            <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Tarjeta" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("codigoTarjeta") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo" runat="server" Enabled="false" Checked='<%#Eval("bloqueoTarjeta") %>' />

                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="valorTarjeta" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="vencimientoTarjeta" HeaderText="Empresa" />                    

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
                    <label>Codigo Tarjeta:</label>
                    <asp:Label ID="codigoTarjeta_Supervisor" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Valor Tarjeta $:</label>
                    <asp:TextBox ID="valorTarjeta_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Vencimiento:</label>
                    <asp:TextBox ID="vencimientoTarjeta_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Supervisor" Enabled="false" runat="server" />
                </div>
            </div>
            

             <div id="Formulario_Tarjeta" runat="server" visible="false">
                <div>
                    <h3 class="titulo_formulario">Formulario Tarjeta</h3>
                </div>
                <div>
                    <label>Cantidad de Tarjetas:</label>
                    <asp:TextBox ID="Cantidad_Tarjetas" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Valor Tarjeta $:</label>
                    <asp:TextBox ID="Valor_Tarjetas" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Vencimiento:</label>
                    <asp:TextBox ID="Vencimiento_Tarjetas" Width="100%" runat="server"></asp:TextBox>
                </div>               
            </div>

            <div>
                <asp:Button ID="Boton_Actualizar_Supervisor" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Supervisor_Click" />
                <asp:Button ID="Boton_Nuevo_Supervisor" Width="100%" runat="server" Text="Nuevo" OnClick="Boton_Nuevo_Supervisor_Click" />
                <asp:Button ID="Boton_Borrar_Supervisor" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Supervisor_Click" />
                <asp:Button ID="Boton_Excel_Supervisor" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Supervisor_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Supervisor" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Supervisor_Click" />
            </div>

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
            <asp:GridView ID="GridView_Dios" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Tarjeta">
                
                <Columns>

                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnDios" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("codigoTarjeta") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo" runat="server" Enabled="false" Checked='<%#Eval("bloqueoTarjeta") %>' />

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="valorTarjeta" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="vencimientoTarjeta" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="empresa" HeaderText="Empresa" />
                  
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
                    <label>Codigo Tarjeta:</label>
                    <asp:Label ID="codigoTarjeta_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Valor Tarjeta $:</label>
                    <asp:Label ID="valorTarjeta_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Vencimiento:</label>
                    <asp:Label ID="vencimientoTarjeta_Dios" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Dios" Enabled="false" runat="server" />
                </div>
            </div>
            <div>    
                <asp:Button ID="Boton_Borrar_Dios" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Dios_Click" /> 
                <asp:Button ID="Boton_Cerrar_Formulario_Dios" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Dios_Click" />    
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />                
            </div>
        </div>
    </form>
</body>
</html>
