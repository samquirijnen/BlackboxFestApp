using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class CreateDateDayFestival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Concerts");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "Concerts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DateDayFestival",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDayFestival", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DateDayFestival",
                columns: new[] { "Id", "Date" },
                values: new object[] { 1, "24/09/2021" });

            migrationBuilder.InsertData(
                table: "DateDayFestival",
                columns: new[] { "Id", "Date" },
                values: new object[] { 2, "25/09/2021" });

            migrationBuilder.InsertData(
                table: "DateDayFestival",
                columns: new[] { "Id", "Date" },
                values: new object[] { 3, "26/09/2021" });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_DateID",
                table: "Concerts",
                column: "DateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_DateDayFestival_DateID",
                table: "Concerts",
                column: "DateID",
                principalTable: "DateDayFestival",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_DateDayFestival_DateID",
                table: "Concerts");

            migrationBuilder.DropTable(
                name: "DateDayFestival");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_DateID",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "Concerts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Concerts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
