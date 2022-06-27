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
  },{
    path: '/log',
    name: '登录操作',
    component: () => import(/* webpackChunkName: "about" */ '../views/LoginRbac/Login.vue')
  },
  {
    path: '/hom',
    name: '导航',
    component: () => import(/* webpackChunkName: "about" */ '../views/RbacMeunView/RbacHome.vue'),
    children:[
      { path: '/about', component: () => import( '../views/AboutView.vue')},
    ]
  }

]

const router = new VueRouter({
  routes
})

export default router
