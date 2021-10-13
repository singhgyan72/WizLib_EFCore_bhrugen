﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLibDataAccess.Migrations
{
    public partial class AddBookDetailsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetail",
                table: "FluentBookDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail");

            migrationBuilder.RenameTable(
                name: "FluentBookDetail",
                newName: "FluentBookDetails");

            migrationBuilder.RenameTable(
                name: "BookDetail",
                newName: "BookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails",
                column: "BookDetail_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookDetails",
                table: "FluentBookDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails");

            migrationBuilder.RenameTable(
                name: "FluentBookDetails",
                newName: "FluentBookDetail");

            migrationBuilder.RenameTable(
                name: "BookDetails",
                newName: "BookDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookDetail",
                table: "FluentBookDetail",
                column: "BookDetail_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetail",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
