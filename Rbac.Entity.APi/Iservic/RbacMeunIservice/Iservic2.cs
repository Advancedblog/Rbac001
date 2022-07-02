using Rbac.Entity;
using Rbac.Iservic;
using System;
using System.Collections.Generic;

namespace Rbac.Iservic
{
    public interface Iservic2
    {
        List<MeunDTo> GetAll();
        List<MeunAddDto> AddDtos();

        bool GetMeunAdd(MeunAddDto meun);
        bool GetMeunUpdate(MeunAddDto updDto);
         List<Meun> GetMeunList();
        int GetRomre(int id);
    }
}   
