<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-precios.aspx.cs" Inherits="Supervisor._2_precios" %>

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
                    <label>Compra de Ejercicio en $:</label>
                    <asp:Label ID="Valor_Ejercicio_Administrador" CssClass="valor" Width="100%" Height="36px"  runat="server"></asp:Label>                                                         
                </div>
                <div>                                    
                    <label>Compra de Explicación en $:</label>
                    <asp:Label ID="Valor_Explicacion_Administrador" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:Label>                                                        
                </div>
                <div>
                    <label>Compra de Vídeo en $:</label>
                    <asp:Label ID="Valor_Video_Administrador" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:Label>                                                       
                </div>
                <div>
                    <label>Compra de las Impresiones en $:</label>
                    <asp:Label ID="Valor_Impresion_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:Label>                                            
                </div>
                <div>
                    <label>Duración Videos:</label>
                    <asp:Label ID="Duracion_Videos_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px" ></asp:Label>
                </div>
                <div>
                    <label>Duración de Ejercicios:</label>
                    <asp:Label ID="Duracion_Ejercicios_Administrador" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:Label>
                </div>
                <div>
                    <label>EJercicios para ser Habitue:</label>
                    <asp:Label ID="EjerciciosHabitue_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:Label>                                            
                </div>
                <div>
                    <label>Recarga Habitue (en pesos):</label>
                    <asp:Label ID="RecargaHabitue_Administrador" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:Label>                                            
                </div>
                                           
            <br />
            <br />

            ---------------------------------------------------------------------------------------------------------------<br />
            <br />
            Panel 2<br />
                <div>                                            
                    <label>Compra de Ejercicio en $:</label>
                    <asp:TextBox ID="Valor_Ejercicio_Supervisor" CssClass="valor" Width="100%" Height="36px"  runat="server"></asp:TextBox>                                                         
                </div>
                <div>                                    
                    <label>Compra de Explicación en $:</label>
                    <asp:TextBox ID="Valor_Explicacion_Supervisor" CssClass="valor" runat="server" Width="100%" Height="36px"></asp:TextBox>                                                        
                </div>
                <div>
                    <label>Compra de Vídeo en $:</label>
                    <asp:TextBox ID="Valor_Video_Supervisor" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:TextBox>                                                       
                </div>
                <div>
                    <label>Compra de las Impresiones en $:</label>
                    <asp:TextBox ID="Valor_Impresion_Supervisor" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:TextBox>                                            
                </div>
                <div>
                    <label>Duración Videos:</label>
                    <asp:TextBox ID="Duracion_Videos_Supervisor" runat="server" CssClass="valor" Width="100%" Height="36px" ></asp:TextBox>
                </div>
                <div>
                    <label>Duración de Ejercicios:</label>
                    <asp:TextBox ID="Duracion_Ejercicios_Supervisor" CssClass="valor" Width="100%" Height="36px" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label>EJercicios para ser Habitue:</label>
                    <asp:TextBox ID="EjerciciosHabitue_Supervisor" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:TextBox>                                            
                </div>
                <div>
                    <label>Recarga Habitue (en pesos):</label>
                    <asp:TextBox ID="RecargaHabitue_Supervisor" runat="server" CssClass="valor" Width="100%" Height="36px"></asp:TextBox>                                            
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
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="duracionVideos" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="duracionEjercicios" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="precioVideo" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="precioEjercicio" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="precioExplicacion" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="precioImpresion" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="ejerciciosCompradosHabitue" HeaderText="Empresa" />
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="recargaHabitue" HeaderText="Empresa" />
                                      
                       
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
