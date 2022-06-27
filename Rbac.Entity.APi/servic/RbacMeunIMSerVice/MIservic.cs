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
        public bool GetRomre(int id)
        {

            int arrid=0;
            bool ISbk = false;
            var del = dbContext.Meun.FirstOrDefault(s=>s.Mid==id);
            if (del!=null)
            {
                var listdel = dbContext.Meun.Where(s=>s.MeunFatherId== del.Mid);

                if (listdel!=null)
                {
                    foreach (var item in listdel)
                    {
                         arrid = item.MeunFatherId;
                    }
                   var dd = dbContext.Meun.Where(s=>s.MeunFatherId==arrid).FirstOrDefault();
                    if (dd.MeunIsck==false)
                    {
                        //dbContext.RemoveRange(dd);
                        Meun a = new Meun();
                        a.MeunIsck = !a.MeunIsck;
                        del.MeunIsck = !del.MeunIsck;
                        return dbContext.SaveChanges() > 0;
                    }
                    else
                    {
                        del.MeunIsck = !del.MeunIsck;
                        return dbContext.SaveChanges() > 0;
                    }
                }
                else
                {
                    return ISbk;
                }
            }
            return ISbk;
        }



    }
}
