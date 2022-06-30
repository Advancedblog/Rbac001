using Admin;
using Admin.Login.pagestratorsIntInterfaceFile;
using AutomappperConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rbac.Iservic;
using Rbac.MyDbcontextEF;
using Rbac.servic;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Rbac.MeunApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rbac.MeunApi", Version = "v1" });
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //在header中添加token，传递到后台
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                // 显示注释
                #region
                string path = Path.GetDirectoryName(typeof(Program).Assembly.Location);// 程序运行时的目录
                string xmlpath = Path.Combine(path, "Rbac.MeunApi.xml");
                c.IncludeXmlComments(xmlpath);
                #endregion
        });
            //配置上下文
            services.AddDbContext<MyDbContext>(option =>
            {
                //使用 Sqlserver 配置连接字符串
                option.UseSqlServer(Configuration.GetConnectionString("Sqlserver"));
            });
            //配置  跨域策略
            services.AddCors(options =>
            {
                // this defines a CORS policy called "c"
                options.AddPolicy("Cors", policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            #region 配置令牌
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
            option =>
            {
                //Token验证参数
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],//发行人

                    //是否验证受众人
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],//受众人

                    //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                    ValidateLifetime = true, //验证生命周期

                    RequireExpirationTime = true, //过期时间

                    ClockSkew = TimeSpan.Zero   //平滑过期偏移时间
                };
            }
        );
            #endregion
            //注册
            services.AddAutoMapper(Assembly.Load("AutomappperConfig")); //注册 AutoMapper 
            services.AddScoped<Iservic2, servic2>();
            services.AddScoped<IMIservic, MIservic>();
            services.AddScoped<IAdministratorsIntInterface, AdministratorsIntInterface>();
            services.AddScoped<IpagestratorsIntInterface, pagestratorsIntInterface>();
            services.AddScoped<ILoginService, LoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rbac.MeunApi v1"));
            }
            //使用跨域策略
            //app.UseCors("Cors");
            app.UseCors(s => s.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); //简便跨域 没有权威
            app.UseHttpsRedirection();

            app.UseRouting();
            
            //认证
            app.UseAuthentication();
            //授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
