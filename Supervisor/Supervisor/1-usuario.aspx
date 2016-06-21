<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-usuario.aspx.cs" Inherits="Supervisor._1_usuario" %>

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
            Usuario
            <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            <br />
            <asp:DropDownList ID="DropDownList_TipoUsuario" runat="server">
                <asp:ListItem Value="1" Text="Correo"></asp:ListItem>
                <asp:ListItem Value="2" Text="Celular"></asp:ListItem>
                <asp:ListItem Value="3" Text="Facebook"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="BtnUsuario" runat="server" Text="Buscar Usuario" OnClick="BtnUsuario_Click" />
            <br />
            <div id="Formulario_Administrador" runat="server" visible="false">
                <div>
                    <h3 class="titulo_formulario">Formulario</h3>
                </div>
                <div>
                    <label>Correo:</label>
                    <asp:Label ID="LblCorreo" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>telefono:</label>
                    <asp:Label ID="LblTelefono" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Credito: $</label>
                    <asp:Label ID="LblCredito" Width="100%" runat="server"></asp:Label>
                </div>
                 <div>
                    <label>Facebook:</label>
                    <asp:Label ID="LblFacebook" Width="100%" runat="server"></asp:Label>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBoxBloqueo" runat="server" Enabled="false" />
                </div>
            </div>
            <br />
            <asp:Button ID="BtnCerrar" runat="server" Text="X" OnClick="BtnCerrar_Click" />
            <br />
            ---------------------------------------------------------------------------------------------------------------<br />            
            Panel 2<br />
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Usuario" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Usuario") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="creditoUsuario" HeaderText="Credito" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoSOS" HeaderText="SOS" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="ofertaProximaCarga" HeaderText="Proxima Carga" />

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo_Supervisor" runat="server" Enabled="false" Checked='<%#Eval("bloqueoUsuario") %>' />

                        </ItemTemplate>

                    </asp:TemplateField>
                                
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
                    <asp:TextBox ID="Correo_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Telefono</label>
                    <asp:TextBox ID="Telefono_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Supervisor" runat="server" />
                </div>
                <div>
                    <label>Pais</label>
                    <asp:DropDownList ID="DropDownListPais_Supervisor" runat="server">
                        <asp:ListItem Value="0" Text="Argenitna"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Bolivia"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                 
                <div>
                    <label>SOS</label>
                    <asp:CheckBox ID="CheckBox_SOS_Supervisor" runat="server" />
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
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Usuario" AutoGenerateColumns="false">
                
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnDios" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Usuario") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="correo" HeaderText="correo" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="nameFacebook" HeaderText="Facebook" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="password" HeaderText="Password" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="empresa" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="creditoUsuario" HeaderText="Credito" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="prestamoSOS" HeaderText="SOS" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="ofertaProximaCarga" HeaderText="Proxima Carga" />

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="skype" HeaderText="Skype" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="modeloTelefono" HeaderText="modeloTelefono" />                                       

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo_Dios" runat="server" Enabled="false" Checked='<%#Eval("bloqueoUsuario") %>' />

                        </ItemTemplate>

                    </asp:TemplateField>
                                
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
                    <asp:TextBox ID="Correo_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Telefono</label>
                    <asp:TextBox ID="Telefono_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Dios" runat="server" />
                </div>
                <div>
                    <label>Pais</label>
                    <asp:DropDownList ID="DropDownListPais_Dios" runat="server">
                        <asp:ListItem Value="0" Text="Argenitna"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Bolivia"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div>
                    <label>Password</label>
                    <asp:TextBox ID="Password_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>SOS</label>
                    <asp:CheckBox ID="CheckBox_SOS_Dios" runat="server" />
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
