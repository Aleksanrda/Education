import Vue from "vue";
debugger;
export default {
  state: {
    user: {
      isAuthenticated: false,
      uid: null,
    },
  },
  mutations: {
    set_user(state, payload) {
      state.user.isAuthenticated = true;
      state.user.uid = payload;
    },
    // unset_user(state) {
    //     user = 
    // }
  },
  actions: {
    signup({ commit }, payload) {
      commit("set_processing", true);
      Vue.axios({
        method: "post",
        url: "accounts/register",
        data: {
          Email: payload.email,
          Name: payload.username,
          PhoneNumber: payload.tel,
          Password: payload.password,
        },
      })
        .then((user) => {
          commit("set_user", user.data.id);
          commit("set_processing", false);
        })
        .catch(function(error) {
          commit("set_processing", true);
          commit("set_error", error.message);
        });
    },
    signin({ commit }, payload) {
      commit("set_processing", true);
      Vue.axios({
        method: "post",
        url: "accounts/login",
        data: {
          Email: payload.email,
          Password: payload.password,
        },
      })
        .then((user) => {
            if(user.data.token)
            {
                commit("set_user", user.data.id);
                commit("set_processing", false);
            }
            commit("set_processing", true);
        })
        .catch(function(error) {
          commit("set_processing", true);
          commit("set_error", error.message);
        });
    },
    state_changed({commit}, payload) {
        if (payload) {
            commit('set_user', payload.uid)
        }
        // else {

        // }
    }
  },
  getters: {
    isUserAuthenticated: (state) => state.user.isAuthenticated,
  },
};
