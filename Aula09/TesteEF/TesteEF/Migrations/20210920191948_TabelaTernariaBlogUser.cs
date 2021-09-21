using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class TabelaTernariaBlogUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TB_BLOG_USER",
                columns: table => new
                {
                    ID_BLOG_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    ID_BLOG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BLOG_USER", x => x.ID_BLOG_USER);
                    table.ForeignKey(
                        name: "FK_TB_BLOG_USER_TB_BLOG_ID_BLOG",
                        column: x => x.ID_BLOG,
                        principalTable: "TB_BLOG",
                        principalColumn: "ID_BLOG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_BLOG_USER_TB_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "TB_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_BLOG_USER_ID_BLOG",
                table: "TB_BLOG_USER",
                column: "ID_BLOG");

            migrationBuilder.CreateIndex(
                name: "IX_TB_BLOG_USER_ID_USER",
                table: "TB_BLOG_USER",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BLOG_USER");

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
    }
}
