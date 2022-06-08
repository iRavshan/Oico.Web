using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oico.Data.Migrations
{
    public partial class adsdsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thing_Products_ProductId",
                table: "Thing");

            migrationBuilder.DropIndex(
                name: "IX_Thing_ProductId",
                table: "Thing");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Thing");

            migrationBuilder.AddColumn<string>(
                name: "NameOfProduct",
                table: "Thing",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfProduct",
                table: "Thing");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Thing",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Thing_ProductId",
                table: "Thing",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thing_Products_ProductId",
                table: "Thing",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
