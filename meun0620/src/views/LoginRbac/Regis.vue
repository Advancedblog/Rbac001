<template>
  <div>
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span>管理员注册</span>
         <el-button
         style="float: left; padding: 3px 0"
            type="primary"
            icon="el-icon-box"
            round
            @click="RegEmilPhone"
            >邮箱注册</el-button
          >
      </div>
      <div >
        <el-form
          :model="ruleForm"
          :rules="rules"
          ref="ruleForm"
          label-width="100px"
          class="demo-ruleForm"
        >
         
          <el-form-item
            v-if="ruleForm.isLos == false"
            label="账号"
            prop="admName"
          >
            <el-input placeholder="请输入账号" v-model="ruleForm.admName"></el-input>
          </el-form-item>
          <el-form-item 
          v-show="ruleForm.isLos" 
          label="邮箱账号"
           prop="admEmile">
            <el-input placeholder="请输入邮箱" v-model="ruleForm.admEmile"></el-input>
          </el-form-item>

          <el-form-item label="密码" prop="admPwd">
            <el-input placeholder="请输入密码" type="password" v-model="ruleForm.admPwd"></el-input>
          </el-form-item>

          <el-form-item>
            <el-button type="primary" @click="submitForm('ruleForm')"
              >注册</el-button
            >
            <el-button @click="resetForm('ruleForm')">重置</el-button>
          </el-form-item>
        </el-form>
      </div>
    </el-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      ruleForm: {
        admName: "", //账号
        admPwd: "", //密码
        admEmile: "", //邮箱
        // addDateTimeA: null, //登录日期 //加上时间字段报 400  原因：类型不能转换   解决方案：把类型转换成'后端'里的类型一致
        // lastLoginDateTimeA: null, //末次登录时间
        lastLoginIPA: "", //上次登录
        isLos: false,
      },
      rules: {
        admName: [
          { required: true, message: "请输入账号", trigger: "blur" },
        ],
        // admEmile: [
        //   { required: true, message: "请输入邮箱", trigger: "blur" },
        // ],
         admPwd: [
          { required: true, message: "请输入密码", trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    RegEmilPhone() {
      this.ruleForm.isLos = !this.ruleForm.isLos;
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$http.post("https://localhost:44343/api/LoginServer/Register",this.ruleForm).then(res=>{
             let infor = res.data;
             debugger
             if(infor.erSum > 0){
                this.$message.success(infor.erSuccess);
                this.$router.push("/log");
                return
             }
             else{
                this.$message.error(infor.erSuccess);
             }
          })
        } else {
          console.log("请验证数据是否正确");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
};
</script>

<style>
.el-card{
    margin: 0 auto; 
}
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