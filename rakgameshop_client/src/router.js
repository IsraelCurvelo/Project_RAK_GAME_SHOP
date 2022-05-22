import Vue from 'vue';
import Router from 'vue-router';
import userLogin from './components/UserLogin';
import newUser from './components/NewUser';
import store from './components/Store';
import newProduct from './components/NewProduct';
import libary from './components/Library';

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
    },
    {
      path: '/newProduct',
      nome: 'newProduct',
      component: newProduct
    },
    {
      path: '/library',
      nome: 'library',
      component: libary
    }
  ]
})