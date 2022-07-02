
using Admin.Dto;
using Admin.Login.pagestratorsIntInterfaceFile;
using AutoMapper;
using IBaseService;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class LoginService : Bservice<Administrators, RegisterDto>, ILoginService
    {
        private readonly IAdministratorsIntInterface administratorsInt;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
       private readonly IpagestratorsIntInterface ipagestratorsInt;

        public LoginService(IAdministratorsIntInterface administratorsInt, IMapper mapper, IConfiguration configuration, IpagestratorsIntInterface ipagestratorsInt)
            : base(administratorsInt, mapper)
        {
            this.administratorsInt = administratorsInt;
            this.mapper = mapper;
            this.configuration = configuration;
            this.ipagestratorsInt = ipagestratorsInt;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Toenk GetLogin(AdminDto dto)
        {
            var AdminName = administratorsInt.GetKeyQuery(s => s.AdmName == dto.AdmName.Trim());
            //ToLower()  把字母字符转换成小写, Trim 首尾两端的空格移除
            if (AdminName==null)//判断 数据库是否有此  账号
            {
                return new Toenk { ErSum = 1, ErSuccess = "账号不正确" };
            }
            if (AdminName.AdmPwd.ToLower()!=Md5(dto.AdmPwd.Trim().ToLower())) //判断是否  跟数据库密码一直
            {
                return new Toenk { ErSum = 2, ErSuccess = "密码不正确" };
            }
            //Jwt  有；表头，签名，负载
            //1.表头Header：记录令牌类型，以及算法
            //2.签名: 防治Toenk信息被篡改，
            //3.负载就是对用户的信息进行声明  所有的用户信息都是放在负载里面的  他是json格式
            //生成Token令牌
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, dto.AdmName)
            };
            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));
            //算法，签名证书  签名: 防治Toenk信息被篡改
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);
            //Payload负载 负载就是对用户的信息进行声明  所有的用户信息都是放在负载里面的  他是json格式
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims, //自定义声明信息
                notBefore: DateTime.UtcNow,  //创建时间
                expires: expires,   //过期时间
                signingCredentials: cred
                );
            var handler = new JwtSecurityTokenHandler();
            //生成令牌
            string jwt = handler.WriteToken(token);
            //成功后返回
            return new Toenk
            {
                ErSum = 0,
                ErSuccess = "登录成功",
                Tok = jwt //返回令牌
            };
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Eroor Register(RegisterDto admin)
        {
            var RegisName = administratorsInt.GetKeyQuery(s => s.AdmName == admin.AdmName.Trim().ToLower());
            if (RegisName!=null)
            {
                return new Eroor { ErSum = 0, ErSuccess = "用户已存在" };
            }
            admin.AdmName = admin.AdmName.Trim().ToUpper(); //ToUpper 转化成大写
            admin.AdmPwd = Md5(admin.AdmPwd.Trim());
            admin.AddDateTimeA = DateTime.Now;
            admin.LastLoginDateTimeA = DateTime.Now;
            admin.LastLoginIPA = null;
            //进行添加
            administratorsInt.GetAdd(mapper.Map<Administrators>(admin));
            return new Eroor { ErSum = 1, ErSuccess = "注册成功" };
    }
        /// <summary>
        /// 管理员查询2  “分页” 多一个对象  ？？？？？？？？
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public AdminQuery admin1(Page page)
        {
            var list = administratorsInt.GetQuery().AsQueryable();
            //var list = ipagestratorsInt.GetQueryPage(page).AsQueryable();
            var coun = list.Count();
            var list1 = list.OrderBy(s => s.AdmID).Skip((page.PIndex - 1) * page.PSizs).Take(page.PSizs);
            var list2 = mapper.Map<List<AdminQuery>>(list1); //类型转换
            return new AdminQuery { PToTa = coun,admins = list2};
        }
        /// <summary>
        ///  管理员 1 "分页"
        /// </summary>
        /// <param name="PIndex"></param>
        /// <param name="PSizs"></param>
        /// <returns></returns>
        public Tuple<List<AdminQuery>,int> GetPage(int PIndex = 0,int PSizs = 0)
        {
            var list = administratorsInt.GetQuery().AsQueryable(); //查询全部数据
            var count = administratorsInt.GetQuery().Count(); //获取总数据
            var skip = (PIndex - 1) * PSizs; // 分页 计算公式
            var data = list.OrderBy(s => s.AdmID).Skip(skip).Take(PSizs).ToList(); //实现分页
            var list1 = mapper.Map<List<AdminQuery>>(data);
            return new Tuple<List<AdminQuery>,int>(list1, count);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }
    }
}
