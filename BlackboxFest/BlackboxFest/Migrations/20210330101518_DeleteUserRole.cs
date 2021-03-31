using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class DeleteUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetUsers_GetUserRoles_TicketId",
                table: "GetUsers");

            migrationBuilder.DropTable(
                name: "GetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "GetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "GetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetUserRoles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GetUsers_GetUserRoles_TicketId",
                table: "GetUsers",
                column: "TicketId",
                principalTable: "GetUserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
