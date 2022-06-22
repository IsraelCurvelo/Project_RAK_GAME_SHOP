<script>
import HeaderBar from "./shared/HeaderBar.vue";
import FooterBar from "./shared/FooterBar.vue";

export default {
  components: {
    HeaderBar,
    FooterBar
  },
  data(){
    return{
      jogos: [],
      jogosCarousel: [],
      usuario: {}
    }
  },
  mounted(){
      this.usuario = this.$root.usuario;
      if(this.usuario == null){
        return this.$router.push({ name: 'login' })
      }
  },
  created() {
    this.$http.get('http://localhost:5000/api/admin/buscarjogos').then(res =>{
      this.jogos = res.body;
      if(this.jogos[0] != undefined){
        this.jogosCarousel.push(this.jogos[0]);
      }
      if(this.jogos[1] != undefined){
        this.jogosCarousel.push(this.jogos[1]);
      }
      if(this.jogos[2] != undefined){
        this.jogosCarousel.push(this.jogos[2]);
      }
      if(this.jogos[3] != undefined){
        this.jogosCarousel.push(this.jogos[3]);
      }
    }, res => {
      console.log(res);
    });
  }
};
</script>

<template>
  <div>
    <HeaderBar />
    <div class="container-fluid game-carousel">
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
                 <router-link :to="`/gameDetail:${this.jogosCarousel[0].id}`">
                    <img :src="require(`../assets/${this.jogosCarousel[0].urlFoto}`)" class="d-block w-100" />
                  </router-link>
                </div>
                <div class="carousel-item">
                   <router-link :to="`/gameDetail:${this.jogosCarousel[1].id}`">
                    <img :src="require(`../assets/${this.jogosCarousel[1].urlFoto}`)" class="d-block w-100" />
                  </router-link>
                </div>
                <div class="carousel-item">
                  <router-link :to="`/gameDetail:${this.jogosCarousel[2].id}`">
                    <img :src="require(`../assets/${this.jogosCarousel[2].urlFoto}`)" class="d-block w-100" />
                  </router-link>
                </div>
                <div class="carousel-item">
                  <router-link :to="`/gameDetail:${this.jogosCarousel[3].id}`">
                    <img :src="require(`../assets/${this.jogosCarousel[3].urlFoto}`)" class="d-block w-100" />
                  </router-link>
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
    <div class="container mt-4" style="margin-bottom: 80px">
      <div class="row justify-content-center mb-3">
          <div v-for="jogo in jogos" :key="jogo.id" class="col-3 mb-3">
            <div class="card game-card" style="min-height: 306px;">
              <router-link :to="`/gameDetail:${jogo.id}`">
                <img :src="require(`../assets/${jogo.urlFoto}`)" class="card-img-top">
              </router-link>
              <div class="card-body">
                  <div class="row">
                    <p class="card-text"><strong>{{jogo.nome}}</strong></p>
                  </div>
                  <div class="row mb-4">
                    <p class="card-text">Classificação de Idade: {{jogo.classificacao}}</p>
                  </div>
                  <div class="d-flex flex-row-reverse">
                    <p class="card-text"><b>R$ {{jogo.valor.toFixed(2)}}</b></p>
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