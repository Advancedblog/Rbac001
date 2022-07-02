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

  // {
  //   path: '/Meunadd',
  //   name: '菜单新增',
  //   component: () => import(/* webpackChunkName: "about" */ '../views/MeunAdd.vue')
  // },
  { //
    path: '/Meunaupd',
    name: '菜单编辑',
    component: () => import(/* webpackChunkName: "about" */ '../views/MeunUpd.vue')
  },
  { //菜单编辑2
    path: '/Update',
    name: '菜单编辑2',
    component: () => import(/* webpackChunkName: "about" */ '../views/Update.vue')
  }, {//登录操作
    path: '/log',
    name: '登录',
    component: () => import(/* webpackChunkName: "about" */ '../views/LoginRbac/Login.vue')
  },
  {
    path: '/Reg',
    name: '注册操作',
    component: () => import(/* webpackChunkName: "about" */ '../views/LoginRbac/Regis.vue')
  },
  {
    path: '/perm',
    name: '权限树',
    component: () => import(/* webpackChunkName: "about" */ '../views/Admin/Permissiontree.vue')
  },
  { //注册操作
    path: '/hom',
    name: '导航',
    component: () => import(/* webpackChunkName: "about" */ '../views/RbacMeunView/RbacHome.vue'),
    children: [
      { path: '/about', component: () => import('../views/AboutView.vue') },
      {path: '/Meunadd', component: () => import('../views/MeunAdd.vue')},
      { path: '/Admdate',component: () => import(/* webpackChunkName: "about" */ '../views/Admin/AdminView.vue')},
    ]
  },


]

const router = new VueRouter({
  routes
})

//路由守卫
router.beforeEach((t, f, n) => {
  let LogName = sessionStorage.getItem("admName") ?? ""
  if (t.name !== "登录" && LogName == "") {
    n({ name: "登录" })
  }
  else {
    n();
  }
})

export default router
