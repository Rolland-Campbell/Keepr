import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import ViewKeep from './views/ViewKeep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'login',
      component: Login
    },
    {
      path: '/home',
      name: 'home',
      component: Home
    },
    {
      path: '/vault/:vaultId',
      name: 'vault',
      component: Vault,
      props: true
    },
    {
      path: '/viewKeep',
      name: 'viewKeep',
      component: ViewKeep
    },
  ]
})
