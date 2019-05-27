<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainAgente.aspx.cs" Inherits="BiblioTEC.GUI.mainAgente" %>

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
            <a class="navbar-brand" href="#">BiblioTEC</a>
        </nav>

        <div class="container-fluid" style="margin-top: 75px">

            <!-- Creo una fila -->
            <section class="main row row-centered">

                <!-- spacer -->
               <div class="col-lg-4" style=" height:1000px" >
                                      <div class="card border-info text-center">
                                          <div class="row" style="margin-top:10px">
                                                  <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar un libro" style="margin-left:20px; margin-right:20px; margin-top:10px"></asp:TextBox>
                                              
                                              </div>

                                       <div class="row" style ="margin-top:10px">
                                           <asp:DropDownList ID="DDList_Cantidad" runat="server" CssClass="form-control" style="margin-left:20px; margin-right:20px; margin-top:10px"></asp:DropDownList>
                                       </div>
                                        
                                          <div class="row" style="margin-left:20px">
                                              <h3> Filtros </h3>
                                          </div>
                                       <div class="row">
                                           
                                           <div class="col-6 col-centered">
                                               
                                               <asp:CheckBox id="checkCliente" runat="server"
                                                    AutoPostBack="False"
                                                    Text="Cliente"
                                                    TextAlign="Right"
                                                    CssClass="form-check"
                                                />

                                               <asp:CheckBox id="checkTema" runat="server"
                                                    AutoPostBack="False"
                                                    Text="Tema"
                                                    TextAlign="Right"
                                                    CssClass="form-check"
                                                />
                                           </div>
                                           <div class="col">
                                               <asp:CheckBox id="checkEstado" runat="server"
                                                    AutoPostBack="False"
                                                    Text="Estado"
                                                    TextAlign="Right"
                             
                                                    CssClass="form-check"
                                                />

                                               <asp:CheckBox id="checkFecha" runat="server"
                                                    AutoPostBack="False"
                                                    Text="Fecha"
                                                    TextAlign="Right"
                            
                                                    CssClass="form-check"
                                                />
                                           </div>
                                       </div>

                                       <div class="row" style="margin-left:20px">
                                           <h3> Rango de Fechas</h3>
                                       </div>

                                       <div class="row" style="margin-left:20px; margin-right:20px">
                                           <h5>Desde</h5> <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" style=" float:left; width:132px; margin-right:10px" placeholder="AAAA-MM-DD"></asp:TextBox>
                                           <h5 style="margin-left:10px">Hasta</h5> <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="form-control" style=" float:left; width:132px" placeholder="AAAA-MM-DD"></asp:TextBox>
                                       </div>

                                          <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-light" Text="BUSCAR" UseSubmitBehavior="false" style="margin:10px; float:right;"></asp:Button> 
                                      </div>
                                   </div>

                <!-- Cuadro Login -->
                <div class="col-sm-12 col-md-12 col-lg-4 col-centered">
                    <div class="card border-info" style="max-width: 50rem; margin-bottom: 20px">
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

