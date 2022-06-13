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
                message: 'Adicionar jogo à sacola',
                disabledButton: false,
                spawnCompra: true
            }
            
        },
        created(){
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
        methods: {
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
                        this.message = 'Jogo já adicionado'
                        this.disabledButton = true;
                        this.spawnCompra = false; 
                    }
                    else if(res.status == 204){
                        this.message = 'Jogo já adquirido'
                        this.disabledButton = true;
                        this.spawnCompra = false;
                    }
                    else if (res.status == 200){
                        this.message = 'Adicionar jogo à sacola'
                        this.disabledButton = false;
                        this.spawnCompra = true;
                    }
                })
                
            },
            adicionarJogoSacola(){
                let pedido = {
                    Cliente: this.cliente,
                    Jogo: this.jogo
                }
                this.$http.post('http://localhost:5000/api/cliente/adicionarjogosacola', pedido).then(res => {
                    if(res.staus == 204){
                        window.alert("Jogo já adquirido");
                    }
                    else if(res.staus == 201){
                        window.alert("Jogo já adicionado");
                    }
                    else if(res.staus == 202){
                        window.alert("Erro ao adicionar");
                    }
                    else{
                        window.alert("Jogo Adicionado!");
                        this.$router.push({ name: 'store' })
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
                        <div style="text-align: end; padding-right: 150px; margin-top: 200px;">
                            <h4>R$ {{jogo.valor}}</h4>
                        </div>
                        <div style="align-items: center;">
                            <div v-if="spawnCompra" class="d-grid gap-2 col-5 mx-auto mt-4">
                                <button class="btn btn-lg btt-submit">Comprar Agora</button>
                            </div>
                            <div class="d-grid gap-2 col-5 mx-auto mt-4" >
                                <button class="btn btn-lg btt-outline-submit" @click="adicionarJogoSacola()" :disabled="disabledButton">{{this.message}}</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col mt-3" style="margin-left: 15px">
                        <h4>Descrição</h4>
                        <div>
                            <p>{{jogo.descricao}}</p>
                        </div>
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