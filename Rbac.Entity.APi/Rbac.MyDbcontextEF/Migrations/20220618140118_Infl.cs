using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.MyDbcontextEF.Migrations
{
    public partial class Infl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmPwd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmEmile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDateTimeA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDateTimeA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIPA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdmID);
                });

            migrationBuilder.CreateTable(
                name: "Meun",
                columns: table => new
                {
                    Mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeunName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeunFatherId = table.Column<int>(type: "int", nullable: false),
                    MeunLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meun", x => x.Mid);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDateTimeA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDateTimeA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIPA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "RoleAdminisrationType",
                columns: table => new
                {
                    RoleAdminisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    AdmID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAdminisrationType", x => x.RoleAdminisID);
                });

            migrationBuilder.CreateTable(
                name: "MeunRileType",
                columns: table => new
                {
                    MeunRileTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mid = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeunRileType", x => x.MeunRileTypeId);
                    table.ForeignKey(
                        name: "FK_MeunRileType_Meun_Mid",
                        column: x => x.Mid,
                        principalTable: "Meun",
                        principalColumn: "Mid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeunRileType_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeunRileType_Mid",
                table: "MeunRileType",
                column: "Mid");

            migrationBuilder.CreateIndex(
                name: "IX_MeunRileType_RoleID",
                table: "MeunRileType",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "MeunRileType");

            migrationBuilder.DropTable(
                name: "RoleAdminisrationType");

            migrationBuilder.DropTable(
                name: "Meun");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
