using Microsoft.EntityFrameworkCore.Migrations;

namespace TruckRegistration.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_truck_model",
                columns: table => new
                {
                    TruckModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_model = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck_model", x => x.TruckModelId);
                });

            migrationBuilder.CreateTable(
                name: "tb_truck",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year_manufacture = table.Column<int>(type: "int", nullable: false),
                    year_madel = table.Column<int>(type: "int", nullable: false),
                    TruckModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck", x => x.TruckId);
                    table.ForeignKey(
                        name: "FK_tb_truck_tb_truck_model_TruckModelId",
                        column: x => x.TruckModelId,
                        principalTable: "tb_truck_model",
                        principalColumn: "TruckModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_truck_TruckModelId",
                table: "tb_truck",
                column: "TruckModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_truck");

            migrationBuilder.DropTable(
                name: "tb_truck_model");
        }
    }
}
