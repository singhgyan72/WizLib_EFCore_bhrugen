using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLibDataAccess.Migrations
{
    public partial class ChangeTableAndColNameOfGenreTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "tbl_Genre");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tbl_Genre",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Genre",
                table: "tbl_Genre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Genre",
                table: "tbl_Genre");

            migrationBuilder.RenameTable(
                name: "tbl_Genre",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");
        }
    }
}
