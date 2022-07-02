<template>
    <div class="ss">
        <el-container>
  <el-aside width="200px">
    <el-menu
      default-active="2"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
      background-color="#545c64"
      text-color="#fff"
      :unique-opened='true'
      active-text-color="#ffd04b"  :router="true">
      <el-submenu index="1" v-for="ie in FilMeun" :key="ie.mid">
        <template slot="title">
          <i class="el-icon-location"></i>
          <span>{{ ie.meunName }}</span>
        </template>
        <el-menu-item-group>
          <el-menu-item v-for="item in Meun.filter(a=>a.meunFatherId==ie.mid)" :key="item.mid">
          <el-menu-item :index="meunitem.meunLink"
           v-for="meunitem in Meun.filter(w=>w.meunFatherId==item.mid)" 
            :key="meunitem.mid">
          <span>{{ meunitem.meunName }}</span>
          </el-menu-item>
            </el-menu-item> 
        </el-menu-item-group>
      </el-submenu>
    </el-menu>
  </el-aside>
  <el-main>
     <router-view/>
  </el-main>
</el-container>
    </div>
</template>
<script>
  export default {
    data(){
      return{
          Meun:[],
      }
    },
    methods: {
      handleOpen(key, keyPath) {
        console.log(key, keyPath);
      },
      handleClose(key, keyPath) {
        console.log(key, keyPath);
      },
      getMeunList(){
         this.$http.get("https://localhost:44343/api/RbacServer/GetMeunList").then(res=>{
          this.Meun = res.data;
        })
       }
    },
    created(){
       this.getMeunList();
    },
    computed:{
      FilMeun(){
        //  return this.Meun.filter(s=>s.meunFatherId==0)
         return this.Meun.filter(t=>t.meunFatherId==0);
      }
    }
   
  }
</script>

<style>
.el-submeun_title{
},
  .el-header, .el-footer {
    background-color: #B3C0D1;
    color: #333;
    text-align: center;
    line-height: 20px;
  }
  .el-meun{
        border-right: solid 0px #af1414;
  }
  .el-aside {
    background-color: #545c64;
    color: rgb(193, 39, 39);
    text-align: center;
    line-height: 200px;
  }
  
  .el-main {
    background:repeating-linear-gradient(rgb(184, 25, 128),rgb(46, 155, 209),rgb(33, 35, 33),blue);
    color: rgb(100, 26, 174);
    text-align: center;
    line-height: 160px;
    padding:100px;
  }
  
  body > .el-container {
    margin-bottom: 40px;
  }
  
  .el-container:nth-child(5) .el-aside,
  .el-container:nth-child(6) .el-aside {
    line-height: 260px;
  }
  
  .el-container:nth-child(7) .el-aside {
    line-height: 320px;
  }
</style>