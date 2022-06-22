<script>
    export default {
      name: "HeaderBarAdm",
      data(){
        return{
          usuario: {},
          storeLink: 'color: white; background-color: #7e64b3; border-radius: 2px;'
        }
      },
      mounted() {
        this.usuario = this.$root.usuario;
      },
      methods:{
        logOff(){
          this.$root.usuario = null;
          return this.$router.push({ name: 'login' })
        }
      }
    }
</script>

<template>
  <nav class="navbar fixed-top navbar-expand-lg navbar-main p-0">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">
        <img src="../../assets/logo.png" width="60px" height="auto">
      </a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse">
        <ul class="navbar-nav me-auto mb-3 mb-lg-0">
          <li class="nav-item" :style="storeLink" href="#">
            <router-link to="/jogos">
              <a class="nav-link navbar-links" aria-current="page" href="#">Jogos</a>
            </router-link> 
          </li>
           <li class="nav-item" href="#">&nbsp;</li>
          <li class="nav-item" href="#">
            <router-link to="/newProduct">
              <a class="nav-link navbar-links" aria-current="page" href="#">Novo Jogo</a>
            </router-link> 
          </li>
        </ul>
        <form class="d-flex">
          <div class="row align-items-center">
           <div class="col">
            </div>
            <div class="col">
              <h5 style="color: white">{{usuario.email}}</h5>
            </div>
            <div class="col" style="cursor: pointer">
              <div class="btn-group dropstart">
                <img src="../../assets/userLogo.svg" class="w-5" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                  <li>
                    <router-link to="/dadosAdm">
                      <a class="dropdown-item">Meus Dados</a>
                    </router-link>
                  </li>
                  <li>
                    <router-link to="/login">
                      <a class="dropdown-item" @click="logOff()">Sair</a>
                    </router-link>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </nav>
</template>

<style>
  .navbar-main{
    background-color: #340E80;
  }

  .navbar-links{
    color: white;
  }

  .navbar-links:hover{
    color: white;
    background-color: #7e64b3;
    border-radius: 2px;
  }

  .nav.navbar-links:active{
    color: white;
    background-color: #7e64b3;
    border-radius: 2px;
  }
</style>