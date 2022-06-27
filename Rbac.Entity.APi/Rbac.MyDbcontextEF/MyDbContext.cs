using System;
using Microsoft.EntityFrameworkCore;
using Rbac.Entity;
namespace Rbac.MyDbcontextEF
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)  //base  调用副类  进行传给父类值
        {

        }
        public DbSet<Meun> Meun { get; set; }
        public DbSet<MeunRileType> MeunRileType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleAdminisrationType> RoleAdminisrationType { get; set; }
        public DbSet<Administrators> Administrators { get; set; }

        //定义受保护的
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置字段长度
            modelBuilder.Entity<Meun>(s =>
            {
                s.Property(s => s.MeunName).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<Role>(s =>
            {
                s.Property(s => s.RoleName).HasMaxLength(50).IsRequired();
            });
            //设置外键
            modelBuilder.Entity<MeunRileType>(s =>
            {
                s.HasOne<Meun>().WithMany().HasForeignKey(m => m.Mid);
                s.HasOne<Role>().WithMany().HasForeignKey(m => m.RoleID);
            });
        }





    }
}
