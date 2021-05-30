using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class SeedDataDateDayFestival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "Id", "ArtistID", "DateID", "StageID", "TimeSlotID" },
                values: new object[] { 46, null, 1, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 46);
        }
    }
}
