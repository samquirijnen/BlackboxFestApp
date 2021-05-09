using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class CreateTimeSlotAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Concerts");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotID",
                table: "Concerts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "Hour" },
                values: new object[,]
                {
                    { 1, "12.00-13.30" },
                    { 2, "12.30-14.00" },
                    { 3, "14.00-15.30" },
                    { 4, "14.30-16.00" },
                    { 5, "16.00-17.30" },
                    { 6, "16.30-18.00" },
                    { 7, "18.00-19.30" },
                    { 8, "18.30-20.00" },
                    { 9, "20.00-21.30" },
                    { 10, "20.30-22.00" },
                    { 11, "22.00-23.30" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_TimeSlotID",
                table: "Concerts",
                column: "TimeSlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_TimeSlot_TimeSlotID",
                table: "Concerts",
                column: "TimeSlotID",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_TimeSlot_TimeSlotID",
                table: "Concerts");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_TimeSlotID",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "TimeSlotID",
                table: "Concerts");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginTime",
                table: "Concerts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Concerts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
