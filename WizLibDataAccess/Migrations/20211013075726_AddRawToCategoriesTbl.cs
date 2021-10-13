using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLibDataAccess.Migrations
{
    public partial class AddRawToCategoriesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_Categories VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO tbl_Categories VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO tbl_Categories VALUES('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
