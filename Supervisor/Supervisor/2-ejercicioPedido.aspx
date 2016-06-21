<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2-ejercicioPedido.aspx.cs" Inherits="Supervisor._2_ejercicioPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

         <div>            
            <asp:GridView ID="GridView_Administrador" runat="server" OnSelectedIndexChanged="Identificador_Administrador" AutoGenerateColumns="false" DataKeyNames="ID_PedidoEjercicioVideo">
                
                <Columns>
                
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Número de Ejercicio">
                                                    
                        <ItemTemplate>
                            <asp:LinkButton ID="Seleccionar_Administrador" CommandName="select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("id_PedidoEjercicioVideo") %></asp:LinkButton>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" />      
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaPedidoEjercicioVideo" HeaderText="Pedido" />  
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Administrador" HeaderText="Administrador" />         
                    
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="OK Realizado">
                    
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_Administrador" runat="server" Enabled="false" Checked='<%# Eval ("realizadoOKPedidoEjercicioVideo") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>                                           
                                            
                </Columns>
                                        
            </asp:GridView>
        
        </div>                                        
                            
        <div id="Centro_Administrador" runat="server" visible="false">
           <asp:LinkButton ID="Anterior_Administrador" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Administrador" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>

        <div id="Extremo_Administrador" runat="server">
           <asp:LinkButton ID="Anterior_Administrador_Ultimo" Visible="false" runat="server" OnClick="Anterior_Administrador_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Administrador_Primero" runat="server" OnClick="Siguiente_Administrador_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>
                
        
        
        
             
            <div id="Formulario_Administrador" runat="server" visible="false" >
            <div>
                <h3 class="titulo_formulario">Formulario</h3>
            </div>
            <div>
                <label>Adjunto</label>
                <asp:Button ID="BtnAdjunto_Administrador" runat="server" Text="Adjunto" OnClick="BtnAdjunto_Administrador_Click" />
            </div>
            <div>
                <label>Ficha</label>
                <asp:Button ID="BtnFicha_Administrador" runat="server" Text="Ficha" OnClick="BtnFicha_Administrador_Click" />
            </div>
            <div>
                <label>MATH</label>
                <asp:Button ID="BtnMath_Administrador" runat="server" Text="Math" OnClick="BtnMath_Administrador_Click" />
            </div>
            <div>
                <label>Limpio</label>
                <asp:Button ID="BtnLimpio_Administrador" runat="server" Text="Limpio" OnClick="BtnLimpio_Administrador_Click" />
            </div>
            <div>
                <label>Usuario</label>
                <asp:Label ID="Usuario_Administrador" Width="100%" runat="server"></asp:Label>
            </div>
            <div>
                 <label>Pedido</label>
                 <asp:Label ID="FechaPedido_Administrador" Width="100%" runat="server"></asp:Label>
            </div>           
            <div>
                 <label>Profesor</label>
                 <asp:Label ID="Profesor_Administrador" Width="100%" runat="server"></asp:Label>
             </div>
             <div>
                 <label>Ejercicio</label>
                 <asp:CheckBox ID="CheckBoxEjercicio_Administrador" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>Explicacion</label>
                 <asp:CheckBox ID="CheckBoxExplicacion_Administrador" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>RealizadoOK</label>
                 <asp:CheckBox ID="CheckBoxRealizadoOK_Administrador" runat="server" />
             </div>
             

        </div>

            <div>
                <asp:Button ID="Boton_No_Resolver_Administrador" Width="100%" runat="server" Text="No resolver" OnClick="Boton_No_Resolver_Administrador_Click"  />
                <asp:Button ID="Boton_Resolver_Administrador" Width="100%" runat="server" Text="Resolver" OnClick="Boton_Resolver_Administrador_Click"  />
                <asp:Button ID="Boton_Resuelto_Administrador" Width="100%" runat="server" Text="Resuelto" OnClick="Boton_Resuelto_Administrador_Click"/>                             
                <asp:Button ID="Boton_Cerrar_Formulario_Administrador" runat="server" Width="100%" Text="X" OnClick="Boton_Cerrar_Formulario_Administrador_Click" />                
                
             </div>




















      ------------------------------------------------------------------------------------------------------------------

        <div>            
            <asp:GridView ID="GridView_Supervisor" runat="server" OnSelectedIndexChanged="Identificador_Supervisor" AutoGenerateColumns="false" DataKeyNames="ID_PedidoEjercicioVideo">
                
                <Columns>
                
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Número de Ejercicio">
                                                    
                        <ItemTemplate>
                            <asp:LinkButton ID="Seleccionar_Supervisor" CommandName="select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("id_PedidoEjercicioVideo") %></asp:LinkButton>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" />      
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaPedidoEjercicioVideo" HeaderText="Pedido" />  
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Administrador" HeaderText="Supervisor" />         
                    
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="OK Realizado">
                    
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_Supervisor" runat="server" Enabled="false" Checked='<%# Eval ("realizadoOKPedidoEjercicioVideo") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>                                           
                                            
                </Columns>
                                        
            </asp:GridView>
        
        </div>                                        
                            
        <div id="Centro_Supervisor" runat="server" visible="false">
           <asp:LinkButton ID="Anterior_Supervisor" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Supervisor" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>

        <div id="Extremo_Supervisor" runat="server">
           <asp:LinkButton ID="Anterior_Supervisor_Ultimo" Visible="false" runat="server" OnClick="Anterior_Supervisor_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Supervisor_Primero" runat="server" OnClick="Siguiente_Supervisor_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>
                                    
       <div id="Formulario_Supervisor" runat="server" visible="false" >
            <div>
                <h3 class="titulo_formulario">Formulario</h3>
            </div>
            <div>
                <label>Adjunto</label>
                <asp:Button ID="BtnAdjunto_Supervisor" runat="server" Text="Adjunto" OnClick="BtnAdjunto_Supervisor_Click" />
            </div>
            <div>
                <label>Ficha</label>
                <asp:Button ID="BtnFicha_Supervisor" runat="server" Text="Ficha" OnClick="BtnFicha_Supervisor_Click" />
            </div>
            <div>
                <label>MATH</label>
                <asp:Button ID="BtnMath_Supervisor" runat="server" Text="Math" OnClick="BtnMath_Supervisor_Click" />
            </div>
            <div>
                <label>Limpio</label>
                <asp:Button ID="BtnLimpio_Supervisor" runat="server" Text="Limpio" OnClick="BtnLimpio_Supervisor_Click" />
            </div>
            <div>
                <label>Usuario</label>
                <asp:Label ID="Usuario_Supervisor" Width="100%" runat="server"></asp:Label>
            </div>
            <div>
                 <label>Pedido</label>
                 <asp:Label ID="FechaPedido_Supervisor" Width="100%" runat="server"></asp:Label>
            </div>           
            <div>
                 <label>Profesor</label>
                 <asp:Textbox ID="Profesor_Supervisor" Width="100%" runat="server"></asp:Textbox>
             </div>
             <div>
                 <label>Ejercicio</label>
                 <asp:CheckBox ID="CheckBoxEjercicio_Supervisor" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>Explicacion</label>
                 <asp:CheckBox ID="CheckBoxExplicacion_Supervisor" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>RealizadoOK</label>
                 <asp:CheckBox ID="CheckBoxRealizadoOK_Supervisor" runat="server" />
             </div>
             

        </div>

            <div>
                <asp:Button ID="Boton_No_Resolver_Supervisor" Width="100%" runat="server" Text="No resolver" OnClick="Boton_No_Resolver_Supervisor_Click"  />
                <asp:Button ID="Boton_Resolver_Supervisor" Width="100%" runat="server" Text="Resolver" OnClick="Boton_Resolver_Supervisor_Click"  />
                <asp:Button ID="Boton_Resuelto_Supervisor" Width="100%" runat="server" Text="Resuelto" OnClick="Boton_Resuelto_Supervisor_Click"/>
                <asp:Button ID="Boton_Borrar_Supervisor" runat="server" Width="100%" Text="Borrar" OnClick="Boton_Borrar_Supervisor_Click"/>                
                <asp:Button ID="Boton_Cerrar_Formulario_Supervisor" runat="server" Width="100%" Text="X" OnClick="Boton_Cerrar_Formulario_Supervisor_Click" />                
                <asp:Button ID="Boton_Excel_Supervisor" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Supervisor_Click" />
             </div>

------------------------------------------------------------------------------------------------------------------------------------
        <div>            
            <asp:GridView ID="GridView_Dios" runat="server" OnSelectedIndexChanged="Identificador_Dios" AutoGenerateColumns="false" DataKeyNames="ID_PedidoEjercicioVideo">
                
                <Columns>
                
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Número de Ejercicio">
                                                    
                        <ItemTemplate>
                            <asp:LinkButton ID="Seleccionar_Dios" CommandName="select" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" runat="server"><%# Eval ("id_PedidoEjercicioVideo") %></asp:LinkButton>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Usuario" HeaderText="Usuario" />      
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="fechaPedidoEjercicioVideo" HeaderText="Pedido" />  
                    <asp:BoundField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" DataField="id_Administrador" HeaderText="Dios" />         
                    
                    <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="OK Realizado">
                    
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_Dios" runat="server" Enabled="false" Checked='<%# Eval ("realizadoOKPedidoEjercicioVideo") %>' />
                        </ItemTemplate>

                    </asp:TemplateField>                                           
                                            
                </Columns>
                                        
            </asp:GridView>
        
        </div>                                        
                            
        <div id="Centro_Dios" runat="server" visible="false">
           <asp:LinkButton ID="Anterior_Dios" runat="server" OnClick="Anterior_Dios_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Dios" runat="server" OnClick="Siguiente_Dios_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>

        <div id="Extremo_Dios" runat="server">
           <asp:LinkButton ID="Anterior_Dios_Ultimo" Visible="false" runat="server" OnClick="Anterior_Dios_Click"><< Anterior &nbsp</asp:LinkButton>
           <asp:LinkButton ID="Siguiente_Dios_Primero" runat="server" OnClick="Siguiente_Dios_Click">&nbsp Siguiente >></asp:LinkButton>
        </div>
                                    
       <div id="Formulario_Dios" runat="server" visible="false" >
            <div>
                <h3 class="titulo_formulario">Formulario</h3>
            </div>
            <div>
                <label>Adjunto</label>
                <asp:Button ID="BtnAdjunto_Dios" runat="server" Text="Adjunto" OnClick="BtnAdjunto_Dios_Click" />
            </div>
            <div>
                <label>Ficha</label>
                <asp:Button ID="BtnFicha_Dios" runat="server" Text="Ficha" OnClick="BtnFicha_Dios_Click" />
            </div>
            <div>
                <label>MATH</label>
                <asp:Button ID="BtnMath_Dios" runat="server" Text="Math" OnClick="BtnMath_Dios_Click" />
            </div>
            <div>
                <label>Limpio</label>
                <asp:Button ID="BtnLimpio_Dios" runat="server" Text="Limpio" OnClick="BtnLimpio_Dios_Click" />
            </div>
            <div>
                <label>Usuario</label>
                <asp:Label ID="Usuario_Dios" Width="100%" runat="server"></asp:Label>
            </div>
            <div>
                 <label>Pedido</label>
                 <asp:Label ID="FechaPedido_Dios" Width="100%" runat="server"></asp:Label>
            </div>           
            <div>
                 <label>Profesor</label>
                 <asp:Textbox ID="Profesor_Dios" Width="100%" runat="server"></asp:Textbox>
             </div>
             <div>
                 <label>Ejercicio</label>
                 <asp:CheckBox ID="CheckBoxEjercicio_Dios" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>Explicacion</label>
                 <asp:CheckBox ID="CheckBoxExplicacion_Dios" Enabled="false" runat="server" />
             </div>
             <div>
                 <label>RealizadoOK</label>
                 <asp:CheckBox ID="CheckBoxRealizadoOK_Dios" runat="server" />
             </div>
             

        </div>

            <div>
                <asp:Button ID="Boton_No_Resolver_Dios" Width="100%" runat="server" Text="No resolver" OnClick="Boton_No_Resolver_Dios_Click"  />
                <asp:Button ID="Boton_Resolver_Dios" Width="100%" runat="server" Text="Resolver" OnClick="Boton_Resolver_Dios_Click"  />
                <asp:Button ID="Boton_Resuelto_Dios" Width="100%" runat="server" Text="Resuelto" OnClick="Boton_Resuelto_Dios_Click"/>
                <asp:Button ID="Boton_Borrar_Dios" runat="server" Width="100%" Text="Borrar" OnClick="Boton_Borrar_Dios_Click"/>                
                <asp:Button ID="Boton_Cerrar_Formulario_Dios" runat="server" Width="100%" Text="X" OnClick="Boton_Cerrar_Formulario_Dios_Click" />                
                <asp:Button ID="Boton_Excel_Dios" runat="server" Width="100%" Text="Excel" OnClick="Boton_Excel_Dios_Click" />
             </div>

    </form>
</body>
</html>
