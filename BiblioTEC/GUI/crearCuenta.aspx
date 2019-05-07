<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearCuenta.aspx.cs" Inherits="BiblioTEC.GUI.crearCuenta" %>

<!DOCTYPE html>


<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>BiblioTEC - Crear Cuenta</title>

</head>

<body>
    <!--Linea Azul arriba de la pagina-->
    <form id="form1" runat="server">
        <nav class="navbar navbar-dark" style="background-color: #0b4980;">
            <a class="navbar-brand" href="#">BiblioTEC</a>
        </nav>

        <div class="alert alert-danger" role="alert" id="errorAlert" runat="server" visible="false">
              A simple danger alert—check it out!
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

        <div class="container-fluid" style="margin-top: 75px">


            <div class="row">
                <div class="col-lg-2"></div>
                <div class="col-sm-12 col-md-12 col-lg-8 text-center">

                    <h1 style="color: #0b4980">Registrar Nuevo Usuario</h1>
                    <h2 style="margin-bottom: 50px">Todos los campos son de caracter obligatorio</h2>
                    

                </div>

            </div>
            <!-- Creo una fila -->
            <section class="main row">

                <div class="col-lg-2"></div>
                
              
                <!-- Primera columna de informacion-->
              <div class="col-sm-12 col-md-12 col-lg-4" >
                    <div style="margin":"50px">

                        <p class="card-text">Nombre</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej. Mario"></asp:TextBox>
                        </div>    
                        
                        <p class="card-text">Primer Apellido</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" placeholder="Ej. Rodriguez"></asp:TextBox>
                        </div>

                        <p class="card-text">Segundo Apellido</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" placeholder="Ej. Mendez"></asp:TextBox>
                        </div>   

                        <p class="card-text">Numero de Cedula</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" placeholder="Ej. 123038734"></asp:TextBox>
                        </div> 

                        <p class="card-text">Fecha de Nacimiento</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="DD/MM/AA"></asp:TextBox>
                        </div>

                        <p class="card-text">Tipo de Cliente</p>
                        <div style="margin":"40px">
                            <asp:DropDownList ID="DDList_tipoCliente" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDList_tipoCliente_SelectedIndexChanged"></asp:DropDownList>
                        </div> 


                    </div>
                </div>

                 <!-- Segunda columna de informacion-->
              <div class="col-sm-12 col-md-12 col-lg-4">
                    <div style="margin":"50px">

                         <p class="card-text">Ubicacion</p>
                        <div style="margin":"40px">
                            <asp:DropDownList ID="DDList_ubicacion" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDList_ubicacion_SelectedIndexChanged"></asp:DropDownList>
                        </div> 

                        <p class="card-text">Correo Electronico</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ej. sucorreo@ejemplo.com"></asp:TextBox>
                        </div>    
                        
                        <p class="card-text">Numero de Telefono</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ej. 83456581,54865201"></asp:TextBox>
                        </div>

                        <p class="card-text">Nombre de Usuario</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ej. mario06"></asp:TextBox>
                        </div>   

                        <p class="card-text">Contrasena</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtConstrasena" runat="server" CssClass="form-control" type="password"></asp:TextBox>
                        </div> 

                        <p class="card-text"> Confirmar Contrasena</p>
                        <div style="margin":"40px">                            
                            <asp:TextBox ID="txtContrasenaConfirmacion" runat="server" CssClass="form-control" type="password"></asp:TextBox>
                        </div> 
                   
                    </div>
                </div>
            </section>

            <div class="row">
                <div class="col-lg-2"></div>
                    <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                        <asp:Button ID="btnCrearCuenta" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="CREAR CUENTA" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnCrearCuenta_Click"></asp:Button>  
                    </div>
                    
                
            </div>


        </div>

        <!-- Modal de manejo de errores -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="First Name" class="form-control"></asp:TextBox><br />
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="Middle Name" class="form-control"></asp:TextBox><br />
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="Last Name" class="form-control"></asp:TextBox><br />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                        <%--<button type="button"  class="btn btn-primary">
                                        Save changes</button>--%>
                        <asp:Button Text="Save" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        

    </form>



    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.bundle.min.js" integrity="sha384-pjaaA8dDz/5BgdFUPX6M/9SUZv4d12SUPF0axWc+VRZkx5xU3daN+lYb49+Ax+Tl" crossorigin="anonymous"></script>
</body>
</html>
