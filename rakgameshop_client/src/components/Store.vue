<script>
import HeaderBar from "./shared/HeaderBar.vue";
import FooterBar from "./shared/FooterBar.vue";

export default {
  components: {
    HeaderBar,
    FooterBar
  },
};
</script>

<template>
  <div>
    <HeaderBar spanLinks="true" />
    <div class="container-fluid game-carousel" style="margin-top: 70px">
      <div class="container">
        <div class="row justify-content-center align-items-center">
          <div class="col-8">
            <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
              <div class="carousel-indicators">
                <button type="button"  data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                 <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
              </div>
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="../assets/among_us.jpg" class="d-block w-100" />
                </div>
                <div class="carousel-item">
                  <img src="../assets/cyberpunk_2077.png" class="d-block w-100" />
                </div>
                <div class="carousel-item">
                  <img src="../assets/fifa_22.jpg" class="d-block w-100" />
                </div>
                 <div class="carousel-item">
                  <img src="../assets/the_witcher_33.jpg" class="d-block w-100" />
                </div>
              </div>
              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
              </button>
              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container mt-4 mb-5">
      <div class="row justify-content-center mb-3">
         <div class="col-3">
          <div class="card game-card">
            <img src="../assets/among_us.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">Amoug Us</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 4,50</b></p>
              </div>
            </div>
          </div>
        </div>
         <div class="col-3">
          <div class="card game-card">
            <img src="../assets/forza_horizon_5.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">Forza Horizon 5</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 140,90</b></p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/cyberpunk_2077.png" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">cyberpuk 2077</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 99,90</b></p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/fifa_22.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">FIFA 22</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 120,49</b></p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="row justify-content-center">
         <div class="col-3">
          <div class="card game-card">
            <img src="../assets/rainbow_six_siege.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">Tom Clancy's: Rainbow Six Siege</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 89,00</b></p>
              </div>
            </div>
          </div>
        </div>
         <div class="col-3">
          <div class="card game-card">
            <img src="../assets/the_witcher_33.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">The Witcher 3</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 79,50</b></p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/far-cry-6.jpeg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">Far Cry 6</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 69,49</b></p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/mafia_3.jpg" class="card-img-top">
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">Mafia 3</p>
              </div>
              <div class="d-flex flex-row-reverse">
                <p class="card-text"><b>R$ 79,99</b></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <FooterBar />
  </div>
</template>

<style>
  .game-card{
    background-color: #1C1B1B;
    color: #FFFFFF;
    border: 2px solid #340E80;  
  }
  .game-card:hover{
    cursor: pointer;
  }
  .game-carousel{
    background-color: #080808;
  }
</style>