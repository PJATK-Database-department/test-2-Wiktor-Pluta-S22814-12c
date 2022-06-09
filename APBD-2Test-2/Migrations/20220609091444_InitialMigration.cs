using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_2Test_2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Confectioneries",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerOne = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectioneries", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.IdClientOrder);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfectioneryClientOrders",
                columns: table => new
                {
                    IdClientOrder = table.Column<int>(type: "int", nullable: false),
                    IdConfectionery = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfectioneryClientOrders", x => new { x.IdClientOrder, x.IdConfectionery });
                    table.ForeignKey(
                        name: "FK_ConfectioneryClientOrders_ClientOrders_IdClientOrder",
                        column: x => x.IdClientOrder,
                        principalTable: "ClientOrders",
                        principalColumn: "IdClientOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfectioneryClientOrders_Confectioneries_IdConfectionery",
                        column: x => x.IdConfectionery,
                        principalTable: "Confectioneries",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Sebastian", "Nowak" },
                    { 3, "Jan", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Confectioneries",
                columns: new[] { "IdConfectionery", "Name", "PricePerOne" },
                values: new object[] { 1, "Confectionery1", 10.1f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "IdEmployee", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Adam", "Buksa" },
                    { 2, "Robert", "Lewandowski" },
                    { 3, "Adam", "Zalewski" }
                });

            migrationBuilder.InsertData(
                table: "ClientOrders",
                columns: new[] { "IdClientOrder", "Comments", "CompletionDate", "IdClient", "IdEmployee", "OrderDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2022, 6, 9, 11, 14, 44, 195, DateTimeKind.Local).AddTicks(2918) },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2022, 6, 9, 11, 14, 44, 196, DateTimeKind.Local).AddTicks(9655) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2022, 6, 9, 11, 14, 44, 196, DateTimeKind.Local).AddTicks(9623) },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, new DateTime(2022, 6, 9, 11, 14, 44, 196, DateTimeKind.Local).AddTicks(9650) }
                });

            migrationBuilder.InsertData(
                table: "ConfectioneryClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "Comments" },
                values: new object[] { 1, 1, 10, "some comments" });

            migrationBuilder.InsertData(
                table: "ConfectioneryClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "Comments" },
                values: new object[] { 2, 1, 20, "some comments" });

            migrationBuilder.InsertData(
                table: "ConfectioneryClientOrders",
                columns: new[] { "IdClientOrder", "IdConfectionery", "Amount", "Comments" },
                values: new object[] { 3, 1, 5, "some comments" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_IdClient",
                table: "ClientOrders",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_IdEmployee",
                table: "ClientOrders",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_ConfectioneryClientOrders_IdConfectionery",
                table: "ConfectioneryClientOrders",
                column: "IdConfectionery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfectioneryClientOrders");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "Confectioneries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
