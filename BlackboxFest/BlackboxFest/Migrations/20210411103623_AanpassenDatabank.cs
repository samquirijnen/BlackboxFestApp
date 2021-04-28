using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class AanpassenDatabank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_TimeTables_ArtistId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ArtistId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Artists",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ArtistId",
                table: "TimeTables",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Artists_ArtistId",
                table: "TimeTables",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Artists_ArtistId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ArtistId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Artists");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "News",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Artists",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistId",
                table: "Artists",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_TimeTables_ArtistId",
                table: "Artists",
                column: "ArtistId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
