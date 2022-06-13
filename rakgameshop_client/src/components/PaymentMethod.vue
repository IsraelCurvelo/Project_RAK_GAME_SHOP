<script>
import HeaderBar from "./shared/HeaderBarBag.vue";
import FooterBar from "./shared/FooterBar.vue";
import ModalBoleto from "./shared/modals/Boleto.vue";
import ModalPIX from "./shared/modals/PIX.vue";
import TheMask from 'vue-the-mask';

export default {
  components: {
    HeaderBar,
    FooterBar,
    ModalBoleto,
    ModalPIX,
    TheMask,
  },
  data(){
    return{
      usuario: {},
      cliente: {},
      pedido: {}
    }
  },
   created(){
    this.usuario = this.$root.usuario;
    if(this.usuario == null){
        return this.$router.push({ name: 'login' })
    }
    this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res => {
        this.cliente = res.body;
        this.buscarSacola();
    }, res => {
        console.log(res);
    });
  },
  methods: {
    showAlert() {
      this.$swal('Deseja confirmar a compra?');
    },
    buscarSacola(){
      this.$http.post('http://localhost:5000/api/cliente/buscarsacola', this.cliente).then(res => {

        console.log(res.body);

      }, res => {
        console.log(res);
      })
    }
  },
};

</script>


<template>

  <div>
    <the-mask/>
    <header>
      <HeaderBar />
    </header>

    <div class="container">
      <div class="py-5 text-center">
      </div>

      <div class="row g-5">

        <div class="col-md-12 col-lg-8 container clearfix">
          <h4 style="color: white">Finalizar compra</h4>

          
          <hr style="color: white">

          <div class="accordion radio mt-4" id="accordionExample">
            <div class="accordion-item" style="background-color: #414040;">
              <h2 class="accordion-header" id="headingTwo">
                <button class="accordion-button collapsed" type="radio" data-bs-toggle="collapse"
                  data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                  style="color: white; background-color: #414040;">
                  <svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor"
                    class="bi bi-credit-card" viewBox="0 0 16 16">
                    <path
                      d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4zm2-1a1 1 0 0 0-1 1v1h14V4a1 1 0 0 0-1-1H2zm13 4H1v5a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V7z">
                    </path>
                    <path d="M2 10a1 1 0 0 1 1-1h1a1 1 0 0 1 1 1v1a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1v-1z"></path>
                  </svg>
                  &nbsp; Cartão de crédito
                </button>
              </h2>
              <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne"
                data-bs-parent="#accordionExample">
                <div class="accordion-body">
                  <label for="address" class="form-label" style="color: white">Número do cartão</label>
                  <input type="text" class="form-control" id="address" placeholder="0000 0000 0000 00000" v-mask="'#### #### #### ####'" required="">
                  <div class="invalid-feedback">
                    Insira numero do cartão.
                  </div>

                  <div class="row mt-2">

                    <div class="col-8 mt-2">
                      <label for="address2" class="form-label" style="color: white">Titular do cartão</label>
                      <input type="text" class="form-control" id="address2"
                        placeholder="José da Silva, Maria de Oliveira ..">
                    </div>
                    <div class="col-4 mt-2">
                      <label for="address2" class="form-label" style="color: white">CPF do Titular</label>
                      <input type="text" class="form-control" id="address2" placeholder="000.000.000-00" v-mask="'###.###.###-##'">
                    </div>
                  </div>

                  <div class="row mt-2">

                    <div class="col-md-2">
                      <label for="country" class="form-label" style="color: white">Val.</label>
                      <input type="text" class="form-control" id="val_cartao" placeholder="00/00" v-mask="'##/##'">
                      <div class="invalid-feedback">
                        Digite uma data válida.
                      </div>
                    </div>

                    <div class="col-md-2">
                      <label for="state" class="form-label" style="color: white">CVV</label>
                      <input type="text" class="form-control" id="cvv_cartao" placeholder="XXX" maxlength="3" v-mask="'###'">
                      <div class="invalid-feedback">
                        Selecione um estado válido.
                      </div>
                    </div>

                  </div>
                </div>
              </div>
            </div>
            <div class="accordion-item" style="background-color: #414040;">
              <h2 class="accordion-header" id="headingTwo">
                <ModalBoleto />
              </h2>
            </div>
            <div class="accordion-item" style="background-color: #414040;">
              <h2 class="accordion-header" id="headingThree">
                <ModalPIX />
              </h2>
            </div>
          </div>
        </div>
        <div class="col-md-5 col-lg-4 order-md-last">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="" style="color: white">Carrinho</span>
          </h4>
          <hr style="color: white">
          <div class="row mt-2">
            <img src="../assets/among_us.jpg" style="width: 180px;" />
            <div class="card cart-card" style="width: 15rem; padding-left: 0%;">
              <div class="card-body">
                <div class="row mb-4">
                  <p class="card-text">Amoug Us</p>
                </div>
                <div class="d-flex flex-row-reverse">
                  <p class="card-text"><b>R$ 99,99</b></p>
                </div>
              </div>
            </div>
          </div>
          <div class="row mt-2">
            <img src="../assets/cyberpunk_2077.png" style="width: 180px;" />
            <div class="card cart-card" style="width: 15rem; padding-left: 0%;">
              <div class="card-body">
                <div class="row mb-4">
                  <p class="card-text">Cyberpunk</p>
                </div>
                <div class="d-flex flex-row-reverse">
                  <p class="card-text"><b>R$ 199,99</b></p>
                </div>
              </div>
            </div>
          </div>
          <div class="row mt-2">
            <img src="../assets/fifa_22.jpg" style="width: 180px;" />
            <div class="card cart-card" style="width: 15rem; padding-left: 0%;">
              <div class="card-body">
                <div class="row mb-4">
                  <p class="card-text">FIFA 2022</p>
                </div>
                <div class="d-flex flex-row-reverse">
                  <p class="card-text"><b>R$ 249,99</b></p>
                </div>
              </div>
            </div>
          </div>

          <div class="row" style="position: inherit;">
            <hr class="my-4" style="color:white">
            <div class="col" style="color: white">
              <h4>Total</h4>
            </div>
            <div class="col" style="color: white; text-align: end;">
              <strong>R$549,97</strong>
            </div>
            <div class="d-grid gap-2 mt-2">
              <button type="button" class="btn btn-primary"
                style="color:white; background-color: #340E80; border-color: #340E80; font-weight: bold;">
                FAZER PEDIDO
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>

    <footer>
      <FooterBar />
    </footer>
  </div>

</template>

<style>
.cart-card {
  background-color: #1c1b1b;
  color: #ffffff;
  border-radius: 0%;
}

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