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
import clienteDetails from './components/ClienteDetail';
import admDetails from './components/AdminDetail';
import ListJogos from './components/ListJogos';
import jogoDetail from './components/JogoDetail';
import HistoricoCompra from './components/HistoricoCompra';

Vue.use(Router);

export default new Router({
  routes:[
    {
      path: '/',
      name: 'store',
      component: store
    },
    {
      path: '/login',
      name: 'login',
      component: userLogin
    },
    {
      path: '/signin',
      name: 'signin',
      component: newUser
    },
    {
      path: '/newProduct',
      name: 'newProduct',
      component: newProduct
    },
    {
      path: '/library',
      name: 'library',
      component: libary
    },
    {
      path: '/gameDetail:id',
      name: 'gameDetail',
      component: jogoCompra,
    },
    {
      path: '/paymentMethod',
      name: 'paymentMethod',
      component: paymentMethod
    },
    {
      path: '/modalBoleto',
      name: 'modalBoleto',
      component: modalBoleto
    },
    {
      path: '/PIX',
      name: 'PIX',
      component: modalPIX
    },
    {
      path: '/confirmaCompra',
      name: 'confirmaCompra',
      component: confirmaCompra
    },
    {
      path: '/sucessoPedido',
      name: 'sucessoPedido',
      component: sucessoPedido
    },
    {
      path: '/dados',
      name: 'dadosCliente',
      component: clienteDetails
    },
    {
      path: '/jogos',
      name: 'listJogos',
      component: ListJogos
    },
    {
      path: '/jogoDetail:id',
      name: 'editJogo',
      component: jogoDetail
    },
    {
      path: '/historico',
      name: 'historico',
      component: HistoricoCompra
    },
    {
      path: '/dadosAdm',
      name: 'dadosAdm',
      component: admDetails
    },
  ]
})