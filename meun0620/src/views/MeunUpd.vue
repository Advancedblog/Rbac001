<template>
  <dir>
    <el-form
      :model="ruleForm"
      :rules="rules"
      ref="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
    >
      <el-form-item label="菜单选者">
        <el-cascader
          v-model="ruleForm.mid"
          :options="options"
          placeholder="请选择要添加的权限名称"
          :props="{ checkStrictly: true }"
          ref="meunFather"
          @change="handleChange"
          clearable
        ></el-cascader>
      </el-form-item>

      <el-form-item label="菜单选者" prop="label">
        <el-input v-model="ruleForm.label"></el-input>
      </el-form-item>
      <el-form-item label="菜单链接" prop="meunLink">
        <el-input v-model="ruleForm.meunLink"></el-input>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="submitFormUpd('ruleForm')"
          >立即编辑</el-button
        >
        <el-button @click="resetForm('ruleForm')">重置</el-button>
      </el-form-item>
    </el-form>
  </dir>
</template>
<script>

export default {
    props:{
        age:Object
    },
  data() {
    return {
      ruleForm: {
        label: "",
        meunLink: "",
        value: "",
        mid:0
      },
      value:[],
      options: [], //下拉框
      rules: {
        label: [{ required: true, message: "请输入菜单名称", trigger: "blur" }],
        meunLink: [
          { required: true, message: "请输入链接地址", trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    
    handleChange() {
      this.$http
        .get("https://localhost:44343/api/RbacServer/AddDtos")
        .then((res) => {
          var reg = new RegExp('\\,"children":\\[]', "g");

          this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ""));
        });
    },
    submitFormUpd(formName) {
      //菜单新增方法 validate（验证）  参数valid 状态为true 为验证通过
      this.$refs[formName].validate((valid) => {
        if (valid) {  //验证成功执行

        
             //取最后的值
           debugger
           
        this.ruleForm.mid = this.value[0];
        //this.ruleForm.meunFatherId=this.$refs["meunFather"].checkedValue[this.$refs["meunFather"].checkedValue.length-1];

         this.ruleForm.meunFatherId=this.$refs["meunFather"].checkedValue[this.$refs["meunFather"].checkedValue.length-1];
          this.$http
            .put(
              "https://localhost:44343/api/RbacServer/GetMeunUpdate",this.ruleForm.mid
            )
            .then((res) => {
             debugger 
              this.$message.success("菜单编辑成功");
              this.$router.puth("/about");
            });




        } else {
          //验证失败 valid 如果为false 就执行以下 console.log("控件验证不通过");
          console.log("控件验证不通过");
          return false;
        }
      });
    },
    resetForm(formName) {
      //重置方法
      this.$refs[formName].resetFields();
    },
  },
  mounted() {
    this.handleChange();
        this.ruleForm = this.age;
  },
  created(){
    console.log(this.age)
  }
};
</script>