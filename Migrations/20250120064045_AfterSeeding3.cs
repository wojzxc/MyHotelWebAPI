using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class AfterSeeding3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 1,
                column: "Name",
                value: "Pokój 100");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 2,
                column: "Name",
                value: "Pokój 110");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 3,
                column: "Name",
                value: "Pokój 120");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 4,
                column: "Name",
                value: "Pokój 310");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 5,
                column: "Name",
                value: "Pokój 212");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6,
                column: "Name",
                value: "Pokój 1008");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rooms");
        }
    }
}
