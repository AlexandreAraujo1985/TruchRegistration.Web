using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckRegistration.Infra.Data.Migrations
{
    public partial class Alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_truck",
                table: "tb_truck",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_truck",
                table: "tb_truck");
        }
    }
}
