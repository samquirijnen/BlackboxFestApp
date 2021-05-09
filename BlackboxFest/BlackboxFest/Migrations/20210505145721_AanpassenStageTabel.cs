using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class AanpassenStageTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Stages_StageId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Stages");

            migrationBuilder.RenameColumn(
                name: "StageId",
                table: "Concerts",
                newName: "StageID");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_StageId",
                table: "Concerts",
                newName: "IX_Concerts_StageID");

            migrationBuilder.AlterColumn<int>(
                name: "StageID",
                table: "Concerts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Stages_StageID",
                table: "Concerts",
                column: "StageID",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Stages_StageID",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "StageID",
                table: "Concerts",
                newName: "StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_StageID",
                table: "Concerts",
                newName: "IX_Concerts_StageId");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "Stages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StageId",
                table: "Concerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Stages_StageId",
                table: "Concerts",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
