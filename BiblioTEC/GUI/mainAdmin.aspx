<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainAdmin.aspx.cs" Inherits="BiblioTEC.GUI.mainAdmin" %>

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
                              <a class="dropdown-item" runat="server">Editar mi Informacion</a>
                              <a class="dropdown-item" runat="server">Ver Historial de compras</a>
                              <div class="dropdown-divider"></div>
                              <a class="dropdown-item" href="#" runat="server">Cerrar Sesion</a>
                            </div>
                          </li>

                              </div>
                          

                          </ul>
 
            </div>
                  
        </nav>

        <div class="alert alert-danger" role="alert" id="errorAlert" runat="server" visible="false">
              A simple danger alert—check it out!
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

        <div class="container-fluid" style="margin-bottom: 75px">

            <!-- Creo una fila -->
            <section class="main row row-centered">

                <!-- filtros -->
               <div class="col-lg-2" style="background-color:lightgray; height:1000px" >
                  <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                    <a class="nav-link active" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="true">Libros</a>
                    <a class="nav-link" id="v-pills-profile-tab" data-toggle="pill" href="#v-pills-profile" role="tab" aria-controls="v-pills-profile" aria-selected="false">Librerias</a>
                    <a class="nav-link" id="v-pills-messages-tab" data-toggle="pill" href="#v-pills-messages" role="tab" aria-controls="v-pills-messages" aria-selected="false">Promociones</a>
                      <a class="nav-link" id="v-pills-delete-tab" data-toggle="pill" href="#v-pills-delete" role="tab" aria-controls="v-pills-delete" aria-selected="false">Eliminar Elementos</a>
                    <a class="nav-link" id="v-pills-settings-tab" data-toggle="pill" href="#v-pills-settings" role="tab" aria-controls="v-pills-settings" aria-selected="false">Reportes</a>
                  </div>
               </div>

                <!-- PAGINAS DE ADMINISTRACION -->
                <div class="col-lg-9 col-centered" id="columnaPrueba" runat="server" style="margin-top: 75px; margin-left:90px">
                    <div class="list-group" id="bookList" runat="server"></div>
                    <<div class="tab-content" id="v-pills-tabContent">

                        <div class="tab-pane fade show active col-centered" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <h1 style="color: #0b4980">CREAR NUEVO LIBRO</h1>
                                    <h2 style="margin-bottom: 50px">Todos los campos son de caracter obligatorio</h2>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-2" ></div>
                            <!-- Primera columna de informacion-->
                              <div class="col-sm-12 col-md-12 col-lg-4" >
                                    <div style="margin":"50px">

                                        <p class="card-text">Titulo</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>    
                        
                                        <p class="card-text">Tema</p>
                                        <div style="margin":"40px">                            
                                            <asp:DropDownList ID="DDList_tema" runat="server" CssClass="form-control" ></asp:DropDownList>
                                        </div>  

                                        <p class="card-text">Libreria</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtLibreria" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div> 

                                        <p class="card-text">Cantidad Vendida</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtCantidadVendida" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                        <p class="card-text">Cantidad Disponible</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtCantidadDisponible" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>                                       

                                    </div>
                                </div> 
                            
                            <!-- Segunda columna de informacion-->
                                  <div class="col-sm-12 col-md-12 col-lg-4" >
                                        <div style="margin":"50px">

                                              <p class="card-text">URL de la imagen de Portada</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtFoto" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <p class="card-text">Precio en Dolares</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <p class="card-text">Descripcion</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" Height="195px"></asp:TextBox>
                                            </div>   
                                        
                                        </div>
                                    </div>  
                                </div>

                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <asp:Button ID="btnGuardarLibro" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="GUARDAR LIBRO" UseSubmitBehavior="false" OnClick="btnLibros_Click"></asp:Button>  
                                </div>
                           </div>
                        </div>

                        <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab">
                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <h1 style="color: #0b4980">CREAR NUEVA LIBRERIA</h1>
                                    <h2 style="margin-bottom: 50px">Todos los campos son de caracter obligatorio</h2>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-2" ></div>
                            <!-- Primera columna de informacion-->
                              <div class="col-sm-12 col-md-12 col-lg-4" >
                                    <div style="margin":"50px">

                                        <p class="card-text">Nombre</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtNombreLibreria" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>    

                                        <p class="card-text">Pais</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtPaisLibreria" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div> 

                                        <p class="card-text">Telefono</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtTelefonoLibreria" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                     
                                    </div>
                                </div> 
                            
                            <!-- Segunda columna de informacion-->
                                  <div class="col-sm-12 col-md-12 col-lg-4" >
                                        <div style="margin":"50px">

                                              <p class="card-text">Horario</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtHorarioLibreria" runat="server" CssClass="form-control" placeholder="HH:mm-HH:mm"></asp:TextBox>
                                            </div>

                                            <p class="card-text">Detalle de la Ubicacion</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtDetalleLibreria" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" Height="115px"></asp:TextBox>
                                            </div>  
                                        </div>
                                    </div>  
                                </div>

                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <asp:Button ID="btnLibreria" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="GUARDAR LIBRERIA" UseSubmitBehavior="false" OnClick="btnLibrerias_Click"></asp:Button>  
                                </div>
                           </div>
                        </div>

                        <div class="tab-pane fade" id="v-pills-messages" role="tabpanel" aria-labelledby="v-pills-messages-tab">
                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <h1 style="color: #0b4980">CREAR NUEVA PROMOCION</h1>
                                    <h2 style="margin-bottom: 50px">Todos los campos son de caracter obligatorio</h2>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-2" ></div>
                            <!-- Primera columna de informacion-->
                              <div class="col-sm-12 col-md-12 col-lg-4" >
                                    <div style="margin":"50px">

                                        <p class="card-text">Nombre</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtPromocionNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>    

                                        <p class="card-text">Fecha de Inicio</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtPromocionFInicio" runat="server" CssClass="form-control" placeholder="AAAA-MM-DD"></asp:TextBox>
                                        </div> 

                                        <p class="card-text">Fecha Finalizacion</p>
                                        <div style="margin":"40px">                            
                                            <asp:TextBox ID="txtPromocionFFinal" runat="server" CssClass="form-control" placeholder="AAAA-MM-DD"></asp:TextBox>
                                        </div>
                                     
                                    </div>
                                </div> 
                            
                            <!-- Segunda columna de informacion-->
                                  <div class="col-sm-12 col-md-12 col-lg-4" >
                                        <div style="margin":"50px">

                                              <p class="card-text">Porcentaje de descuento</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtPromocionDescuento" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <p class="card-text">Descripcion de la Promocion</p>
                                            <div style="margin":"40px">                            
                                                <asp:TextBox ID="txtPromocionDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" Height="115px"></asp:TextBox>
                                            </div>  
                                        </div>
                                    </div>  
                                </div>

                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-sm-12 col-md-12 col-lg-8 text-center">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="GUARDAR PROMOCION" UseSubmitBehavior="false" OnClick="btnPromociones_Click"></asp:Button>  
                                </div>
                           </div>
                        </div>

                        <div class="tab-pane fade" id="v-pills-delete" role="tabpanel" aria-labelledby="v-pills-delete-tab">
                            <div class="row">
                                <div class="col-4">
                                    <div class="row">
                                        <div class="col text-center">
                                            <h1 style="color: #0b4980">ELIMINAR LIBRO</h1>
                                        </div>
                                        
                                    </div>
                                    <div style="margin":"40px">                            
                                            <asp:DropDownList ID="DDList_DeleteLibro" runat="server" CssClass="form-control" ></asp:DropDownList>
                                        </div> 
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="ELIMINAR" UseSubmitBehavior="false" OnClick="btnEliminarLibro_Click"></asp:Button> 
                                        </div>
                                    </div>
                                </div>

                                <div class="col-4">
                                    <div class="row">
                                        
                                        <div class="col text-center">
                                            <h1 style="color: #0b4980">ELIMINAR LIBRERIA</h1>
                                        </div>
                                        
                                    </div>
                                    <div style="margin":"40px">                            
                                            <asp:DropDownList ID="DDList_DeleteLibreria" runat="server" CssClass="form-control" ></asp:DropDownList>
                                        </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="ELIMINAR" UseSubmitBehavior="false" OnClick="btnPromociones_Click"></asp:Button> 
                                        </div>
                                    </div>
                                </div>

                                <div class="col-4">
                                    <div class="row">
                                        <div class="col text-center">
                                            <h1 style="color: #0b4980">ELIMINAR PROMOCION</h1>
                                        </div>
                                        
                                    </div>
                                    <div style="margin":"40px">                            
                                            <asp:DropDownList ID="DDList_DeletePromocion" runat="server" CssClass="form-control" ></asp:DropDownList>
                                        </div> 
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="ELIMINAR" UseSubmitBehavior="false" OnClick="btnEliminarPromocion_Click"></asp:Button> 
                                        </div>
                                    </div>  
                                </div>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="v-pills-settings" role="tabpanel" aria-labelledby="v-pills-settings-tab">reportes</div>
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