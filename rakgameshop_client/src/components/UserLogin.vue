<script>
    export default {};
</script>

<template>
    <div class="container">
        <div class="row justify-content-center align-items-center vh-100">
            <div class="col-6">
                <img src="../assets/logo1.svg" class="w-100" />
            </div>
            <div class="col-3">
                <div class="card p-2 pt-3 pb-0 loginCard">
                    <div class="card-body">
                        <div class="row mb-3">
                            <input type="email" class="form-control" id="emailImput" placeholder="E-mail">
                        </div>
                        <div class="row mb-4">
                            <input type="password" class="form-control" id="passwordImput" placeholder="Senha">
                        </div>
                        <div class="row d-grid gap-2">
                            <button class="btn loginButton" type="button">Entrar</button>
                        </div>
                        <div class="row">
                            <p style="color: white;">Nao tem uma conta? <b><a href="#" style="color: white">Cadastre-se</a></b></p>
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