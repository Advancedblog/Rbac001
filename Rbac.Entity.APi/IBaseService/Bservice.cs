using AutoMapper;
using Rbac.IRepository;
using System;
using System.Collections.Generic;

namespace IBaseService
{
    public class Bservice <TCURDDto, TDto> : IBservice<TCURDDto, TDto> where TCURDDto : class, new() where TDto : class, new()
    {
        private readonly IRepository<TCURDDto, int> repository;
        private readonly IMapper mapper;

        public Bservice(IRepository<TCURDDto, int> repository, IMapper mapper) //Miaapper 用于执行映射的配置提供程序
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool GetAdd(TDto dto)
        {
            //MAP执行从源对象到新目标对象的映射。来源
            //类型是从源对象推断出来的
            return repository.GetAdd(mapper.Map<TCURDDto>(dto));
        }
        //删除
        public bool GetDelete(int id)
        {
            return repository.GetDelete(id);
        }
         //查询
        public List<TDto> GetQuery()
        {
            return mapper.Map<List<TDto>>(repository.GetQuery());
        }
        /// <summary>
        /// 支持分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //public List<TCURDDto> GetQueryPage(TDto dto)
        //{
        //    return repository.GetQueryList<List<TCURDDto>>(mapper.Map<TCURDDto>(dto));
        //}

        //编辑
        public bool GetUpdate(TDto dto)
        {
            return repository.GetUpdate(mapper.Map<TCURDDto>(dto));
        }
    }
}
