<script>
    import HeaderBar from "./shared/HeaderBarBag.vue";
    import FooterBar from "./shared/FooterBar.vue";

    export default {
        components: {
            HeaderBar,
            FooterBar
        },
        data(){
            return{
                id: this.$route.params.id.replace(":", ""),
                jogo: {},
                jogos: [],
                usuario: {},
                cliente: {},
                message: "",
                messageError: "",
                messageButton: 'Adicionar jogo à sacola',
                disabledButton: false,
                spawnCompra: true,
                spawnDownload: false
            }
            
        },
        mounted(){
            this.atualizaPagina();
        },
        methods: {
            atualizaPagina(){
                this.usuario = this.$root.usuario;
                if(this.usuario == null){
                    return this.$router.push({ name: 'login' })
                }
                this.$http.get('http://localhost:5000/api/admin/buscarjogos').then(res =>{
                    this.jogos = res.body;
                    this.jogos.map(j => {   
                        if(j.id == this.id){
                            this.jogo = j;
                        }
                    })
                }, res => {
                    console.log(res);
                });
                this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res =>{
                    this.cliente = res.body;
                    this.validarJogo();
                }, res => {
                    console.log(res);
                });
            },
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
            pushPedido(){
                let j = []
                j.push(this.jogo);
                this.pedido = {
                    Cliente: this.cliente,
                    Jogos: j,
                    DataCompra: "",
                    FormaPagamento: null,
                    ValorTotal: 0,
                    Status: 0,
                    Parcelamento: 1
                };
                this.$http.post('http://localhost:5000/api/cliente/adicionar', this.pedido);
            },
            validarJogo(){
                let pedido = {
                    Cliente: this.cliente,
                    Jogo: this.jogo
                }
                this.$http.post('http://localhost:5000/api/cliente/verificarjogosacola', pedido).then(res => {
                    if(res.status == 201){
                        this.messageButton = 'Jogo já adicionado'
                        this.disabledButton = true;
                        this.spawnCompra = false;
                        this.spawnDownload = false; 
                    }
                    else if(res.status == 204){
                        this.messageButton = 'Jogo já adquirido'
                        this.disabledButton = true;
                        this.spawnCompra = false;
                        this.spawnDownload = true;
                    }
                    else if (res.status == 200){
                        this.messageButton = 'Adicionar jogo à sacola'
                        this.disabledButton = false;
                        this.spawnCompra = true;
                        this.spawnDownload = false;
                    }
                })
                
            },
            redirectCSacola(){
                 this.$router.push({ name: 'paymentMethod' })
            },
            adicionarJogoSacola(compra){
                let pedido = {
                    Cliente: this.cliente,
                    Jogo: this.jogo
                }
                this.$http.post('http://localhost:5000/api/cliente/adicionarjogosacola', pedido).then(res => {
                    if(res.status == 204){
                        this.messageError = "Jogo já adquirido";
                    }else if(res.status == 201){
                        this.messageError = "Jogo já adicionado"
                    }else if(res.status == 202){
                        this.messageError = "Erro ao adicionar"
                    }else{
                        this.message = "Jogo Adicionado!";
                        if(compra){
                            this.$router.push({ name: 'paymentMethod' })
                        }else{
                            this.$router.push({ name: 'store' })
                        }
                    }
                }, res => {
                    console.log(res);
                })
                
            }
        }
    }
    
</script>

<template>  
    <div>
        <HeaderBar />
        <div class="container-fluid detail-container" style="margin-top: 70px">
            <div class="container-fluid">
                <div class="row justify-content-center">
                    <div class="col mt-4" style="margin-left: 15px">
                        <img :src="require(`../assets/${jogo.urlFoto}`)" class="d-block w-100" />
                    </div>
                    <div class="col" style="text-align: center; margin-top: 100px; padding-right: 80px;">    
                        <h2>{{jogo.nome}}</h2>
                        <div style="text-align: center; margin-top: 200px;">
                            <h4>R$ {{jogo.valor.toFixed(2)}}</h4>
                        </div>
                        <div style="align-items: center;">
                            <div v-if="spawnCompra" class="d-grid gap-2 col-5 mx-auto mt-4">
                                <button class="btn btn-lg btt-submit" @click="adicionarJogoSacola(true)">Comprar Agora</button>
                            </div>
                            <div class="d-grid gap-2 col-5 mx-auto mt-4" >
                                <button class="btn btn-lg btt-outline-submit" @click="adicionarJogoSacola(false)" :disabled="disabledButton">{{this.messageButton}}</button>
                            </div>
                            <div v-if="messageButton == 'Jogo já adicionado'" class="d-grid gap-2 col-5 mx-auto mt-4">
                                <button class="btn btn-lg btt-submit" @click="redirectCSacola()">Ir para sacola</button>
                            </div>
                            <div v-if="spawnDownload" class="d-grid gap-2 col-5 mx-auto mt-4">
                                <a class="btn btn-lg btt-submit" type="button" :href="require(`../assets/${jogo.urlFoto}`)" download="">Download</a>
                            </div>
                             <div v-if="message" class="alert alert-success alert-dismissible fade show" role="alert">
                                {{ message }}
                                <button type="button" @click="message = null" data-dismiss="alert"
                                    aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div v-if="messageError" class="alert alert-danger alert-dismissible fade show"
                                role="alert">
                                {{ messageError }}
                                <button type="button" @click="messageError = null" data-dismiss="alert"
                                    aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-left">
                    <div class="col-3 mt-1" style="margin-left: 15px">
                        <p><b>{{jogo.descricao}}</b></p><br>
                    </div>
                    <div class="col-3 mt-1 mb-5" style="margin-left: 15px">
                        <p><b>Data de Lançamento: </b>{{formatDate(jogo.dataLancamento)}}</p><br>
                        <p><b>Categoria: </b>{{jogo.categoria}}</p>
                        <p><b>Calssificação: </b>{{jogo.classificacao}}</p>
                        <p><b>Tamanho: </b>{{jogo.tamanho}}</p>
                        <p><b>Desenvolvedora: </b>{{jogo.desenvolvedora}}</p>
                    </div>
                </div>
            </div>
        </div>
        <FooterBar />
    </div>
</template>


<style scoped>
    .detail-container{
        color: #ffff;
    }

    .btt-submit{
        color: #ffff;
        background-color: #340E80;
    }

    .btt-submit:hover{
        color: #ffff;
        background-color: #7e64b3;
    }

    .btt-outline-submit{
        color: #ffff;
        border: 1px solid #340E80;
    }

    .btt-outline-submit:hover{
        color: #ffff;
        border: 1px solid #340E80;
        background-color: #413f3f;
    }
</style>