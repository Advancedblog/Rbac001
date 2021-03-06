using Admin.Dto;
using AutoMapper;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomappperConfig
{
    public class Automappper : Profile
    {
        public Automappper()
        {
            CreateMap<RegisterDto, Administrators>().ReverseMap();
            CreateMap<Administrators, AdminQuery>().ReverseMap(); // ReverseMap  反转
            //CreateMap<AdimRoleDto, MeunRileType>().ReverseMap(); // ReverseMap  反转
            //CreateMap<AdimRoleDto, MeunRileType>().ReverseMap(); // ReverseMap  反转
        }
    }
}
