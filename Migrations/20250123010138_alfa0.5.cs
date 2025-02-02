using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class alfa05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Room_ID", "Availability", "Hotel_ID", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 7, true, 1, "Pokój 200", 350, "Single" },
                    { 8, true, 1, "Pokój 210", 550, "Double" },
                    { 9, true, 1, "Pokój 220", 800, "Apartment" },
                    { 10, true, 2, "Pokój 350", 100, "Single" },
                    { 11, true, 2, "Pokój 212", 150, "Double" },
                    { 12, true, 2, "Pokój 1008", 200, "Apartment" },
                    { 13, true, 1, "Pokój 200", 350, "Single" },
                    { 14, true, 1, "Pokój 410", 550, "Double" },
                    { 15, true, 1, "Pokój 420", 800, "Apartment" },
                    { 16, true, 2, "Pokój 450", 100, "Single" },
                    { 17, true, 2, "Pokój 512", 150, "Double" },
                    { 18, true, 2, "Pokój 1008", 200, "Apartment" },
                    { 19, true, 1, "Pokój 090", 350, "Single" },
                    { 20, true, 1, "Pokój 0960", 550, "Double" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 20);
        }
    }
}
