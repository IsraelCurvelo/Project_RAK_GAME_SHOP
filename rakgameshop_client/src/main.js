import Vue from 'vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import App from './App.vue';
import vueResource from 'vue-resource';

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.js'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'sweetalert2/dist/sweetalert2.min.css';
import VueTheMask from 'vue-the-mask'
import VueSweetalert2 from 'vue-sweetalert2';
import vuetify from './plugins/vuetify'
import router from './router'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueSweetalert2);
Vue.use(VueTheMask);

Vue.config.productionTip = false;
Vue.use(vueResource);


new Vue({
  data(){
    return{
      usuario: null
    }
  },
  methods: {
    setUsuario(usuario){
      this.usuario = usuario;
      console.log(this.usuario);
    }
  },
  router,
  VueTheMask,
  vuetify,
  render: h => h(App)
}).$mount('#app')
