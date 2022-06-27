using Fare;
using Rbac.Entity;
using Rbac.Iservic;
using Rbac.servic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Iservic
{
    public class servic2 : Iservic2
    {
        private readonly IMIservic iservic;

        public servic2(IMIservic iservic)
        {
            this.iservic = iservic;
        }

        public List<MeunDTo> GetAll()
        {
            var list = iservic.GetAll();
            //传值到递归
            List<MeunDTo> dTos = new List<MeunDTo>();
            //查询MeunFatherId 父级 id  ==0
            var Quey = list.Where(s => s.MeunFatherId == 0&&s.MeunIsck==false).Select(s => new MeunDTo
            {
                Mid = s.Mid,
                MeunName = s.MeunName,
                MeunLink = s.MeunLink,
                MeunIsck=s.MeunIsck,
            }).ToList();
            GetMeun(Quey); //传参数到递归
            return Quey;    
        }
        /// <summary>
        /// 递归 
        /// </summary>
        /// <param name="dTos"></param>
        private void GetMeun(List<MeunDTo> dTos)
        {
            var lisr1 = iservic.GetAll();

            foreach (var item in dTos) //循环出下级 
            {
                var _list = lisr1.Where(t => t.MeunFatherId == item.Mid && t.MeunIsck == false).Select(s => new MeunDTo
                {
                    Mid = s.Mid,
                    MeunName=s.MeunName,
                    MeunLink=s.MeunLink,
                    MeunIsck = s.MeunIsck,
                }).ToList();

                item.children.AddRange(_list); //添加范围
                GetMeun(_list); //调用自己
            }

        }

        public List<MeunAddDto> AddDtos()
        {
            var list = iservic.GetAll();

            List<MeunAddDto> addDtos = new List<MeunAddDto>();
            //查询第一级ID 为零的 数据
            var Query = list.Where(s => s.MeunFatherId == 0 && s.MeunIsck == false).Select(s => new MeunAddDto
            {
                value = s.Mid,
                label = s.MeunName
            }).ToList();
            GetAddMethod(Query);
            return Query;
        }

        private void GetAddMethod(List<MeunAddDto> addDtos)
        {
            var list = iservic.GetAll();

            foreach (var item in addDtos)
            {
                var list_1 = list.Where(t => t.MeunFatherId == item.value&&t.MeunIsck==false).Select(s => new MeunAddDto
                {
                    value = s.Mid,
                    label = s.MeunName
                }).ToList();
                item.children.AddRange(list_1); //添加范围
                GetAddMethod(list_1);
            }
        }

        public bool GetMeunAdd(MeunAddDto meun)
        {
            Meun obj = new Meun
            {
               MeunName = meun.label,
               MeunFatherId=meun.value,
               MeunLink=meun.meunLink,
               MeunIsck = false
            };
            return iservic.GetMeunAdd(obj);
        }

        public bool GetMeunUpdate(MeunAddDto updDto)
        {
            Meun upd = new Meun
            {
                Mid = updDto.Mid,
                MeunName = updDto.label,
                MeunFatherId = updDto.value,
                MeunLink = updDto.meunLink,
            };
            return iservic.GetMeunPut(upd);
        }
    }
}
