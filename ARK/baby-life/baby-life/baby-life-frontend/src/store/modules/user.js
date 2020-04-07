debugger;
import Vue from 'vue'

const state = {
    name: '',
    phone: '',
    email: '',
    userId: null,
    isLoggedIn: false,
    loginError: ''
}

const getters = {
    isLoggedIn: state => state.isLoggedIn,
    userId: state => state.userId,
    loginError: state => state.loginError
}

const actions = {
logInUser ({ commit }, payload) {
     Vue.axios({
        method: 'post',
        url: 'accounts/login',
        data: {
          Email: payload.email,
          Password: payload.password
        }
      })
    .then((resp) => {
        let data = resp.data
        if(data) {
            console.log(data.email);
            if (data.email === payload.email) {
            payload.userId = 1;
                commit('logInUser', payload)
            } else {
                commit('loginError')
            }
        }       
    })
    .catch(() => {
        commit('loginError')
    })
}
}

const mutations = {
    logInUser (state, payload) {
        state.email = payload.email
        state.userId = payload.userId
        state.isLoggedIn = true
    },
    loginError (state) {
        state.isLoggedIn = false
        state.loginError = 'Eeeeeeeeeeeeeeeeemail and/or Password are invalid. Login failed.'
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}