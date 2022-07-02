<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column label="账号" prop="admName" width="180">
      </el-table-column>
      <el-table-column label="密码" prop="admPwd" width="180">
      </el-table-column>
      <el-table-column label="邮箱账号" prop="admEmile" width="180">
      </el-table-column>
      <el-table-column label="注册时间" width="180">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.addDateTimeA }}</span>
        </template>
      </el-table-column>

      <el-table-column label="登录时间" width="180">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{
            GetDateTime(scope.row.lastLoginDateTimeA)
          }}</span>
        </template>
      </el-table-column>

      <el-table-column label="末次登录时间" width="180">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{scope.row.lastLoginIPA  }}</span>
        </template>
      </el-table-column>

      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)"
            >编辑</el-button>
          <el-button
            size="mini"
            type="danger"
            @click="handleJurisdictionDistribution(scope.$index, scope.row)"
            >权限分配</el-button>
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >删除</el-button>
          
        </template>
      </el-table-column>
      
    </el-table>
    <div>
    <el-pagination
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="page.PSizs"
      :page-sizes="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20]"
      :page-size="100"
      layout="total, sizes, prev, pager, next, jumper"
      :total="page.item2"
      background
    >
    </el-pagination>
    </div>
    <el-dialog
  title="提示"
  :visible.sync="dialogVisible"
  width="30%"
  :before-close="handleClose">
  
  <peimterry  />

  <span slot="footer" class="dialog-footer">
    <el-button @click="dialogVisible = false">取 消</el-button>
    <el-button type="primary" @click="dialogVisible = false">确 定</el-button>
  </span>
</el-dialog>
  </div>
</template>
<script>
import peimterry from "@/views/Admin/Permissiontree.vue"
import moment from 'moment'
export default {
  components:{
    peimterry,
  },
  data() {
    return {
      dialogVisible:false,
      tableData: [],
      page: {
        PIndex: 1,
        PSizs: 1,
        item2: 0,
      },
      moment,
    };
  },
  methods: {
    GetAdminList() {
      this.$http
        .get("https://localhost:44343/api/LoginServer/GetPage", {
          params: { PIndex: this.page.PIndex, PSizs: this.page.PSizs },
        })
        .then((res) => {
          this.tableData = res.data.item1;
          this.page.item2 = res.data.item2;
        });
    },
    handleJurisdictionDistribution(index, row){ //实现权限分配
      this.dialogVisible = true;
    },
    GetDateTime(){
        return moment().format('YYYY年MM月DD日HH时s分S秒-第:E周');
    },
    handleEdit(index, row) { //编辑
      console.log(index, row);
    },
    handleDelete(index, row) { //删除
      console.log(index, row);
    },
    handleSizeChange(val) {
      this.page.PIndex = 1;
      this.page.PSizs = val;
      this.GetAdminList();
      console.log(`每页 ${val} 条`);
    },
    handleCurrentChange(val) {
      this.page.PIndex = val;
      this.GetAdminList();
      console.log(`当前页: ${val}`);
    },
  },
  created() {
    this.GetAdminList();
  },
};
</script>