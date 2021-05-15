using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboxFest.Migrations
{
    public partial class AddShopcartModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tickets_TicketId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TicketId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "TicketOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingsDate = table.Column<DateTime>(nullable: false),
                    CustomUserID = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrders_AspNetUsers_CustomUserID",
                        column: x => x.CustomUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketShopCarts",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomUserID = table.Column<string>(nullable: true),
                    TypeTicketID = table.Column<int>(nullable: false),
                    CountTypeTickets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketShopCarts", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_TicketShopCarts_AspNetUsers_CustomUserID",
                        column: x => x.CustomUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketShopCarts_TypeTickets_TypeTicketID",
                        column: x => x.TypeTicketID,
                        principalTable: "TypeTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketOrderId = table.Column<int>(nullable: false),
                    TypeTicketId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrderDetails_TicketOrders_TicketOrderId",
                        column: x => x.TicketOrderId,
                        principalTable: "TicketOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketOrderDetails_TypeTickets_TypeTicketId",
                        column: x => x.TypeTicketId,
                        principalTable: "TypeTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrderDetails_TicketOrderId",
                table: "TicketOrderDetails",
                column: "TicketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrderDetails_TypeTicketId",
                table: "TicketOrderDetails",
                column: "TypeTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrders_CustomUserID",
                table: "TicketOrders",
                column: "CustomUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketShopCarts_CustomUserID",
                table: "TicketShopCarts",
                column: "CustomUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketShopCarts_TypeTicketID",
                table: "TicketShopCarts",
                column: "TypeTicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketOrderDetails");

            migrationBuilder.DropTable(
                name: "TicketShopCarts");

            migrationBuilder.DropTable(
                name: "TicketOrders");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeTicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_TypeTickets_TypeTicketId",
                        column: x => x.TypeTicketId,
                        principalTable: "TypeTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TicketId",
                table: "AspNetUsers",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeTicketId",
                table: "Tickets",
                column: "TypeTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tickets_TicketId",
                table: "AspNetUsers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
