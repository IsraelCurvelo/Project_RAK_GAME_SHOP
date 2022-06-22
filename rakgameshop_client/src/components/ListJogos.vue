<script>
    import Header from './shared/HeaderBarAdmList'

    export default {
        components: {
            Header
        },
        data(){
            return{
                jogos: []
            }
        },
        mounted(){
            this.usuario = this.$root.usuario;
            if(this.usuario == null || !this.usuario.admin){
                return this.$router.push({ name: 'login' })
            }
            this.$http.get('http://localhost:5000/api/admin/buscarjogos').then(res => {
                this.jogos = res.body;
            }, res => {
                console.log(res)
            });
        },
        methods: {
            removerJogo(jogo){
                console.log(jogo);
                this.$http.delete('http://localhost:5000/api/admin/excluirjogo', {body: jogo}).then(res => {
                    if(res.status == 200){
                        this.jogos.map(j => {
                            if(j.id == jogo.id){
                                let index = this.jogos.indexOf(jogo);
                                this.jogos.splice(index, 1);
                            }
                        })
                    }
                })
            }
        }
    }
</script>

<template>
    <div>
        <Header />
          <div class="container-fluid" style="margin-top: 80px">
            <div class="row justify-content-center">
                <div class="col-7">
                    <form class="form-new">
                        <div class="row justify-content-center mt-3">
                            <table class="table table-borderless table-jogos">
                                <thead>
                                    <tr>
                                        <th scope="col"></th>
                                        <th scope="col">Nome</th>
                                        <th scope="col">Categoria</th>
                                        <th scope="col">Valor</th>
                                        <th scope="col">Desenvolvedora</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="jogo in jogos" :key="jogo.id">
                                        <td><img :src="require(`../assets/${jogo.urlFoto}`)" width="70px" height="auto"/></td>
                                        <td>{{jogo.nome}}</td>
                                        <td>{{jogo.categoria}}</td>
                                        <td>{{jogo.valor}}</td>
                                        <td>{{jogo.desenvolvedora}}</td>
                                        <td>
                                            <router-link :to="`/jogoDetail:${jogo.id}`">
                                                <button class="btn btn-sm btt-outline-submit">Editar</button>
                                            </router-link>
                                        </td>
                                        <td>
                                            <button class="btn btn-sm btn-outline-danger" disabled @click="removerJogo(jogo)">Remover</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
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
    .table-jogos{
        background-color: #1C1B1B;
        color: white;
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