using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rbac.IRepository
{
    public interface IRepository<TCURDDto,TKey>
        where TCURDDto:class 
        where TKey:struct  //约束
    {
        bool GetAdd(TCURDDto dto);
        bool GetDelete(TKey id);
        bool GetUpdate(TCURDDto upd);
        List<TCURDDto> GetQuery();
        TCURDDto GetKeyQuery(Expression<Func<TCURDDto, bool>> predicate);
        //List<TCURDDto> GetQueryList(TCURDDto dto);
    }
}
