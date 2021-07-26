using Microsoft.EntityFrameworkCore.Migrations;

namespace AluraChallenge.Infra.Migrations
{
    public partial class AlterMapCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Category_CategoryId",
                table: "Video",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
