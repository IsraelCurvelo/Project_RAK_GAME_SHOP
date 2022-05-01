<script>
    export default {
      name: "HeaderBar"
    };
</script>

<template>
  <nav class="navbar navbar-expand-lg navbar-main">
    <div class="container-fluid" style="margin-top: 15px">
      <a class="navbar-brand" href="#" style="position: absolute;">
        <img src="../../assets/logo2.svg" class="w-80">
      </a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        </ul>
        <form class="d-flex">
          <div class="row align-items-center">
            <div class="col">
              <h5 style="color: white">nome_usuario</h5>
            </div>
            <div class="col">
              <img src="../../assets/userLogo.svg" class="w-55">
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
</style>