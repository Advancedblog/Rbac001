<template>
  <dir class="cen">
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span >系统管理</span>
        <el-button style="float: right; padding: 3px 0" @click="Register" type="text"
          ><h4>注册</h4></el-button
        >
      </div>
            <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm" >
  <el-form-item label="账号：" prop="admName">
    <el-input v-model="ruleForm.admName"></el-input>
  </el-form-item>
  <el-form-item label="密码：" prop="admPwd">
    <el-input show-password v-model="ruleForm.admPwd"></el-input>
  </el-form-item>
  <el-form-item v-if="ruleForm.admPwd.length>=6&&ruleForm.admName!=0" label="验证码:" prop="Verification">
     <el-col :span="5">
    <el-input v-model="ruleForm.Verification"></el-input>
     </el-col>
  </el-form-item>

  <el-form-item v-if="ruleForm.admPwd.length>=6&&ruleForm.admName!=0"  label="" prop="Verification2">
<el-col :span="5">
    <el-input disabled  style="color:red" v-model="ruleForm.Verification2"></el-input>
    <el-link type="primary" @click="GetRandom" icon="el-icon-refresh-left" circle></el-link>
    </el-col>
  </el-form-item>
   <el-form-item>
    <el-button type="warning" round icon="el-icon-check" @click="submitForm('ruleForm')"><span>登录</span></el-button>
    <el-button type="danger" round @click="resetForm('ruleForm')">重置</el-button>
  </el-form-item>
</el-form>
      </div>
    </el-card>
  </dir>
</template>
<script>
export default {
  data() {
    return {
      ruleForm: {
        admName: "",
        admPwd: "",
        Verification: "", //验证码
        Verification2: "", //这是获取数据库传过来的验证码
      },
      rules: {
        admName: [
          { required: true, message: "请输入账号", trigger: "blur" },
          {
            min: 3,
            max: 11,
            message: "长度在 3 到 11 个字符",
            trigger: "blur",
          },
        ],
        admPwd: [
          { required: true, message: "请输入密码", trigger: "blur" },
          {
            min: 6,
            max: 15,
            message: "长度在 6 到 15 个字符",
            trigger: "blur",
          },
        ],
        Verification: [
          { required: true, message: "请输入验证码", trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          if (this.ruleForm.Verification != this.ruleForm.Verification2) {
            this.$message.error("验证码不正确");
            return;
          }
          this.$http
            .post(
              "https://localhost:44343/api/LoginServer/GetLogin",
              this.ruleForm
            )
            .then((res) => {
              let infor = res.data;
              if (infor.erSum > 0) {
                this.$message.error(infor.erSuccess);
              } else {
                debugger;
                localStorage.setItem("tok", infor.tok); //获取领牌秘钥
                this.$router.push("/hom");
              }
            });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    Register(){
      this.$router.push("/Reg")
    },
    GetRandom() {
      this.$http
        .get("https://localhost:44343/api/LoginServer/GetRandom")
        .then((res) => {
          this.ruleForm.Verification2 = res.data;
          debugger;
        });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
  created() {
    this.GetRandom();
  },
};
</script>
<style>
.cen {
  width: 100%;
  height: 100%;
  padding-top: 10em;
}
,
.text {
  font-size: 14px;
}
.el-card {
  margin: 0 auto;
}
.item {
  margin-bottom: 20px;
}

.clearfix:after {
  display: table;
  content: "";
}
.clearfix:after {
  clear: both;
}

.box-card {
  width: 500px;
  text-align: center;
}
</style>