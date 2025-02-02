using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class AfterSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "On_Shift",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "Availaibility",
                table: "Rooms",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "Priotity",
                table: "Events",
                newName: "Priority");

            migrationBuilder.AlterColumn<string>(
                name: "On_Shift",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MoveOut",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MoveIn",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Postal_Code",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Client_ID", "Address", "Email", "Name", "Password", "Phone", "Postal_Code", "Type" },
                values: new object[,]
                {
                    { 1, "Warsaw, ul.Podluzna 5", "JanKowalski@gmail.com", "Jan Kowalski", "clientpass1", 123456789, "00-001", "Single" },
                    { 2, "Krakow, ul.Krakowska 10", "ANowak@gmail.com", "Anna Nowak", "clientpass2", 987654321, "30-200", "Group" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Hotel_ID", "Name" },
                values: new object[,]
                {
                    { 1, "Marriott" },
                    { 2, "DS1 Olimp" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Payment_ID", "Date", "Payment_type", "Price", "Status" },
                values: new object[,]
                {
                    { 1, "2025/1/17", "Card", 550, "Paid" },
                    { 2, "2025/1/18", "Cash", 100, "Waiting" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Position_ID", "Position_Type" },
                values: new object[,]
                {
                    { 1, "Receptionist" },
                    { 2, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Room_ID", "Availability", "Hotel_ID", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, 1, 350, "Single" },
                    { 2, 1, 1, 550, "Double" },
                    { 3, 0, 1, 800, "Apartment" },
                    { 4, 1, 2, 100, "Single" },
                    { 5, 0, 2, 150, "Double" },
                    { 6, 0, 2, 200, "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Staff_ID", "On_Shift", "Password", "Position_ID" },
                values: new object[,]
                {
                    { 1, "Day", "secret1", 2 },
                    { 2, "Night", "secret2", 2 },
                    { 3, "Day", "secret3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Event_ID", "Date", "Position_ID", "Priority", "Room_ID", "Type" },
                values: new object[,]
                {
                    { 1, "2025/1/14", 1, 1, 1, "Naprawa" },
                    { 2, "2025/1/18", 2, 3, 2, "Sprzątanie" },
                    { 3, "2025/1/20", 1, 2, 1, "Przegląd" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Reservation_ID", "Client_ID", "MoveIn", "MoveOut", "Payment_ID", "Room_ID", "Status" },
                values: new object[,]
                {
                    { 1, 1, "2025/1/10", "2025/1/17", 1, 2, "Confirmed" },
                    { 2, 2, "2025/2/1", "2025/2/9", 2, 4, "Pending" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Event_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Event_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Event_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Reservation_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Reservation_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Staff_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Staff_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Staff_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Client_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Client_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Payment_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Payment_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Position_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Position_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Room_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Hotel_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Hotel_ID",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Rooms",
                newName: "Availaibility");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Events",
                newName: "Priotity");

            migrationBuilder.AlterColumn<bool>(
                name: "On_Shift",
                table: "Staffs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MoveOut",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MoveIn",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "On_Shift",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "Events",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Postal_Code",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
