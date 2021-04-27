using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class KleineAanpassing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Artists_BookingAgentId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_BookingAgentId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "BookingAgentId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "BookingAgentId",
                table: "Artists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingAgentId",
                table: "TimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingAgentId",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_BookingAgentId",
                table: "TimeTables",
                column: "BookingAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Artists_BookingAgentId",
                table: "TimeTables",
                column: "BookingAgentId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
