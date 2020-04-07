debugger;
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import axios from 'axios'


Vue.config.productionTip = false
Vue.axios = Vue.prototype.$http = axios.create({
  baseURL: 'http://localhost:62899/api'
})

// // global app config object
// Vue.config.productionTip: JSON.stringify({
//   apiUrl: '/api'
// })

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
