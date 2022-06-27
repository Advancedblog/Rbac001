import Vue from 'vue'
import App from './App.vue'
import router from './router'
Vue.use(ElementUI);
import store from './store'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import axios from 'axios';
// 创建实例后修改默认值
Vue.prototype.$refs = axios
//axios.defaults.headers.common['Authorization'] = `bearer ${localStorage.getItem("tok")}`;
axios.defaults.headers.common['Authorization'] = `bearer ${localStorage.getItem('tok')}`;

Vue.config.productionTip = false
Vue.use(ElementUI)
Vue.prototype.$http =axios
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
