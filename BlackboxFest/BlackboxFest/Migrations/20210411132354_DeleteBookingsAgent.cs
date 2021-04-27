using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class DeleteBookingsAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_BookingAgents_BookingAgentId",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "BookingAgents");

            migrationBuilder.DropIndex(
                name: "IX_Artists_BookingAgentId",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "BookingAgentId",
                table: "TimeTables",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BookingAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAgents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_BookingAgentId",
                table: "Artists",
                column: "BookingAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_BookingAgents_BookingAgentId",
                table: "Artists",
                column: "BookingAgentId",
                principalTable: "BookingAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
