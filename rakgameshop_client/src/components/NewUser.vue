<script>
    import Header from './shared/HeaderBar'

    export default {
        components:{
            Header
        }
    }
</script>


<template>
    <div>
        <Header />
        <div class="container mt-5">
            <form class="form-new">
                <p style="font-size: 20px">Criar Conta</p>
            </form>
        </div>
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-7">
                    <form class="form-new">
                        <div class="row justify-content-center mt-3">
                            <div class="col-3">
                                <h5>Dados Cadastrais</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Nome Completo</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Apelido</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">E-Mail</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Data de Nascimento</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">CPF</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label for="exampleInputEmail1" class="form-label">Telefone</label>
                                <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <button class="btn btn-md btt-submit">Enviar</button>
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
</style>