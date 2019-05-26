<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carritoCliente.aspx.cs" Inherits="BiblioTEC.GUI.carritoCliente" %>

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

        <!--Manejo de errores-->
        <div class="alert alert-success" role="alert" id="errorAlert" runat="server" visible="false">
              A simple danger alert—check it out!
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

        <div class="container-fluid" style="margin-top: 75px">

            <!-- Creo una fila -->
            <section class="main row row-centered">

                <!-- spacer -->
               <div class="col-lg-4 text-center"></div>

                <!-- Cuadro Login -->
                <div class="col-sm-12 col-md-12 col-lg-4 col-centered">
                    <div class="card border-info" style="max-width: 50rem; margin-bottom: 20px">
                        <!-- Enmarca el Login -->
                        <div class="card-body text-center">
                            <h3 class="card-title" style="margin: 25px">DETALLE DE LA ORDEN</h3>
                            <div class="list-group" id="bookList" runat="server"></div>
                            <div class="row">
                                <h5 class="card-body" id="txtDescuento" runat="server">DESCUENTO:</h5>
                                <h5 class="card-body" id="txtPrecioTotal" runat="server">PRECIO TOTAL:</h5>
                                
                            </div>
                            <div class="row">
                                
                            </div>
                            <div>
                                <asp:Button ID="btnComprar" runat="server" CssClass="btn btn-primary" Style="margin-top: 50px" Text="COMPRAR" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnComprar_Click"></asp:Button>
                            </div>
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

