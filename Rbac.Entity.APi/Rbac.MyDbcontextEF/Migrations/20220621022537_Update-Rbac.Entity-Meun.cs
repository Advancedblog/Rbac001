using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbac.MyDbcontextEF.Migrations
{
    public partial class UpdateRbacEntityMeun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MeunIsck",
                table: "Meun",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeunIsck",
                table: "Meun");
        }
    }
}
