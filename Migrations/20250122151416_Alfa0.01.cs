using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class Alfa001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Availability",
                table: "Rooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 1,
                column: "Availability",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 2,
                column: "Availability",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 3,
                column: "Availability",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 4,
                column: "Availability",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 5,
                column: "Availability",
                value: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6,
                column: "Availability",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Availability",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 1,
                column: "Availability",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 2,
                column: "Availability",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 3,
                column: "Availability",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 4,
                column: "Availability",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 5,
                column: "Availability",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6,
                column: "Availability",
                value: 0);
        }
    }
}
