using Microsoft.EntityFrameworkCore.Migrations;

namespace Oico.Data.Migrations
{
    public partial class DeleteNumberOfBoxesColumnFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfBoxes",
                table: "Products",
                newName: "CountOfProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountOfProduct",
                table: "Products",
                newName: "NumberOfBoxes");
        }
    }
}
