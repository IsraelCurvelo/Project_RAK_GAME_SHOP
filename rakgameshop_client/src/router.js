import Vue from 'vue';
import Router from 'vue-router';
import userLogin from './components/UserLogin';
import newUser from './components/NewUser';
import store from './components/Store';
import newProduct from './components/NewProduct';
import libary from './components/Library';
import jogoCompra from './components/JogoCompra';
import paymentMethod from './components/PaymentMethod';
import modalBoleto from './components/shared/modals/Boleto';
import modalPIX from './components/shared/modals/PIX';
import confirmaCompra from './components/shared/modals/ConfirmaCompra';
import sucessoPedido from './components/shared/modals/SucessoPedido';

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
    },
    {
      path: '/gameDetail:id',
      nome: 'gameDetail',
      component: jogoCompra,
    },
    {
      path: '/paymentMethod',
      nome: 'paymentMethod',
      component: paymentMethod
    },
    {
      path: '/modalBoleto',
      nome: 'modalBoleto',
      component: modalBoleto
    },
    {
      path: '/PIX',
      nome: 'PIX',
      component: modalPIX
    },
    {
      path: '/confirmaCompra',
      nome: 'confirmaCompra',
      component: confirmaCompra
    },
    {
      path: '/sucessoPedido',
      nome: 'sucessoPedido',
      component: sucessoPedido
    }
  ]
})