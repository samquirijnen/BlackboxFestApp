using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class FkArtistIDInConcert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Concerts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ArtistID",
                table: "Concerts",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Artists_ArtistID",
                table: "Concerts",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Artists_ArtistID",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_ArtistID",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Concerts");

            migrationBuilder.AddColumn<int>(
                name: "ConcertID",
                table: "Artists",
                type: "int",
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
    }
}
