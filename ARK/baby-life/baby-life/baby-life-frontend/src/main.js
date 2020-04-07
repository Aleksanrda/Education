debugger;
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import axios from 'axios'
import {i18n} from './plugins/i18n'
import FlagIcon from 'vue-flag-icon'

Vue.config.productionTip = false
Vue.axios = Vue.prototype.$http = axios.create({
  baseURL: 'http://localhost:62899/api'
})

Vue.use(FlagIcon)

// // global app config object
// Vue.config.productionTip: JSON.stringify({
//   apiUrl: '/api'
// })

new Vue({
  i18n,
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
