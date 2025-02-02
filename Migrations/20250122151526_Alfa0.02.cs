using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class Alfa002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6,
                column: "Availability",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6,
                column: "Availability",
                value: false);
        }
    }
}
