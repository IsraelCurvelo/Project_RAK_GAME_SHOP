<script>

    import Header from './shared/HeaderBarDetail.vue'

    export default {
        components:{
            Header
        },
        data(){
            return{
                usuario: {},
                pedidos: [],
                cliente: {}
            }
        },
        mounted() {
            this.usuario = this.$root.usuario;
            if(this.usuario == null){
                return this.$router.push({ name: 'login' })
            }
            this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res => {
                this.cliente = res.body;
                this.buscarPedidos();
            }, res => {
                console.log(res);
            });
        },
        methods: {
             formatDate(date) {
                let d = new Date(date);
                let month = (d.getMonth() + 1).toString();
                let day = d.getDate().toString();
                let year = d.getFullYear();
                if (month.length < 2) {
                    month = '0' + month;
                }
                if (day.length < 2) {
                    day = '0' + day;
                }
                return [day, month, year].join('/');
            },
            buscarPedidos(){
                this.$http.post('http://localhost:5000/api/cliente/historicopedidocliente', this.cliente).then(res => {
                if(res.status == 200){
                    this.pedidos = res.body;
                }
                }, res => {
                    console.log(res)
                });
            },
            getFormaPagamento(formaPagamento){
                let cartao = "";
                if(formaPagamento.cartao != null){
                    let formatCartao = formaPagamento.cartao.numeroCartao.split('');
                    let bandeira = 'padrao';
                    console.log(bandeira);
                    switch(formaPagamento.cartao.bandeira){
                        case 0:
                            bandeira = "MasterCard"
                            break;
                        case 1:
                            bandeira = "Visa"
                            break;
                        case 2:
                            bandeira = "Elo"
                            break;
                        case 3:
                            bandeira = "Maestro"
                            break;
                        case 4:
                            bandeira = "Hipercard"
                            break;
                        case 5:
                            bandeira = "AmericanEX"
                            break;
                        default:
                            break;
                    }
                    console.log(bandeira);
                    cartao = "Cartão: " + bandeira + " " + formatCartao[15] + formatCartao[16] + formatCartao[17] + formatCartao[18];
                }
                switch(formaPagamento.tipoPagamento){
                    case 0:
                        return "Indefinido";
                    case 1:
                        return cartao.toString();
                    case 2:
                        return "Boleto";
                    case 3:
                        return "Pix";
                    default:
                        return "";
                }      
            }
        }
    }
</script>

<template>
    <div>
        <Header />
        <div class="container-fluid" style="margin-top: 80px; color: white">
            <div class="row justify-content-center">
                <div class="col-7">
                    <div class="row justify-content-center mt-3">
                        <h4>Histórico de Compras</h4>
                        <hr>
                        <div v-for="pedido in pedidos" :key="pedido.id" style="background-color: #414040;" class="pt-2 mb-3">
                            <div class="row justify-content-between">
                                <div class="col-4">
                                    <h5><b>Pedido {{pedido.id}}</b></h5>
                                </div>
                                <div class="col-4">
                                    <p>{{formatDate(pedido.dataCompra)}}</p>
                                </div> 
                            </div>
                            <div v-for="jogo in pedido.jogos" :key="jogo.id" class="row justify-content-between">
                                <div class="col-4">
                                    <p>{{jogo.nome}}</p>
                                </div>
                                <div class="col-4">
                                    <p>{{jogo.valor.toFixed(2)}}</p>
                                </div> 
                            </div>
                            <hr>
                            <div class="row justify-content-between">
                                <div class="col-4">
                                    <p>{{getFormaPagamento(pedido.formaPagamento)}}</p>
                                </div>
                                <div class="col-4">
                                    <p>{{pedido.valorTotal.toFixed(2)}}</p>
                                </div> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
    
</style>