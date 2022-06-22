<script>
import Header from './shared/HeaderBarAdmDetail';
import TheMask from 'vue-the-mask';

export default {
    components: {
        Header,
        TheMask,
    },
    data() {
        return {
            usuario: {},
            cliente: {},
            message: null,
            messageError: null,
            alterarSenha: false,
            senhaAtual: '',
            senha: '',
            confirmaSenha: '',
            apelido: ''
        }
    },
    created(){
        this.usuario = this.$root.usuario;
        if(this.usuario == null){
            return this.$router.push({ name: 'login' })
        }
        this.$http.post('http://localhost:5000/api/cliente/buscarcliente', this.usuario).then(res => {
            this.cliente = res.body;
            this.cliente.dataNascimento = this.formatDate(this.cliente.dataNascimento);
            this.apelido = this.cliente.apelido;
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
        validarSenha(){
            console.log(this.senhaAtual)
            if(this.senhaAtual != this.usuario.senha){
                this.messageError = "Senha Atual Incorreta!";
            }else{
                if(this.senha != this.confirmaSenha){
                    this.messageError = "Senhas Diferentes!";
                }else{
                    this.usuario.senha = this.senha;
                    this.salvarCliente();
                }
            }
        },
        salvarCliente() {
            this.usuario.dataCadastro = this.formatDate(this.usuario.dataCadastro);
            this.cliente.usuario = this.usuario;
            this.$http.post('http://localhost:5000/api/cliente/AlterarCliente', this.cliente).then(res => {
                if (res.status == 200) {
                    this.messageError = null;
                    this.message = "Alteração concluída!";
                     return this.$router.push({ name: 'dadosCliente' })
                } else {
                    this.messageError = "Erro ao Alterar!";
                }
            }, res => {
                console.log(res);
            });
        }
    }
}
</script>


<template>
    <div>
        <Header spanLinks="true" />
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-7">
                    <form class="form-new">
                        <div class="row justify-content-center mt-3">
                            <div class="container mt-5">
                                <form class="form-new">
                                    <p style="font-size: 20px; margin-top: 20px">{{apelido}}</p>
                                </form>
                            </div>
                            <div class="col-3">
                                <h5>Alterar Dados</h5>
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
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Nome Completo</label>
                                <input v-model="cliente.nome" type="text" class="form-control" id="formNome">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Apelido</label>
                                <input v-model="cliente.apelido" type="text" class="form-control" id="formApelido">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">E-Mail</label>
                                <input v-model="usuario.email" type="text" class="form-control" id="formEmail">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Data de Nascimento</label>
                                <input v-model="cliente.dataNascimento" type="date" class="form-control"
                                    id="formDataNascimento">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">CPF</label>
                                <the-mask />
                                <input v-model="cliente.cpf" type="text" class="form-control" id="formCpf"
                                    v-mask="'###.###.###-##'">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Telefone</label>
                                <input v-model="cliente.telefone" type="text" class="form-control" id="formTelefone"
                                    v-mask="['(##) ####-####', '(##) #####-####']">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-4">
                                <label @click="alterarSenha = !alterarSenha" style="cursor: pointer" class="form-label"><u>Alterar Senha</u></label>
                            </div>
                        </div>
                         <div v-if="alterarSenha" class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Senha Atual</label>
                                <input v-model="senhaAtual" type="password" class="form-control" id="formSenhaAtual">
                            </div>
                        </div>
                        <div v-if="alterarSenha" class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Nova Senha</label>
                                <input v-model="senha" type="password" class="form-control" id="formSenha">
                            </div>
                        </div>
                        <div v-if="alterarSenha" class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Confirmar Senha</label>
                                <input v-model="confirmaSenha" type="password" class="form-control" id="formSenhaConfirm">
                            </div>
                        </div>
                        <div v-if="alterarSenha" class="row">
                            <div class="mb-3 mt-2">
                                <button class="btn btn-md btt-outline" @click="validarSenha()">Alterar</button>
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
                        <hr>
                        <div class="row justify-content-end">
                            <div class="mb-3 mt-4">
                                <button class="btn btn-md btt-enviar" @click="salvarCliente()">Enviar</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
.form-new {
    color: white;
}

.btt-enviar {
    color: #ffff;
    background-color: #340E80;
}

.btt-enviar:hover {
    color: #ffff;
    background-color: #7e64b3;
}

.btt-outline{
    color: #ffff;
    border: 1px solid #340E80;
}

.btt-outline:hover{
    color: #ffff;
    border: 1px solid #340E80;
    background-color: #413f3f;
}
</style>