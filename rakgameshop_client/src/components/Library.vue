<script>
import HeaderBar from "./shared/HeaderBarLib.vue";
import FooterBar from "./shared/FooterBar.vue";

export default {
  components: {
    HeaderBar,
    FooterBar,
  },
  data(){
    return{
      usuario: {},
      cliente: {},
      jogos: []
    }
  },
  created(){
    this.usuario = this.$root.usuario;
    if(this.usuario == null){
        return this.$router.push({ name: 'login' })
    }
    this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res => {
        this.cliente = res.body;
        this.buscarJogos();
    }, res => {
        console.log(res);
    });
  },
  methods: {
    buscarJogos(){
      this.$http.post('http://localhost:5000/api/cliente/buscarjogoscliente', this.cliente).then(res => {
        this.jogos = res.body;
        console.log(this.jogos)
      }, res => {
        console.log(res)
      })
    }
  }
};
</script>

<template>
  <div>
    <HeaderBar spanLinks="true" />
    <div class="container mt-4" style="margin-bottom: 60px">
      <div class="row justify-content-center" style="margin-top: 100px">
        <div v-for="jogo in jogos" :key="jogo.id" class="col-3">
          <div class="card game-card mb-3">
            <router-link :to="`/gameDetail:${jogo.id}`">
              <img :src="require(`../assets/${jogo.urlFoto}`)" class="card-img-top">
            </router-link>
            <div class="card-body">
              <div class="row mb-4">
                <p class="card-text">{{jogo.nome}}</p>
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