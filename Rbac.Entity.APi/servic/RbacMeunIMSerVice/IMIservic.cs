using Rbac.Entity;
using System;
using System.Collections.Generic;

namespace Rbac.servic
{
    public interface IMIservic
    {
        List<Meun> GetAll();

        int GetRomre(int id);

        bool GetMeunPut(Meun upd);

        bool GetMeunAdd(Meun obj);

        bool GetMeunAdd2(Meun add);
   
    }
}
