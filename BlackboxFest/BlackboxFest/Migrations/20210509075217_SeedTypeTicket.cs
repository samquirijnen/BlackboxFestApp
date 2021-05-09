using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class SeedTypeTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TypeTickets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "TypeTickets",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Weekend", 180.0 });

            migrationBuilder.InsertData(
                table: "TypeTickets",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Day", 80.0 });

            migrationBuilder.InsertData(
                table: "TypeTickets",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Camping", 15.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeTickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeTickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeTickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TypeTickets");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tickets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
