<script>
import Header from './shared/HeaderBarAdm';
import TheMask from 'vue-the-mask';

export default {
    components: {
        Header,
        TheMask,
    },
    data() {
        return {
            usuario: {
                Email: "",
                Senha: "",
                DataCadastro: "",
                Admin: false,
            },
            cliente: {
                Nome: "",
                Apelido: "",
                DataNascimento: "",
                CPF: "",
                Telefone: "",
                Status: 1,
                Usuario: {}
            },
            message: null,
            messageError: null
        }
    },
    methods: {
        formatDate() {
            let d = new Date();
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
        salvarCliente() {
            this.usuario.DataCadastro = this.formatDate();
            this.cliente.Usuario = this.usuario;
            console.log(this.cliente);
            this.$http.post('http://localhost:5000/api/cliente/cadastrarcliente', this.cliente).then(res => {
                if (res.status == 200) {
                    this.messageError = null;
                    this.message = "Cadastro concluído!";
                } else {
                    this.messageError = "Revise os dados!";
                }
            }, res => {
                console.log(res);
            });
        },
        redirect() {
            this.message = null;
            return this.$router.push({ name: 'login' });
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
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-7">
                    <form class="form-new">
                        <div class="row justify-content-center mt-3">
                            <div class="col-3">
                                <h5>Dados Cadastrais</h5>
                            </div>
                            <div v-if="message" class="alert alert-success alert-dismissible fade show" role="alert">
                                {{ message }}
                                <button type="button" @click="redirect()" data-dismiss="alert" aria-label="Close">
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
                                <input v-model="cliente.Nome" type="text" class="form-control" id="formNome">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Apelido</label>
                                <input v-model="cliente.Apelido" type="text" class="form-control" id="formApelido">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">E-Mail</label>
                                <input v-model="usuario.Email" type="text" class="form-control" id="formEmail">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Data de Nascimento</label>
                                <input v-model="cliente.DataNascimento" type="date" class="form-control"
                                    id="formDataNascimento">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">CPF</label>
                                <the-mask />
                                <input v-model="cliente.CPF" type="text" class="form-control" id="formCpf"
                                    v-mask="'###.###.###-##'">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Telefone</label>
                                <input v-model="cliente.Telefone" type="text" class="form-control" id="formTelefone"
                                    v-mask="['(##) ####-####', '(##) #####-####']">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
                                <label class="form-label">Senha</label>
                                <input v-model="usuario.Senha" type="password" class="form-control" id="formSenha">
                            </div>
                        </div>
                        <div class="row">
                            <div class="mb-3 mt-2">
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
</style>