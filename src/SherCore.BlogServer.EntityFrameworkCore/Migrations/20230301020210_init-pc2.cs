using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SherCore.BlogServer.Migrations
{
    public partial class initpc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppArticle_ArticleInfo_ArticleInfoId",
                table: "AppArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCategory",
                table: "AppCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppArticle",
                table: "AppArticle");

            migrationBuilder.RenameTable(
                name: "AppCategory",
                newName: "AppCategorys");

            migrationBuilder.RenameTable(
                name: "AppArticle",
                newName: "AppArticles");

            migrationBuilder.RenameIndex(
                name: "IX_AppArticle_ArticleInfoId",
                table: "AppArticles",
                newName: "IX_AppArticles_ArticleInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCategorys",
                table: "AppCategorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppArticles",
                table: "AppArticles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppArticles_ArticleInfo_ArticleInfoId",
                table: "AppArticles",
                column: "ArticleInfoId",
                principalTable: "ArticleInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppArticles_ArticleInfo_ArticleInfoId",
                table: "AppArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCategorys",
                table: "AppCategorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppArticles",
                table: "AppArticles");

            migrationBuilder.RenameTable(
                name: "AppCategorys",
                newName: "AppCategory");

            migrationBuilder.RenameTable(
                name: "AppArticles",
                newName: "AppArticle");

            migrationBuilder.RenameIndex(
                name: "IX_AppArticles_ArticleInfoId",
                table: "AppArticle",
                newName: "IX_AppArticle_ArticleInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCategory",
                table: "AppCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppArticle",
                table: "AppArticle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppArticle_ArticleInfo_ArticleInfoId",
                table: "AppArticle",
                column: "ArticleInfoId",
                principalTable: "ArticleInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
