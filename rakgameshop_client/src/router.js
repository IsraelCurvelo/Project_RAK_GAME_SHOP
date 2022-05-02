import Vue from 'vue';
import Router from 'vue-router';
import userLogin from './components/UserLogin';
import newUser from './components/NewUser';
import store from './components/Store';

Vue.use(Router);

export default new Router({
  routes:[
    {
      path: '/',
      nome: 'store',
      component: store
    },
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