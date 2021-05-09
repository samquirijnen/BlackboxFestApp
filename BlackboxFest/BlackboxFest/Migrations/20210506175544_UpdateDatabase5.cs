using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class UpdateDatabase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_TimeTables_ConcertId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_ConcertId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Concerts");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ConcertId",
                table: "TimeTables",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Concerts_ConcertId",
                table: "TimeTables",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Concerts_ConcertId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ConcertId",
                table: "TimeTables");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "Concerts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ConcertId",
                table: "Concerts",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_TimeTables_ConcertId",
                table: "Concerts",
                column: "ConcertId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
