using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class ForeignKeyUserBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_USER_BLOG",
                table: "TB_BLOG",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_BLOG_ID_USER_BLOG",
                table: "TB_BLOG",
                column: "ID_USER_BLOG");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BLOG_TB_USER_ID_USER_BLOG",
                table: "TB_BLOG",
                column: "ID_USER_BLOG",
                principalTable: "TB_USER",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BLOG_TB_USER_ID_USER_BLOG",
                table: "TB_BLOG");

            migrationBuilder.DropIndex(
                name: "IX_TB_BLOG_ID_USER_BLOG",
                table: "TB_BLOG");

            migrationBuilder.DropColumn(
                name: "ID_USER_BLOG",
                table: "TB_BLOG");
        }
    }
}
