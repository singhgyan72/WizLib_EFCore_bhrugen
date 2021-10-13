using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLibDataAccess.Migrations
{
    public partial class ChangeTblAndColNameTocategoriesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "tbl_Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_Categories",
                newName: "CategoryName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Categories",
                table: "tbl_Categories",
                column: "Category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Categories",
                table: "tbl_Categories");

            migrationBuilder.RenameTable(
                name: "tbl_Categories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Category_Id");
        }
    }
}
