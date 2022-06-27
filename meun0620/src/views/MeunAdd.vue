<template>
  <dir>
    <el-form
      :model="ruleForm"
      :rules="rules"
      ref="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
    >
      <el-form-item label="菜单选者" prop="value">
        <el-cascader
          v-model="value"
          :options="options"
          placeholder="请选择要添加的权限名称"
          :props="{ checkStrictly: true }"
          @change="handleChange"
          clearable
        ></el-cascader>
      </el-form-item>

      <el-form-item label="菜单名称" prop="label">
        <el-input v-model="ruleForm.label"></el-input>
      </el-form-item>
      <el-form-item label="菜单链接" prop="meunLink">
        <el-input v-model="ruleForm.meunLink"></el-input>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="submitForm('ruleForm')"
          >立即创建</el-button
        >
        <el-button @click="resetForm('ruleForm')">重置</el-button>
      </el-form-item>
    </el-form>
  </dir>
</template>
<script>
export default {
  data() {
    return {
      ruleForm: {
        label: "",
        meunLink: "",
        value: "",
      },
      value: [],
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
    handleChange(value) {
      this.$http
        .get("https://localhost:44343/api/RbacServer/AddDtos")
        .then((res) => {
          var reg = new RegExp('\\,"children":\\[]', "g");
          this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ""));
          console.log(this.value);
        });
    },
    submitForm(formName) {
      //菜单新增方法 validate（验证）  参数valid 状态为true 为验证通过
      this.$refs[formName].validate((valid) => {
        if (valid) {
            this.$confirm('此操作将新增菜单操作, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
           //验证成功执行
          this.ruleForm.value = this.value.slice(-1)[0]; //取最后的值
          // this.$router.push("submitForm",true)
          this.$http
            .post(
              "https://localhost:44343/api/RbacServer/GetMeunAdd",
              this.ruleForm
            )
            .then((res) => {
              this.$emit("submitForm", true);
              this.$message.success("菜单新增成功");
              this.$router.puth("/about");
            });
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '已取消新增'
          });          
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
  },
};
</script>