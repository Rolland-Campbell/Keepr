import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost:8080') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultkeeps: [],
    activekeep: [],
    activevault: [],
    keepsinvault: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultkeeps = vaultKeeps
    },
    setActiveKeep(state, activeKeep) {
      state.activekeep = activeKeep
    },
    setActiveVault(state, activeVault) {
      state.activevault = activeVault
    },
    setKeepsInVault(state, keepsinvault) {
      state.keepsinvault = keepsinvault
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async getAllKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getKeepById({ commit, dispatch }, payload) {
      try {
        //  let data = await api.put(`/keeps/${payload.id}`)
        let data = await api.get(`/keeps/${payload}`).then(res => {
          res.data.views++
          api.put("keeps/" + payload, res.data)
          commit('setActiveKeep', res.data)
        })
      } catch (error) {
        console.error(error)
      }
    },
    async getAllVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getVaultById({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`/vaults/${payload.id}`)
        commit('setActiveVault', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getVaultKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('vaultKeeps')
        commit('setVaultKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getKeepsByVaultId({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`/vaultKeeps/${payload.id}`)
        commit('setKeepsInVault', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async addKeep({ commit, dispatch }, payload) {
      try {
        await api.post('keeps', payload)
        dispatch('getAllKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async addVault({ commit, dispatch }, payload) {
      try {
        await api.post('vaults', payload)
        dispatch('getAllVaults')
      } catch (error) {
        console.error(error)
      }
    },
    async addToVault({ commit, dispatch }, payload) {
      try {
        await api.post('vaultKeeps', payload)
        api.get(`keeps/${payload.keepId}`).then(res => {
          res.data.keeps++
          api.put(`/keeps/${payload.keepId}`, res.data)
          dispatch('getAllVaults')
          dispatch('getAllKeeps')
        })
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({ commit, dispatch }, payload) {
      try {
        await api.delete('keeps/' + payload)
        dispatch('getAllKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        await api.delete('vaults/' + payload)
        dispatch('getAllVaults')
      } catch (error) {
        console.error(error)
      }
    },
  }
})
