<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentation.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- La referencia a Bootstrap ya debe estar en Main.Master -->



   <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
  <!-- Indicadores -->
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>

  <!-- Imágenes del carrusel -->
  <div class="carousel-inner">
    <!-- Primera imagen (activa) -->
    <div class="carousel-item active">
      <img src="resources/imagenes/imagen1.jpeg"  id="fotos" class="d-block w-100" alt="First slide">
    </div>
    <!-- Segunda imagen -->
    <div class="carousel-item">
      <img src="resources/imagenes/imagen2.jpeg" id="fotos2<" class="d-block w-100" alt="Second slide">
    </div>
    <!-- Tercera imagen -->
    <div class="carousel-item">
      <img src="resources/imagenes/imagen4.jpeg"  id="fotos3"class="d-block w-100" alt="Third slide">
    </div>
  </div>

 <!-- Controles de navegación -->
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>


    
    <!-- Featurettes -->
    <hr class="featurette-divider">
    <div class="row featurette">
        <div class="col-md-7">
            <h2 class="featurette-heading">Acerca de Nosotros <span class="text-muted">Swipe & Go</span></h2>
            <p class="lead">Bienvenidos a Swipe & Go, tu tienda virtual especializada en electrodomésticos, tecnología para el hogar y accesorios para computadoras. En Swipe & Go, nos apasiona ofrecer productos innovadores que faciliten tu vida y transformen tu hogar. Nos enfocamos en brindarte una experiencia de compra ágil, segura y cómoda, tanto en línea como en nuestra tienda física.</p>
            <p class="lead">Además de nuestra tienda en línea, estamos trabajando en llevar la experiencia de compra a un nuevo nivel en nuestra tienda física. Estamos implementando un sistema de carrito inteligente que permite a nuestros clientes realizar sus compras de manera rápida y sin complicaciones. Este sistema está diseñado para identificar automáticamente los productos que el cliente selecciona, mostrando en tiempo real el total de la compra en una pantalla. De esta forma, buscamos ofrecer una experiencia de compra innovadora y eficiente, adaptada a las nuevas tecnologías.
</p>
        </div>
        <div class="col-md-5">
            <img src="resources/imagenes/poster1.png" class="img-fluid mx-auto" alt="Featurette 1">
        </div>
    </div>
     <!-- Content Section -->
    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-4">
                <h3>Mision</h3>
                <p>Nuestra misión en Swipe & Go es brindar a nuestros clientes acceso a productos de alta calidad en electrodomésticos, tecnología para el hogar y accesorios para computadoras, con el respaldo de una experiencia de compra simple y segura. Nos enfocamos en innovar constantemente para ofrecer soluciones tecnológicas que mejoren la calidad de vida  de nuestros clientes, ya sea en nuestra tienda virtual o física.</p>
            </div>
            
            <div class="col-sm-4">
                <h3>Vision</h3>
                <p>Aspiramos a ser la tienda líder en electrodomésticos y tecnología para el hogar, ofreciendo tanto una plataforma en línea moderna y fácil de usar, como una tienda física innovadora que simplifique la experiencia de compra. Queremos integrar lo último en soluciones tecnológicas para que nuestros clientes disfruten de la mayor comodidad y eficiencia posible en todo momento.</p>
            </div>
        </div>
    </div>

    <hr class="featurette-divider">
    <div class="row featurette">
        <div class="col-md-7 order-md-2">
            <h2 class="featurette-heading">Nuestro Equipo </h2>
            <p class="lead">Swipe & Go es el fruto del trabajo y la dedicación de tres desarrolladores de software que decidimos emprender para hacer llegar la mejor tecnología a todos los hogares. Con un enfoque en la innovación, estamos comprometidos con el crecimiento de nuestra tienda virtual y con la creación de experiencias de compra únicas en nuestra tienda física, siempre ofreciendo productos de calidad que mejoren la vida diaria de nuestros clientes.</p>
        </div>
        <div class="col-md-5 order-md-1">
            <img src="resources/imagenes/poster2.png" class="img-fluid mx-auto" alt="Featurette 2">
        </div>
        </div>
  <div class="container mt-3">
  <h2>Nuestro Equipo de Trabajo</h2>

  <div class="row">
    <!-- Primera tarjeta -->
    <div class="col-md-4 mb-4">
      <div class="card" style="width: 80%;">
        <img class="card-img-top" src="resources/imagenes/ninaa.png"  alt="Card image" style="width:100%">
        <div class="card-body">
          <h4 class="card-title">Carolina ALonso</h4>
          <p class="card-text">Estudiante Universitaria</p>
        </div>
      </div>
    </div>

    <!-- Segunda tarjeta -->
    <div class="col-md-4 mb-4">
      <div class="card" style="width: 80%;">
        <img class="card-img-top"src="resources/imagenes/chico.png"  alt="Card image" style="width:100%">
        <div class="card-body">
          <h4 class="card-title">Dennis Velez</h4>
          <p class="card-text">Estudiante Universitario</p>
        </div>
      </div>
    </div>

    <!-- Tercera tarjeta -->
    <div class="col-md-4 mb-4">
      <div class="card" style="width: 80%;">
        <img class="card-img-top" src="resources/imagenes/nina.png" alt="Card image" style="width:100%">
        <div class="card-body">
          <h4 class="card-title">Anny Diaz</h4>
          <p class="card-text">Estudiante Universitaria</p>
        </div>
      </div>
    </div>
  </div>
</div>





</asp:Content>
