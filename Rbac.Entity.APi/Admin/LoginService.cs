
using Admin.Dto;
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

        public LoginService(IAdministratorsIntInterface administratorsInt, IMapper mapper, IConfiguration configuration)
            : base(administratorsInt, mapper)
        {
            this.administratorsInt = administratorsInt;
            this.mapper = mapper;
            this.configuration = configuration;
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
            var Adminpwd = administratorsInt.GetKeyQuery(s => s.AdmPwd.ToLower() == Md5(dto.AdmPwd.Trim().ToLower()));
            if (AdminName==null)//判断 数据库是否有此  账号
            {
                return new Toenk { ErSum = 0, ErSuccess = "账号不正确" };
            }
            if (Adminpwd!=null) //判断是否  跟数据库密码一直
            {
                return new Toenk { ErSum = -1, ErSuccess = "密码不正确" };

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
                ErSum = 1,
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
