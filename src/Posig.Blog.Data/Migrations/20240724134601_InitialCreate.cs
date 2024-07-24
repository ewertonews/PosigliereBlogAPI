using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Posig.Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    CommentText = table.Column<string>(type: "TEXT", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0d066420-c24e-4475-878b-37c590b5c9c9"), "Author 1", "Content for blog post 1", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5822), "Blog Post 1", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5834) },
                    { new Guid("48158052-7ae1-4c1f-bfc9-5c5ab2d808fb"), "Author 2", "Content for blog post 2", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5841), "Blog Post 2", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5842) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "BlogPostId", "CommentText", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5ad48bdb-8f22-47ce-bf09-851516cfdc54"), "Commenter 3", new Guid("48158052-7ae1-4c1f-bfc9-5c5ab2d808fb"), "This is a comment on post 2", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5892), new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5892) },
                    { new Guid("a0064eaa-8c20-4234-a1ee-ad84a8debbcd"), "Commenter 1", new Guid("0d066420-c24e-4475-878b-37c590b5c9c9"), "This is a comment", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5884), new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5885) },
                    { new Guid("b15d0946-9db5-449a-a860-5dd31c91bc41"), "Commenter 2", new Guid("0d066420-c24e-4475-878b-37c590b5c9c9"), "This is another comment", new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5888), new DateTime(2024, 7, 24, 10, 46, 1, 308, DateTimeKind.Local).AddTicks(5889) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_Title",
                table: "BlogPosts",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId",
                table: "Comments",
                column: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "BlogPosts");
        }
    }
}
