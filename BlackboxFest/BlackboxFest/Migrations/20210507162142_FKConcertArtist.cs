using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class FKConcertArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConcertID",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ConcertID",
                table: "Artists",
                column: "ConcertID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Concerts_ConcertID",
                table: "Artists",
                column: "ConcertID",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Concerts_ConcertID",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ConcertID",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ConcertID",
                table: "Artists");
        }
    }
}
