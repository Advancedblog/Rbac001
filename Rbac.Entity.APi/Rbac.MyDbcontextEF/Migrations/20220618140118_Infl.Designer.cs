// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rbac.MyDbcontextEF;

namespace Rbac.MyDbcontextEF.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220618140118_Infl")]
    partial class Infl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rbac.Entity.Administrators", b =>
                {
                    b.Property<int>("AdmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTimeA")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdmEmile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdmPwd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginDateTimeA")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLoginIPA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdmID");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Rbac.Entity.Meun", b =>
                {
                    b.Property<int>("Mid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeunFatherId")
                        .HasColumnType("int");

                    b.Property<string>("MeunLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeunName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Mid");

                    b.ToTable("Meun");
                });

            modelBuilder.Entity("Rbac.Entity.MeunRileType", b =>
                {
                    b.Property<int>("MeunRileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mid")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("MeunRileTypeId");

                    b.HasIndex("Mid");

                    b.HasIndex("RoleID");

                    b.ToTable("MeunRileType");
                });

            modelBuilder.Entity("Rbac.Entity.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDateTimeA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastLoginDateTimeA")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLoginIPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Rbac.Entity.RoleAdminisrationType", b =>
                {
                    b.Property<int>("RoleAdminisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdmID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("RoleAdminisID");

                    b.ToTable("RoleAdminisrationType");
                });

            modelBuilder.Entity("Rbac.Entity.MeunRileType", b =>
                {
                    b.HasOne("Rbac.Entity.Meun", "Meun")
                        .WithMany()
                        .HasForeignKey("Mid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rbac.Entity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meun");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
