<script>
    export default {
      name: "HeaderBar",
      data(){
        return{
          storeLink: 'color: white; background-color: #7e64b3; border-radius: 2px;',
          usuario: {}
        }
      },
      mounted() {
        this.usuario = this.$root.usuario;
      }
    };
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
        <ul class="navbar-nav me-auto mb-2 mb-lg-0" :show="{spanLinks}">
          <li class="nav-item">
              <router-link to="/">
                  <a class="nav-link navbar-links" aria-current="page" href="#">Loja</a>
              </router-link> 
          </li>
           <li class="nav-item">
            <a class="nav-link" aria-current="page" href="#">&nbsp;</a>
          </li>
          <li class="nav-item">
            <router-link to="/library">
                <a class="nav-link navbar-links" aria-current="page" :style="storeLink" href="#">Biblioteca</a>
            </router-link>
          </li>
        </ul>
        <form class="d-flex">
          <div class="row align-items-center">
           <div class="col">
              <img src="../../assets/bag_icon.svg" class="w-5">
            </div>
            <div class="col">
              <h5 style="color: white">{{usuario.email}}</h5>
            </div>
            <div class="col">
              <img src="../../assets/userLogo.svg" class="w-5">
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