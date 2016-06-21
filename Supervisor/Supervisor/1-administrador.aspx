<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-administrador.aspx.cs" Inherits="Supervisor._1_administrador" %>

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
            Administrador:
            <asp:Label ID="LblAdministrador" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Contraseña:
            <asp:TextBox ID="TxtContraseña" runat="server" Width="166px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnActualizarAdministrador" runat="server" Text="Actualizar" OnClick="BtnActualizarAdministrador_Click" />
            <br />
            <br />
            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_Administrador" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("administrador") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo" runat="server" Enabled="false" Checked='<%#Eval("bloqueo") %>' />

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
                    <label>Administrador:</label>
                    <asp:TextBox ID="Administrador_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Password:</label>
                    <asp:TextBox ID="Password_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Supervisor" runat="server" />
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
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Administrador" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnDios" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("administrador") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bloqueo">

                        <ItemTemplate>

                            <asp:CheckBox ID="CheckBoxBloqueo" runat="server" Enabled="false" Checked='<%#Eval("bloqueo") %>' />

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
                    <label>Administrador:</label>
                    <asp:TextBox ID="Administrador_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Password:</label>
                    <asp:TextBox ID="Password_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Bloqueado:</label>
                    <asp:CheckBox ID="CheckBox_Bloqueo_Dios" runat="server" />
                </div>
                <div>
                    <label>Empresa:</label>
                    <asp:TextBox ID="Empresa_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>

            <div>
                <asp:Button ID="Boton_Actualizar_Dios" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Dios_Click" />
                <asp:Button ID="Boton_Nuevo_Dios" Width="100%" runat="server" Text="Nuevo" OnClick="Boton_Nuevo_Dios_Click" />
                <asp:Button ID="Boton_Borrar_Dios" Width="100%" runat="server" Text="Borrar" OnClick="Boton_Borrar_Dios_Click" />
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Dios" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Dios_Click" />
            </div>

        </div>
    </form>
</body>
</html>
