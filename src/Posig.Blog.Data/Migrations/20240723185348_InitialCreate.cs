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
                    { new Guid("65de260f-fad3-4983-adbd-af4b69f16b14"), "Author 2", "Content for blog post 2", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7588), "Blog Post 2", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7589) },
                    { new Guid("e3d1d95b-3c1b-4794-b672-6902383c42de"), "Author 1", "Content for blog post 1", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7565), "Blog Post 1", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7584) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "BlogPostId", "CommentText", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("21617f22-c34e-4ed4-a46d-723e441317a9"), "Commenter 1", new Guid("e3d1d95b-3c1b-4794-b672-6902383c42de"), "This is a comment", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7595), new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7596) },
                    { new Guid("9219b544-e4df-402d-8d75-a844ee0907f4"), "Commenter 3", new Guid("65de260f-fad3-4983-adbd-af4b69f16b14"), "This is a comment on post 2", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7604), new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7605) },
                    { new Guid("ee8f5c03-91ff-4636-821c-fb03f352377d"), "Commenter 2", new Guid("e3d1d95b-3c1b-4794-b672-6902383c42de"), "This is another comment", new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7600), new DateTime(2024, 7, 23, 15, 53, 48, 500, DateTimeKind.Local).AddTicks(7601) }
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
