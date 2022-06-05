<script>
    import Header from './shared/HeaderBarAdm'

    export default {
        components:{
            Header
        },
        data(){
            return {
                jogo: {
                    nome: '',
                    stringFoto: '',
                    descricao: '',
                    categoria: '',
                    classificacao: '',
                    tamanho: '',
                    dataLancamento: '',
                    desenvolvedora: ''

                },
            }    
        },

        methods: {
            gerarUrl(){
                console.log("Ue")
                console.log(document.getElementById('fotoUrl').value)
                let stringNova = document.getElementById('fotoUrl').value.replace('C:\\fakepath\\', "   ");
                console.log(stringNova)
            },
            salvarJogo(){
                this.$http.post('https://localhost:44364/adim/cadastrarjogo', this.jogo).then(res => res.json()).then(res => {
                    console.log(res);
                }, res => {
                    console.log(res);
                })
            }
        }
    }
</script>


<template>
    <div>
        <Header spanLinks="true" />
        <div class="container mt-5">
            <form class="form-new">
                <p style="font-size: 20px">Criar Conta</p>
            </form>
        </div>
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
                                <h5>Dados do Produto</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Nome do Jogo</label>
                                <input type="text" id="nome" class="form-control" aria-describedby="emailHelp">
                            </div>
                            <div class="col-4 mb-3 mt-2">
                                <div>
                                    <label class="form-label" for="exampleFormControlFile1">Foto do Produto</label><br>
                                    <input id="fotoUrl" type="file" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Descrição</label>
                                <input type="text" class="form-control" id="descricao" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Categoria</label>
                                <input type="text" class="form-control" id="categoria" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Classificação</label>
                                <input type="text" class="form-control" id="classificacao" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Tamanho</label>
                                <input type="text" class="form-control" id="tamanho" aria-describedby="emailHelp">
                            </div>
                            <div class="col-6 mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Data de Lançamento</label>
                                <input type="text" class="form-control" id="dataLancamento" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Desenvolvedora</label>
                                <input type="password" class="form-control" id="desenvolvedora" aria-describedby="emailHelp">
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