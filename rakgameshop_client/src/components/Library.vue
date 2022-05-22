<script>
import HeaderBar from "./shared/HeaderBarLib.vue";
import FooterBar from "./shared/FooterBar.vue";

export default {
  components: {
    HeaderBar,
    FooterBar,
  },
};
</script>

<template>
  <div>
    <HeaderBar spanLinks="true" />
    <div class="container mt-4" style="margin-bottom: 60px">
      <div class="row justify-content-center mb-3" style="margin-top: 100px">
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/among_us.jpg" class="card-img-top" />
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
            <img src="../assets/forza_horizon_5.jpg" class="card-img-top" />
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
            <img src="../assets/cyberpunk_2077.png" class="card-img-top" />
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
            <img src="../assets/fifa_22.jpg" class="card-img-top" />
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
      <div class="row justify-content-center mb-3">
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/rainbow_six_siege.jpg" class="card-img-top" />
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
            <img src="../assets/the_witcher_33.jpg" class="card-img-top" />
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
            <img src="../assets/far-cry-6.jpeg" class="card-img-top" />
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
            <img src="../assets/mafia_3.jpg" class="card-img-top" />
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
      <div class="row justify-content-center">
        <div class="col-3">
          <div class="card game-card">
            <img src="../assets/rainbow_six_siege.jpg" class="card-img-top" />
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
            <img src="../assets/the_witcher_33.jpg" class="card-img-top" />
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
            <img src="../assets/far-cry-6.jpeg" class="card-img-top" />
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
            <img src="../assets/mafia_3.jpg" class="card-img-top" />
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
.game-card {
  background-color: #1c1b1b;
  color: #ffffff;
  border: 2px solid #340e80;
}
.game-card:hover {
  cursor: pointer;
}
.game-carousel {
  background-color: #080808;
}
</style>