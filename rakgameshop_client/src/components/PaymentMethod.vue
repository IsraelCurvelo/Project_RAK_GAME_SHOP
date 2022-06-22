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
  data() {
    return {
      usuario: {},
      cliente: {},
      pedido: {
        valorTotal: 0,
        formaPagamento: {}
      },
      formaPagamento:{
        tipoPagamento: 0,
        codigo: '2648.5465.4789.8516.5465.4789.8516',
      },
      cartao:{
        numeroCartao: '',
        titularCartao: '',
        cpf: '',
        validade: '',
        cvv: '',
        status: 1,
        parcelas: 1,
        bandeira: 1
      },
      flagCartao: false,
      flagBoleto: false,
      flagPix: false,
      flagCompra: false,
      message: "",
      messageError: ""
    }
  },
  mounted() {
    this.atualizaPagina();
  },
  methods: {
    atualizaPagina(){
      this.usuario = this.$root.usuario;
      if (this.usuario == null) {
        return this.$router.push({ name: 'login' })
      }
      this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res => {
        this.cliente = res.body;
        this.buscarSacola();
      }, res => {
        console.log(res);
      });
    },
    showAlert() {
      this.$swal('Deseja confirmar a compra?');
    },
    buscarSacola() {
      this.$http.post('http://localhost:5000/api/cliente/buscarsacola', this.cliente).then(res => {
        this.pedido = res.body

      }, res => {
        console.log(res);
      })
    },
    removerTodos() {
      this.pedido.jogos.forEach(jogo => {
        this.removerJogo(jogo, false)
      })
      this.message = "Removidos!";
    },
    removerJogo(jogo, messagem) {
      const jogoNaSacola = {
        JogoId: jogo.id,
        ClienteId: this.cliente.id
      };
      this.$http.delete('http://localhost:5000/api/cliente/removersacola', { body: jogoNaSacola }).then(res => {
        if (res.status == 202) {
         this.messageError = "Erro ao excluir";
        } else {
          if (messagem) {
            this.message = "Removido!";
          }
          let i = this.pedido.jogos.indexOf(jogo);
          this.pedido.jogos.splice(i, 1);
          this.pedido.valorTotal -= jogo.valor;
        }
      })
    },
    getValorTotal(){
      if(this.pedido.valorTotal == 0){
        this.pedido.jogos.forEach(jogo => {
          this.pedido.valorTotal += jogo.valor;
        });
      }
      return this.pedido.valorTotal.toFixed(2);
    },
    pagamentoCartao(){
      this.formaPagamento.tipoPagamento = 1;
      this.formaPagamento.cartao = this.cartao
      this.formaPagamento.codigo = '';
      this.pedido.formaPagamento = this.formaPagamento;
    },
    pagamentoBoleto(){
      this.formaPagamento.tipoPagamento = 2;
      this.formaPagamento.codigo = '2648.5465.4789.8516.5465.4789.8516';
      this.pedido.formaPagamento = this.formaPagamento;
    },
    pagamentoPix(){
      this.formaPagamento.tipoPagamento = 3;
      this.formaPagamento.codigo = '2648.5465.4789.8516.5465.4789.8516';
      this.pedido.formaPagamento = this.formaPagamento;
    },
    setFlagCartao(){
      this.flagCompra = true;
      this.flagCartao = true;
      this.flagBoleto = false;
      this.flagPix = false;
    },
    setFlagBoleto(){
      this.flagCompra = true;
      this.flagCartao = false;
      this.flagBoleto = true;
      this.flagPix = false;
    },
    setFlagPix(){
      this.flagCompra = true;
      this.flagCartao = false;
      this.flagBoleto = false;
      this.flagPix = true;
    },
    formatParcela(parcela){
      let parcelaFormat = this.pedido.valorTotal / parcela;
      return parcelaFormat.toFixed(2);
    },
    finalizarPedido(){
      if(this.flagCartao){
        this.pagamentoCartao();
      }
      if(this.flagBoleto){
        this.pagamentoBoleto();
      }
      if(this.flagPix){
        this.pagamentoPix();
      }
      this.pedido.cliente = this.cliente;
      this.$http.post('http://localhost:5000/api/cliente/finalizarpedido', this.pedido).then(res => {
        if(res.status == 204){
          this.messageError = "Erro ao finalizar pedido";
        }else{
          this.message = "Pedido finalizado!";
          this.$router.push({ name: 'library' })
        }
      })
    }
  },
};

</script>


<template>

  <div>
    <header>
      <HeaderBar />
    </header>

    <div class="container">
      <div class="py-5 text-center">
      </div>

      <div v-if="pedido.jogos" class="row g-7">

        <div class="col-md-12 col-lg-8 container clearfix">
          <h4 style="color: white">Finalizar Compra</h4>
          <hr style="color: white">
          <div v-if="pedido.jogos.length != 0" class="accordion radio mt-4" id="accordionExample">
            <div class="accordion-item" style="background-color: #414040;">
              <h2 class="accordion-header" id="headingTwo">
                <button @click="setFlagCartao()" class="accordion-button collapsed" type="radio" data-bs-toggle="collapse"
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
                  <div class="row mt-2">
                    <div class="col-md-8">
                      <the-mask/>
                      <label for="address" class="form-label" style="color: white">Número do cartão</label>
                      <input v-model="cartao.numeroCartao" type="text" class="form-control" id="address" placeholder="0000 0000 0000 00000" v-mask="'#### #### #### ####'" required="">
                      <div class="invalid-feedback">
                        Insira numero do cartão.
                      </div>
                    </div>
                    <div class="col-md-4">
                      <label for="state" class="form-label" style="color: white">Bandeira</label>
                      <select v-model="cartao.bandeira" class="form-select" aria-label="Default select example">
                        <option selected value="0">MasterCard</option>
                        <option value="1">Visa</option>
                        <option value="2">Elo</option>
                        <option value="3">Maestro</option>
                        <option value="4">Hipercard</option>
                        <option value="5">AmricanEX</option>
                      </select>
                      <div class="invalid-feedback">
                        Selecione um estado válido.
                      </div>
                    </div>
                  </div>

                  <div class="row mt-2">

                    <div class="col-8 mt-2">
                      <label for="address2" class="form-label" style="color: white">Titular do cartão</label>
                      <input v-model="cartao.titularCartao" type="text" class="form-control" id="address2"
                        placeholder="José da Silva, Maria de Oliveira ..">
                    </div>
                    <div class="col-4 mt-2">
                      <label for="address2" class="form-label" style="color: white">CPF do Titular</label>
                      <input v-model="cartao.cpf" type="text" class="form-control" id="address2" placeholder="000.000.000-00" v-mask="'###.###.###-##'">
                    </div>
                  </div>

                  <div class="row mt-2">

                    <div class="col-md-2">
                      <label for="country" class="form-label" style="color: white">Val.</label>
                      <input v-model="cartao.validade" type="text" class="form-control" id="val_cartao" placeholder="00/00" v-mask="'##/##'">
                      <div class="invalid-feedback">
                        Digite uma data válida.
                      </div>
                    </div>

                    <div class="col-md-2">
                      <label for="state" class="form-label" style="color: white">CVV</label>
                      <input v-model="cartao.cvv" type="text" class="form-control" id="cvv_cartao" placeholder="XXX" maxlength="3" v-mask="'###'">
                      <div class="invalid-feedback">
                        Selecione um estado válido.
                      </div>
                    </div>
                    <div class="col-md-3">
                      <label for="state" class="form-label" style="color: white">Parcelas</label>
                      <select v-model="cartao.parcelas" class="form-select" aria-label="Default select example">
                        <option selected value="1">1X ({{formatParcela(1)}})</option>
                        <option value="2">2X ({{formatParcela(2)}})</option>
                        <option value="3">3X ({{formatParcela(3)}})</option>
                        <option value="4">4X ({{formatParcela(4)}})</option>
                        <option value="5">5X ({{formatParcela(5)}})</option>
                        <option value="6">6X ({{formatParcela(6)}})</option>
                      </select>
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
            <span class="" style="color: white">Sacola</span>
            <button v-if="pedido.jogos.length != 0" class="btn btn-sm btn-outline-danger" @click="removerTodos()">Limpar
              Sacola</button>
          </h4>
          <hr style="color: white">

          <div v-for="jogo in pedido.jogos" :key="jogo.id" class="row mt-2">
            <img :src="require(`../assets/${jogo.urlFoto}`)" style="width: 180px;" />
            <div class="card cart-card" style="width: 15rem; padding-left: 0%;">
              <div class="card-body">
                <div class="row mb-4">
                  <p class="card-text">{{ jogo.nome }}</p>
                </div>
                <div class="row">
                  <div class="col-10">
                    <p class="card-text"><b>R$ {{ jogo.valor.toFixed(2) }}</b></p>
                  </div>
                  <div class="col-2 align-self-end">
                    <button class="btn btn-sm btn-outline-danger" @click="removerJogo(jogo, true)">x</button>
                  </div>
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
              <strong>R${{ getValorTotal() }}</strong>
            </div>
            <div class="d-grid gap-2 mt-2">
              <button :disabled="pedido.jogos.length == 0 || !flagCompra" @click="finalizarPedido()" type="button" class="btn btn-primary"
                style="color:white; background-color: #340E80; border-color: #340E80; font-weight: bold;">
                FAZER PEDIDO
              </button>
            </div>
          </div>
          <div v-if="message" class="alert alert-primary alert-dismissible fade show mt-3" role="alert">
              {{ message }}
              <button type="button" @click="message = ''" data-dismiss="alert"
                  aria-label="Close">
                  <span aria-hidden="true">&times;</span>
              </button>
          </div>
          <div v-if="messageError > 0" class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
            {{ messageError }}
            <button type="button" @click="messageError = ''" data-dismiss="alert"
                aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
          </div>
        </div>
      </div>
      <div v-else class="row g-5">
        <div class="col-md-12 col-lg-8 container clearfix">
          <h4 style="color: white">Nenhum jogo na sacola</h4>
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