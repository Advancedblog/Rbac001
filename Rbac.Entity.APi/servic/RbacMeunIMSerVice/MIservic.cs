using Rbac.Entity;
using Rbac.MyDbcontextEF;
using Rbac.servic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.servic
{
    public class MIservic : IMIservic
    {
        private readonly MyDbContext dbContext;

        public MIservic(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Meun> GetAll()
        {
            return dbContext.Meun.ToList();
        }

        public bool GetMeunAdd(Meun obj)
        {
            dbContext.Meun.Add(obj);
            return dbContext.SaveChanges()>0;

        }

        public bool GetMeunAdd2(Meun add)
        {
            dbContext.Meun.Add(add);
            return dbContext.SaveChanges() > 0;
        }

        public bool GetMeunPut(Meun upd)
        {
            dbContext.Entry(upd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除 菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetRomre(int id)
        {
            var list = dbContext.Meun.Find(id);
            dbContext.Meun.Remove(list);
            return dbContext.SaveChanges();
        }
    }
}
