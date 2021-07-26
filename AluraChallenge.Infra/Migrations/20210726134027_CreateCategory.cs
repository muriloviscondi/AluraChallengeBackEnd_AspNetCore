using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AluraChallenge.Infra.Migrations
{
    public partial class CreateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Video",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_CategoryId",
                table: "Video",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Video_CategoryId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Video");
        }
    }
}
