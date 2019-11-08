using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManyToManyTest.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Create = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Update = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Delete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Create = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Update = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Delete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Create = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Update = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    Delete = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProductId",
                table: "Users",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
