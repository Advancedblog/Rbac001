using System;
using System.Collections.Generic;

namespace IBaseService
{
    public interface IBservice<TCURDDto, TDto> 
         where TCURDDto : class, new() 
         where TDto :class,new()
    {
        bool GetAdd(TDto dto);
        bool GetUpdate(TDto dto);
        bool GetDelete(int id);
        List<TDto> GetQuery();
        //List<TCURDDto> GetQueryPage(TDto dto);
    }
}
