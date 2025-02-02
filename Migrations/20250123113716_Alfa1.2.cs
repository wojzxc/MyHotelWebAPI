using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class Alfa12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Position_ID", "Position_Type" },
                values: new object[] { 3, "Maintance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Position_ID",
                keyValue: 3);
        }
    }
}
