<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-comprasVideos.aspx.cs" Inherits="Supervisor._2_comprasVideos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Panel 1<br />
            <asp:GridView ID="GridView_Administrador" runat="server" AutoGenerateColumns="false">

                <Columns>

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Ejercicio" HeaderText="Ejercicio" />                   
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="vencimiento" HeaderText="Vencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaVencimiento" HeaderText="fechaVencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" />                    

                </Columns>

            </asp:GridView>

            <div id="Centro_Administrador" runat="server" visible="false">
                <asp:LinkButton ID="Anterior_Administrador" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Administrador" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>

            <div id="Extremo_Administrador" runat="server">
                <asp:LinkButton ID="Anterior_Administrador_Ultimo" Visible="false" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior &nbsp</asp:LinkButton>
                <asp:LinkButton ID="Siguiente_Administrador_Primero" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp Siguiente >></asp:LinkButton>
            </div>
                       
            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" DataKeyNames="ID_CompraVideos" AutoGenerateColumns="false">

                <Columns>

                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_CompraVideos") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>                 

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="vencimiento" HeaderText="Vencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaVencimiento" HeaderText="fechaVencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" /> 
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Ejercicio" HeaderText="Ejercicio" />  

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
                    <label>Ejercicio numero:</label>
                    <asp:TextBox ID="numeroEjercicio_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>                
                <div>
                    <label>vencimiento:</label>
                    <asp:TextBox ID="vencimiento_Supervisor" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>Usuario:</label>
                    <asp:TextBox ID="usuario_Supervisor" Width="100%" runat="server"></asp:TextBox>
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
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_CompraVideos" AutoGenerateColumns="false">
                
                <Columns>

                    <asp:TemplateField HeaderText="Administrador">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnSupervisor" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_CompraVideos") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>                   

                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="vencimiento" HeaderText="Vencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaVencimiento" HeaderText="fechaVencimiento" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" /> 
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Ejercicio" HeaderText="Ejercicio" />  

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
                    <label>Ejercicio numero:</label>
                    <asp:TextBox ID="numeroEjercicio_Dios" Width="100%" runat="server"></asp:TextBox>
                </div>                   
                <div>
                    <label>Usuario:</label>
                    <asp:TextBox ID="usuario_Dios" Width="100%" runat="server"></asp:TextBox>
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
