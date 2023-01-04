using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunnyBlog.Infrastructure.Migrations
{
    public partial class category_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_id",
                table: "article");

            migrationBuilder.DropColumn(
                name: "content",
                table: "article");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "article");

            migrationBuilder.DropColumn(
                name: "create_time",
                table: "article");

            migrationBuilder.DropColumn(
                name: "del_flag",
                table: "article");

            migrationBuilder.DropColumn(
                name: "is_comment",
                table: "article");

            migrationBuilder.DropColumn(
                name: "is_top",
                table: "article");

            migrationBuilder.DropColumn(
                name: "status",
                table: "article");

            migrationBuilder.DropColumn(
                name: "summary",
                table: "article");

            migrationBuilder.DropColumn(
                name: "thumbnail",
                table: "article");

            migrationBuilder.DropColumn(
                name: "title",
                table: "article");

            migrationBuilder.DropColumn(
                name: "update_time",
                table: "article");

            migrationBuilder.DropColumn(
                name: "view_count",
                table: "article");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "article",
                newName: "pid");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "article",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "article",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "标题", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    summary = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "article summary", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    thumbnail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "缩略图", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_top = table.Column<bool>(type: "tinyint(1)", maxLength: 1, nullable: true, comment: "is top"),
                    status = table.Column<bool>(type: "tinyint(1)", maxLength: 1, nullable: false, defaultValueSql: "true", comment: "status (true: published, false: draft)"),
                    view_count = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "'0'"),
                    is_comment = table.Column<bool>(type: "tinyint(1)", maxLength: 1, nullable: false, defaultValueSql: "true", comment: "Allow comment"),
                    create_by = table.Column<long>(type: "bigint", nullable: true),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_by = table.Column<long>(type: "bigint", nullable: true),
                    update_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    del_flag = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'0'", comment: "delete flag(0 not deleted，1 deleted)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                },
                comment: "article table")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropColumn(
                name: "description",
                table: "article");

            migrationBuilder.DropColumn(
                name: "name",
                table: "article");

            migrationBuilder.RenameColumn(
                name: "pid",
                table: "article",
                newName: "update_by");

            migrationBuilder.AddColumn<long>(
                name: "category_id",
                table: "article",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "article",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "article",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_time",
                table: "article",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "del_flag",
                table: "article",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'",
                comment: "delete flag(0 not deleted，1 deleted)");

            migrationBuilder.AddColumn<bool>(
                name: "is_comment",
                table: "article",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "true",
                comment: "Allow comment");

            migrationBuilder.AddColumn<bool>(
                name: "is_top",
                table: "article",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: true,
                comment: "is top");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "article",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "true",
                comment: "状态（0已发布，1草稿）");

            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "article",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "article summary",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "thumbnail",
                table: "article",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "缩略图",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "article",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                comment: "标题",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_time",
                table: "article",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "view_count",
                table: "article",
                type: "bigint",
                nullable: false,
                defaultValueSql: "'0'");
        }
    }
}
