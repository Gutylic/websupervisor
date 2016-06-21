<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-empresas.aspx.cs" Inherits="Supervisor._1_empresas" %>

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
            <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
            <br />
            No tiene permisos
            <br />
            <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" DataKeyNames="ID_Empresa" AutoGenerateColumns="false">
                
                <Columns>

                    <asp:TemplateField HeaderText="identificador Empresa">

                        <ItemTemplate>

                            <asp:LinkButton ID="LinkBtnDios" runat="server" CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"><%#Eval("id_Empresa") %></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>

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
                    <label>Empresa</label>
                    <asp:TextBox ID="TxtEmpresa_Dios" runat="server"></asp:TextBox>
                    
                </div>               
            </div>

            <div>
                <asp:Button ID="Boton_Actualizar_Dios" Width="100%" runat="server" Text="Actualizar" OnClick="Boton_Actualizar_Dios_Click" />
                <asp:Button ID="Boton_Nuevo_Dios" Width="100%" runat="server" Text="Nuevo" OnClick="Boton_Nuevo_Dios_Click" />                
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
                <asp:Button ID="Boton_Cerrar_Formulario_Dios" runat="server" Text="X" OnClick="Boton_Cerrar_Formulario_Dios_Click" />

            </div>
        </div>
    </form>
</body>
</html>
