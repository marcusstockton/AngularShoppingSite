import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
      status: '',
      token: localStorage.getItem('user-token') || '',
      user : {}
    },
    mutations: {
      
    },
    actions: {
      
    },
    getters: {
      isLoggedIn(state) {
        return state.user != null;
      }
    },
  });