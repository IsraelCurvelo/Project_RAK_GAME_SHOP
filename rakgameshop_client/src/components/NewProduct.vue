<script>
    import Header from './shared/HeaderBarAdm'

    export default {
        components:{
            Header
        },
        data(){
            return {
                jogo: {
                    Nome: "",
                    Descricao: "",
                    Categoria: "",
                    Classificacao: "",
                    Tamanho: "",
                    DataLancamento: "",
                    DataCadastro: "2022-06-05",
                    Desenvolvedora: "",
                    URLFoto: "",
                    Status: 1
                },
                usuario: {}
            }    
        },
        mounted(){
            this.usuario = this.$root.usuario;
            if(this.usuario == null){
                return this.$router.push({ name: 'login' })
            }
        },
        methods: {
            gerarUrl(){
                let stringNova = document.getElementById('fotoUrl').value.replace('C:\\fakepath\\', "");
                return stringNova;
            },
            salvarJogo(){
                this.DataCadastro = new Date();
                this.jogo.URLFoto = this.gerarUrl()
                console.log(this.jogo);
                this.$http.post('https://localhost:44364/api/admin/cadastrarjogo', this.jogo).then(res => {
                    if(res.status == 200){
                        window.alert("Jogo Cadastrado!");
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
                                <h5>Cadastro de Jogo</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mb-3 mt-2">
                                <label class="form-label">Nome do Jogo</label>
                                <input v-model="jogo.Nome" type="text" id="Nome" class="form-control">
                            </div>
                            <div class="col-4 mb-3 mt-2">
                                <div>
                                    <label class="form-label">Foto do Produto</label><br>
                                    <input id="fotoUrl" type="file" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Descrição</label>
                                <input v-model="jogo.Descricao" type="text" class="form-control" id="descricao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Valor</label>
                                <input v-model="jogo.Valor" type="text" class="form-control" id="descricao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label class="form-label">Categoria</label>
                                <input v-model="jogo.Categoria" type="text" class="form-control" id="categoria">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Classificação</label>
                                <input v-model="jogo.Classificacao" type="text" class="form-control" id="classificacao">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 mb-3 mt-2">
                                <label class="form-label">Tamanho</label>
                                <input v-model="jogo.Tamanho" type="text" class="form-control" id="tamanho">
                            </div>
                            <div class="col-6 mb-3 mt-2">
                                <label class="form-label">Data de Lançamento</label>
                                <input v-model="jogo.DataLancamento" type="date" class="form-control" id="dataLancamento">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Desenvolvedora</label>
                                <input v-model="jogo.Desenvolvedora" type="text" class="form-control" id="desenvolvedora">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <button class="btn btn-md btt-submit" @click="salvarJogo()">Cadastrar</button>
                            </div>
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