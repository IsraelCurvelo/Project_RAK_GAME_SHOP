<script>
    import Header from './shared/HeaderBarAdmList'

    export default {
        components:{
            Header
        },
        data(){
            return {
                id: this.$route.params.id.replace(":", ""),
                jogo: {},
                usuario: {},
                message: "",
                messageError: "",
            }    
        },
        mounted(){
            this.usuario = this.$root.usuario;
            if(this.usuario == null || !this.usuario.admin){
                return this.$router.push({ name: 'login' })
            }
            this.$http.get('http://localhost:5000/api/admin/buscarjogos').then(res =>{
                this.jogos = res.body;
                this.jogos.map(j => {   
                    if(j.id == this.id){
                        this.jogo = j;
                    }
                })
                this.jogo.dataLancamento = this.formatDate(this.jogo.dataLancamento);
                console.log(this.jogo);
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
                return [year, month, day].join('-');
            },
            gerarUrl(){
                let stringNova = document.getElementById('fotoUrl').value.replace('C:\\fakepath\\', "");
                return stringNova;
            },
            salvarJogo(){
                this.$http.put('http://localhost:5000/api/admin/alterarjogo', this.jogo).then(res => {
                    if(res.status == 200){
                        this.message = "Jogo Alterado!";
                    }else{
                        this.messageError = "Erro ao Cadastrar!";
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
        <Header />
        <div class="container mb-5">
            <div class="row pl-5 form-new">
                <h4>Cadastro de Produto</h4>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-7">
                    <form class="form-new">
                        <div class="row justify-content-center mt-3">
                            <div class="col-3">
                                <h5>Editar Jogo</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Nome do Jogo</label>
                                <input v-model="jogo.nome" type="text" id="Nome" class="form-control">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Descrição</label>
                                <input v-model="jogo.descricao" type="text" class="form-control" id="descricao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Valor</label>
                                <input v-model="jogo.valor" type="text" class="form-control" id="descricao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Categoria</label>
                                <input v-model="jogo.categoria" type="text" class="form-control" id="categoria">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Classificação</label>
                                <input v-model="jogo.classificacao" type="text" class="form-control" id="classificacao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 mb-3 mt-2">
                                <label class="form-label">Tamanho</label>
                                <input v-model="jogo.tamanho" type="text" class="form-control" id="tamanho">
                            </div>
                            <div class="col-6 mb-3 mt-2">
                                <label class="form-label">Data de Lançamento</label>
                                <input v-model="jogo.dataLancamento" type="date" class="form-control" id="dataLancamento">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Desenvolvedora</label>
                                <input v-model="jogo.desenvolvedora" type="text" class="form-control" id="desenvolvedora">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <button class="btn btn-md btt-submit" @click="salvarJogo()">Confirmar</button>
                            </div>
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
                    </form>
                </div>
            </div>
        </div>
    </div>  
</template>

<style>
    .form-new{
        color: white;
    }
    .btt-submit{
        color: #ffff;
        background-color: #340E80;
    }

    .btt-submit:hover{
        color: #ffff;
        background-color: #7e64b3;
    }

    #input-file{
        color: #ffff;
        background-color: #340E80;
    }

    #input-file:hover{
        color: #ffff;
        background-color: #7e64b3;
    }

    
</style>