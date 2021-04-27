using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class UploadImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistGallery_Artists_ArtistId",
                table: "ArtistGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistGallery",
                table: "ArtistGallery");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "ArtistGallery");

            migrationBuilder.RenameTable(
                name: "ArtistGallery",
                newName: "ArtistsGallery");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistGallery_ArtistId",
                table: "ArtistsGallery",
                newName: "IX_ArtistsGallery_ArtistId");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ArtistsGallery",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistsGallery",
                table: "ArtistsGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsGallery_Artists_ArtistId",
                table: "ArtistsGallery",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsGallery_Artists_ArtistId",
                table: "ArtistsGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistsGallery",
                table: "ArtistsGallery");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ArtistsGallery");

            migrationBuilder.RenameTable(
                name: "ArtistsGallery",
                newName: "ArtistGallery");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistsGallery_ArtistId",
                table: "ArtistGallery",
                newName: "IX_ArtistGallery_ArtistId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "ArtistGallery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistGallery",
                table: "ArtistGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistGallery_Artists_ArtistId",
                table: "ArtistGallery",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
