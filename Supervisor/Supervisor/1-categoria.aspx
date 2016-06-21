<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1-categoria.aspx.cs" Inherits="Supervisor._1_categoria" %>

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
            No tiene permisos
            <br />
            ---------------------------------------------------------------------------------------------------------------<br />            
            Panel 2<br />
            
         <div>
            &nbsp;Administrador
            <asp:TextBox ID="Administrador_Supervisor" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="BtnAdministrador" runat="server" Text="Buscar Administrador" OnClick="BtnAdministrador_Click" />
             <br />
             <br />
         </div>
            
         <div>
            <label>Administrador</label>
                <asp:DropDownList ID="DropAdministrador_Supervisor" runat="server">
                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Modificar -PC-"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Alta"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Alta - Modificar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Alta - Modificar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Ver - Alta - Modificar - Borrar - Excel"></asp:ListItem>
                    

                </asp:DropDownList>
            </div>

           <div>
            <label>Comentario Administrador</label>
                <asp:DropDownList ID="DropComentarioAdministrador_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Envio"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Borrar - Excel"></asp:ListItem>                    
                    

                </asp:DropDownList>
            </div>

            <div>
            <label>Control Administrador</label>
                <asp:DropDownList ID="DropControlAdministrador_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>                                      
                   

                </asp:DropDownList>
            </div>

            <div>
            <label>Usuario</label>
                <asp:DropDownList ID="DropUsuario_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Buscar Usuarios"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Alta"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Alta - Modificar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Alta - Modificar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Ver - Alta - Modificar - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Comentario Usuario</label>
                <asp:DropDownList ID="DropComentarioUsuario_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                   
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>                    
                    <asp:ListItem Value="6" Text="Ver - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Empresa</label>
                <asp:DropDownList ID="DropEmpresa_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    

                </asp:DropDownList>
            </div>

         <div>
            <label>Precios</label>
                <asp:DropDownList ID="DropPrecios_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Modificar"></asp:ListItem> 
                    

                </asp:DropDownList>
            </div>

         <div>
            <label>Ofertas</label>
                <asp:DropDownList ID="DropOfertas_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Modificar"></asp:ListItem> 
                  

                </asp:DropDownList>
            </div>

         <div>
            <label>Valor Ofertas</label>
                <asp:DropDownList ID="DropValorOfertas_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Modificar"></asp:ListItem> 
                  

                </asp:DropDownList>
            </div>

         <div>
            <label>Compra Ejercicios</label>
                <asp:DropDownList ID="DropEjercicios_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>                    
                    <asp:ListItem Value="5" Text="Ver - Alta"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Alta - Modificar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Alta - Modificar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Ver - Alta - Modificar - Borrar - Excel"></asp:ListItem>
                    

                </asp:DropDownList>
            </div>

         <div>
            <label>Compra Videos</label>
                <asp:DropDownList ID="DropExplicacion_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>                    
                    <asp:ListItem Value="5" Text="Ver - Alta"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Alta - Modificar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Alta - Modificar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Ver - Alta - Modificar - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Insertar Ejercicios</label>
                <asp:DropDownList ID="DropInsertarEjercicios_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                    
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Actualizar Ejercicios</label>
                <asp:DropDownList ID="DropActualizarEjercicios_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                    
                    

                </asp:DropDownList>
            </div>

         <div>
            <label>Tarjeta Prepaga</label>
                <asp:DropDownList ID="DropTarjetaPrepaga_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                    <asp:ListItem Value="1" Text="Buscar"></asp:ListItem>    
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>              
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Borrar - Modificar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Alta - Modificar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Ver - Alta - Modificar - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Carga Automatica</label>
                <asp:DropDownList ID="DropCargaAutomatica_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                                        
                    <asp:ListItem Value="4" Text="PayPal"></asp:ListItem>
                    <asp:ListItem Value="5" Text="MercadoPago"></asp:ListItem>
                    <asp:ListItem Value="6" Text="PayPal - Mercado Pago"></asp:ListItem>

                </asp:DropDownList>
            </div>

         <div>
            <label>Carga Manual</label>
                <asp:DropDownList ID="DropCargaManuel_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                       
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>              
                    <asp:ListItem Value="5" Text="Ver - Modificar"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Ver - Modificar - Excel"></asp:ListItem>                   
                    

                </asp:DropDownList>
            </div>

         <div>
            <label>Facturacion</label>
                <asp:DropDownList ID="DropFacturacion_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem> 
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Moviminetos</label>
                <asp:DropDownList ID="DropMovimientos_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                   
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>                    
                    <asp:ListItem Value="6" Text="Ver - Borrar - Excel"></asp:ListItem>
                  

                </asp:DropDownList>
            </div>


          <div>
            <label>Explicaciones Pedidas</label>
                <asp:DropDownList ID="DropExplicacionesPedidas_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                   
                    <asp:ListItem Value="4" Text="Ver"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Borrar"></asp:ListItem>                    
                    <asp:ListItem Value="6" Text="Ver - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
            </div>

         <div>
            <label>Ejercicios Pedidos</label>
                <asp:DropDownList ID="DropEjerciciosPedidos_Supervisor" runat="server">

                    <asp:ListItem Value="0" Text="Sin permisos"></asp:ListItem>                   
                    <asp:ListItem Value="4" Text="Ver - Formulario"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Ver - Formulario - Liberar"></asp:ListItem>                    
                    <asp:ListItem Value="6" Text="Ver - Formulario - Liberar - Borrar"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Ver - Formulario - Liberar - Borrar - Excel"></asp:ListItem>
                   

                </asp:DropDownList>
             <br />
             <br />
            </div>
         <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar Administrador" OnClick="BtnActualizar_Click" />
         <br />
            ---------------------------------------------------------------------------------------------------------------<br />
            Panel 3<br />
            <br />
           <div>
            &nbsp;Administrador&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Administrador_Dios" runat="server"></asp:TextBox>
               <br />
         </div>
            
         
            Empresa&nbsp;
            <asp:TextBox ID="Empresa_Dios" runat="server"></asp:TextBox>
            <br />
            <br />
            
         
         <asp:Button ID="BtnPermisos_Dios" runat="server" Text="Administrador Dios" OnClick="BtnPermisos_Dios_Click" />

        </div>
    </form>
</body>
</html>
