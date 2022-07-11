using Rbac.MyDbcontextEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IRepository
{
    //abstract  摘要  抽象类
    public abstract class Repository<TCURDDto, TKey> : IRepository<TCURDDto, TKey>
        where TCURDDto:class 
        where TKey :struct //约束
    {
        protected MyDbContext db;

        /// <summary>
        /// 定义虚方法  是为了可以重写
        /// 添加 接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool GetAdd(TCURDDto dto)
        {
            db.Set<TCURDDto>().Add(dto);

            return db.SaveChanges() > 0;

        }
        /// <summary>
        ///  批量添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual int GetCheckAdd(List<TCURDDto> dto)
        {
            db.Set<TCURDDto>().AddRange(dto);
            return db.SaveChanges();
        }

        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool GetDelete(TKey id)
        {
            var Romove = db.Set<TCURDDto>().Find(id);
            if (Romove==null)
            {
                return false;
            }
            else
            {
                db.Remove(Romove);
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TCURDDto GetKeyQuery(Expression<Func<TCURDDto, bool>> predicate)
        {
            return  db.Set<TCURDDto>().Where(predicate).FirstOrDefault();
        }
        /// <summary>
        /// 查询 全部数据
        /// </summary>
        /// <returns></returns>
        public virtual List<TCURDDto> GetQuery()
        {
            return db.Set<TCURDDto>().ToList();
        }
        /// <summary>
        /// 支持分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public List<TCURDDto> GetQueryList(TCURDDto dto)
        {
            return (List<TCURDDto>)db.Set<List<TCURDDto>>().AsQueryable();
        }

        /// <summary>
        /// 编辑功能
        /// </summary>
        /// <param name="upd"></param>
        /// <returns></returns>
        public virtual bool GetUpdate(TCURDDto upd)
        {
            db.Entry<TCURDDto>(upd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return db.SaveChanges() > 0;
        }
    }
}
