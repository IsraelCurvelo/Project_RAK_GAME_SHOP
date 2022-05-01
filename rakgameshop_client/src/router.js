import Vue from 'vue';
import Router from 'vue-router';
import userLogin from './components/UserLogin';
import newUser from './components/NewUser';

Vue.use(Router);

export default new Router({
  routes:[
    {
      path: '/login',
      nome: 'login',
      component: userLogin
    },
    {
      path: '/signin',
      nome: 'signin',
      component: newUser
    }
  ]
})