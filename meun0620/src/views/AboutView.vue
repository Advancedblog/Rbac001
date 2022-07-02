<template>
  <div>
    <el-button type="success" icon="el-icon-check" @click="Add" circle
      >添加菜单</el-button
    >

    <el-table
      :data="tableData"
      style="width: 100%; margin-bottom: 20px"
      row-key="mid"
      border
      ref="meunFatherId"
      default-expand-all
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
    >
      <el-table-column prop="meunName" label="菜单名称" sortable width="180">
      </el-table-column>
      <el-table-column prop="meunLink" label="菜单链接" sortable width="800">
        <template slot-scope="scope">
          <p>
            {{ scope.row.meunLink }}
          </p>
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button
            round
            size="mini"
            @click="handleEdit(scope.$index, scope.row)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            round
            @click="GetIsckROmer(scope.$index, scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>

    <el-dialog title="权限添加" :visible.sync="dialogVisible" width="30%">
      <p>
        <MeunAdd @submitForm="submitForm" />
      </p>
    </el-dialog>

    <el-dialog title="权限编辑" :visible.sync="dialogVisible2" width="30%">
      <p>
        <Meunupd :age="UpdateLIst" />
      </p>
      <span slot="footer" class="dialog-footer"> </span>
    </el-dialog>
  </div>
</template>

<script>
import MeunAdd from "@/views/MeunAdd.vue";
import Meunupd from "@/views/MeunUpd.vue";
export default {
  components: {
    MeunAdd,
    Meunupd,
  },
  data() {
    return {
      dialogVisible: false,
      dialogVisible2: false,
      tableData: [],
      UpdateLIst: [],
    };
  },
  mounted() {
    this.getShow();
  },
  methods: {
    handleEdit(index, row) {
      this.dialogVisible2 = true;
      this.UpdateLIst = row;
      console.log(this.UpdateLIst);
    },
    Add() {
      this.dialogVisible = true;
    },
    submitForm(val) {
      this.dialogVisible = !val;
      this.getShow();
    },
    getShow() {
      this.$http
        .get("https://localhost:44343/api/RbacServer/GetAll")
        .then((m) => {
          this.tableData = m.data;
        });
    },
    GetIsckROmer(index, row) {
      this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          this.$http
            .delete("https://localhost:44343/api/Servercurd", { params: {id:row.mid} })
            .then((m) => {
              if (m.data > 0) {
                this.$message.success("删除成功");
                this.getShow();
              } else if (m.data == 500) {
                this.$message.error("此信息有子级，请删除子级");
                return;
              } else {
                this.$message.error("删除失败");
              }
            });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });
    },
  },
};
</script>
