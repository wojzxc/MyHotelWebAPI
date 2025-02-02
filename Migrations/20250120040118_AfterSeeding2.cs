using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHotelWebAPI.Migrations
{
    public partial class AfterSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Event_ID",
                keyValue: 1,
                column: "IsDone",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Events");
        }
    }
}
