using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class RenameTableBlogColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "TB_BLOG");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_BLOG",
                newName: "DSC_BLOG");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "TB_BLOG",
                newName: "DT_CREATED");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_BLOG",
                newName: "ID_BLOG");

            migrationBuilder.AlterColumn<string>(
                name: "DSC_BLOG",
                table: "TB_BLOG",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_BLOG",
                table: "TB_BLOG",
                column: "ID_BLOG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_BLOG",
                table: "TB_BLOG");

            migrationBuilder.RenameTable(
                name: "TB_BLOG",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "DT_CREATED",
                table: "Blog",
                newName: "CreatedTimestamp");

            migrationBuilder.RenameColumn(
                name: "DSC_BLOG",
                table: "Blog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID_BLOG",
                table: "Blog",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");
        }
    }
}
