using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class SeedConcertSlots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "Id", "ArtistID", "DateID", "StageID", "TimeSlotID" },
                values: new object[,]
                {
                    { 47, null, 1, 1, 3 },
                    { 80, null, 2, 3, 9 },
                    { 81, null, 2, 3, 11 },
                    { 82, null, 2, 4, 2 },
                    { 83, null, 2, 4, 4 },
                    { 84, null, 2, 4, 6 },
                    { 85, null, 2, 4, 8 },
                    { 86, null, 2, 4, 10 },
                    { 87, null, 3, 1, 1 },
                    { 88, null, 3, 1, 3 },
                    { 89, null, 3, 1, 5 },
                    { 90, null, 3, 1, 7 },
                    { 91, null, 3, 1, 9 },
                    { 92, null, 3, 1, 11 },
                    { 93, null, 3, 2, 2 },
                    { 94, null, 3, 2, 4 },
                    { 95, null, 3, 2, 6 },
                    { 96, null, 3, 2, 8 },
                    { 97, null, 3, 2, 10 },
                    { 98, null, 3, 3, 1 },
                    { 99, null, 3, 3, 3 },
                    { 100, null, 3, 3, 5 },
                    { 101, null, 3, 3, 7 },
                    { 102, null, 3, 3, 9 },
                    { 103, null, 3, 3, 11 },
                    { 104, null, 3, 4, 2 },
                    { 105, null, 3, 4, 4 },
                    { 106, null, 3, 4, 6 },
                    { 79, null, 2, 3, 7 },
                    { 78, null, 2, 3, 5 },
                    { 77, null, 2, 3, 3 },
                    { 76, null, 2, 3, 1 },
                    { 48, null, 1, 1, 5 },
                    { 49, null, 1, 1, 7 },
                    { 50, null, 1, 1, 9 },
                    { 51, null, 1, 2, 4 },
                    { 52, null, 1, 2, 6 },
                    { 53, null, 1, 2, 8 },
                    { 54, null, 1, 2, 10 },
                    { 55, null, 1, 3, 1 },
                    { 56, null, 1, 3, 3 },
                    { 57, null, 1, 3, 5 },
                    { 58, null, 1, 3, 7 },
                    { 59, null, 1, 3, 9 },
                    { 60, null, 1, 3, 11 },
                    { 107, null, 3, 4, 8 },
                    { 61, null, 1, 4, 2 },
                    { 63, null, 1, 4, 6 },
                    { 64, null, 1, 4, 8 },
                    { 65, null, 1, 4, 10 },
                    { 66, null, 2, 1, 1 },
                    { 67, null, 2, 1, 3 },
                    { 68, null, 2, 1, 5 },
                    { 69, null, 2, 1, 7 },
                    { 70, null, 2, 1, 9 },
                    { 71, null, 2, 1, 11 },
                    { 72, null, 2, 2, 2 },
                    { 73, null, 2, 2, 4 },
                    { 74, null, 2, 2, 6 },
                    { 75, null, 2, 2, 10 },
                    { 62, null, 1, 4, 4 },
                    { 108, null, 3, 4, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "Id",
                keyValue: 108);
        }
    }
}
