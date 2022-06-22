<script>
    export default {
        data(){
            return{
                usuario:{
                    Email: "",
                    Senha: ""
                },
                message: ""
            }
        },
        methods: {
            efetuarLogin(){
                this.$http.post("http://localhost:5000/api/cliente/login", this.usuario).then(res => {
                    if(res.status == 200){
                        this.$root.setUsuario(res.body);
                        if(res.body.admin){
                            return this.$router.push({ name: 'listJogos' });
                        }
                    return this.$router.push({ name: 'store' });
                    }else{
                        this.message = "Email ou Senha inválidos"
                    }
                }, res => {
                    console.log(res);
                })
            }
        }
    };
</script>

<template>
    <div class="container">
        <div class="row justify-content-center align-items-center vh-100">
            <div class="col-6">
                <img src="../assets/logo1.svg" class="w-100" />
            </div>
            <div class="col-3">
                <div class="col-11" v-if="message">
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        {{message}}
                        <button type="button" @click="message=null" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
                <div class="card p-2 pt-3 pb-0 loginCard">
                    <div class="card-body">
                        <div class="row mb-3">
                            <input v-model="usuario.Email" type="email" class="form-control" id="emailImput" placeholder="E-mail">
                        </div>
                        <div class="row mb-4">
                            <input v-model="usuario.Senha" type="password" class="form-control" id="passwordImput" placeholder="Senha">
                        </div>
                        <div class="row d-grid gap-2">
                            <button class="btn loginButton" @click="efetuarLogin()" type="button">Entrar</button>
                        </div>
                        <div class="row">
                            <p style="color: white;">Nao tem uma conta?
                                <router-link to="/signin">
                                    <b><a href="#" style="color: white">Cadastre-se</a></b>
                                </router-link>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .loginCard{
        background-color: #1C1B1B;
        border: 1px solid #FFFFFF;
    }
    
    .loginButton{
        color: #ffff;
        background-color: #340E80;
    }

    .loginButton:hover{
        color: #ffff;
        background-color: #7e64b3;
    }

    .newUser{
        color: white;
        font-size: 30px;
    }
</style>