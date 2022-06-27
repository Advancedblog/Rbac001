import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/Meunadd',
    name: '菜单新增',
    component: () => import(/* webpackChunkName: "about" */ '../views/MeunAdd.vue')
  },
  {
    path: '/Meunaupd',
    name: '菜单编辑',
    component: () => import(/* webpackChunkName: "about" */ '../views/MeunUpd.vue')
  },
  {
    path: '/Update',
    name: '菜单编辑2',
    component: () => import(/* webpackChunkName: "about" */ '../views/Update.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
