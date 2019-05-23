<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookInfo.aspx.cs" Inherits="BiblioTEC.GUI.bookInfo" %>

<!DOCTYPE html>


<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>BiblioTEC - Main</title>

</head>

<body>
    <!--Linea Azul arriba de la pagina-->
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark" style="background-color: #0b4980;">
            <a class="navbar-brand" href="main.aspx">BiblioTEC</a>
         
            <div class=" navbar-expand-lg" style="margin-left:25px; margin-right:25px">
                

                          <ul class="navbar-nav mr-auto">
                              <div class="row">
                                      <li class="nav-item dropdown" style="margin-right:15px">
                            <a class="nav-link dropdown-toggle" href="#" id="btnPerfil" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="color:white; margin:5px">
                                <i class="fa fa-fw fa-user" style="color:white"></i>
                              Perfil
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                              <a class="dropdown-item" href="#" onserverclick="editarInfo" runat="server">Editar mi Informacion</a>
                              <a class="dropdown-item" href="#"onserverclick="verHistorial" runat="server">Ver Historial de compras</a>
                              <div class="dropdown-divider"></div>
                              <a class="dropdown-item" href="#" onserverclick="logOut" runat="server">Cerrar Sesion</a>
                            </div>
                          </li>

                          </li class="nav-item active">
                            <a href="#" style="color:white; margin:12px" id="btnCarrito" runat="server" ><i class="fa fa-fw fa-shopping-cart" style="color:white"></i> Carrito</a>
                          </li>


                              </div>
                          

                          </ul>
 
            </div>
                  
        </nav>

        <div class="container-fluid" style="margin-top: 75px">

            <!-- Creo una fila -->
            <section class="main row row-centered">

                <!-- spacer -->
               <div class="col-lg-6">
                   <div class="card-body">
                       <div class="row">
                           <div class="col-10">
                               <h1 id="bookTitle" runat="server" class="card-title">Titulo del libro</h1>
                           </div>
                           <div class="col-2">
                               <h2 id="bookPrice" runat="server" class="card-title" style="margin-top:15px; color:blue">Precio</h2>
                           </div>
                       </div>
                   
                   
                       <h5 style="color:cornflowerblue; margin-left:auto" class="card-text" id="bookIssn" runat="server">id</h5>
                       <h5 style="color:gray; margin-left:auto" class="card-text" id="bookTheme" runat="server">tema</h5>

                       <div style="margin-top:50px; margin-left:5px>
                           <p class="card-text" id="bookDescription" runat="server">

                               Contratapa que no cumple con la función que el lector espera. Solución: Las contratapas suelen presentar en pocas líneas el resumen del argumento del libro. 
                               En otras ocasiones se opta reproducción literal de un pasaje del libro, cuidadosamente seleccionado para despertar interés por su lectura
                               Contratapa que no cumple con la función que el lector espera. Solución: Las contratapas suelen presentar en pocas líneas el resumen del argumento del libro. 
                               En otras ocasiones se opta reproducción literal de un pasaje del libro, cuidadosamente seleccionado para despertar interés por su lectura
                               Contratapa que no cumple con la función que el lector espera. Solución: Las contratapas suelen presentar en pocas líneas el resumen del argumento del libro. 
                               En otras ocasiones se opta reproducción literal de un pasaje del libro, cuidadosamente seleccionado para despertar interés por su lectura

                           </p>
                       </div>

                       
                   </div>
                
               </div>

                <div class="col-lg-2">
                    <image src ="http://i.imgur.com/ozxH9ZY.png"  width="350px" height="500px" allign-right="true"></image>

                    <div class="row" style="margin:10px">
                           <div class="col-6">
                           </div>
                           <div class="col-2">
                               <asp:Button ID="btnComprar" runat="server" CssClass="btn btn-primary" Text="AGREGAR AL CARRITO" UseSubmitBehavior="false"></asp:Button> 
                           </div>
                       </div>
                </div>

                <!-- Cuadro Login -->
                <div class="col-sm-12 col-md-12 col-lg-4 col-centered">
                    <div class="card border-info" style="max-width: 20rem; margin-bottom: 20px; margin-left:250px">
                        <!-- Enmarca el Login -->
                        <div class="card-body text-center">
                            <h5 class="card-title" style="margin: 25px">MAIN</h5>
                            <div></div>
                        </div>
                    </div>

                    <div class="card border-info" style="max-width: 20rem; margin-bottom: 20px; margin-left:250px">
                        <!-- Enmarca el Login -->
                        <div class="card-body text-center">
                            <h5 class="card-title" style="margin: 25px">MAIN</h5>
                            <div></div>
                        </div>
                    </div>

                    <div class="card border-info" style="max-width: 20rem; margin-bottom: 20px; margin-left:250px">
                        <!-- Enmarca el Login -->
                        <div class="card-body text-center">
                            <h5 class="card-title" style="margin: 25px">MAIN</h5>
                            <div></div>
                        </div>
                    </div>
                </div>
            </section>
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
