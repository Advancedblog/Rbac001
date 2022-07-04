<template>
    <dir>
<el-card class="box-card">
  <div  class="text item">
   <el-tree
  ref="peimterry"
  :data="data"
  show-checkbox
  node-key="value"
  :default-expanded-keys="[2, 3]"
  :default-checked-keys="[5]"
  :props="defaultProps">
</el-tree>
  <el-button @click="data1">查看信息</el-button>
  </div>
</el-card>
    </dir>
</template>


<script>
  export default {
   
    data() {
      return {
        data: [],
        defaultProps: {
          value: 'value',
          label: 'label'
        }
      };
    },
    methods: {
      data1(){
         var list = this.$refs["peimterry"].getCheckedNodes(true,true).map(m => m.value); //获取选中的Id 
         console.log(list);
      },
      handleChange(value) {
      this.$http
        .get("https://localhost:44343/api/RbacServer/AddDtos")
        .then((res) => {
          var reg = new RegExp('\\,"children":\\[]', "g");
          this.data = JSON.parse(JSON.stringify(res.data).replace(reg, ""));
        });
    },
    },
    created(){
        this.handleChange();
    }
  };
</script>

<style>
  .text {
    font-size: 14px;
  }

  .item {
    padding: 18px 0;
  }

  .box-card {
    width: 480px;
  }
</style>