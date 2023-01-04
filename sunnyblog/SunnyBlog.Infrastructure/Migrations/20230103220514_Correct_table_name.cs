using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunnyBlog.Infrastructure.Migrations
{
    public partial class Correct_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_id",
                table: "category");

            migrationBuilder.DropColumn(
                name: "content",
                table: "category");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "category");

            migrationBuilder.DropColumn(
                name: "create_time",
                table: "category");

            migrationBuilder.DropColumn(
                name: "del_flag",
                table: "category");

            migrationBuilder.DropColumn(
                name: "is_comment",
                table: "category");

            migrationBuilder.DropColumn(
                name: "is_top",
                table: "category");

            migrationBuilder.DropColumn(
                name: "status",
                table: "category");

            migrationBuilder.DropColumn(
                name: "summary",
                table: "category");

            migrationBuilder.DropColumn(
                name: "thumbnail",
                table: "category");

            migrationBuilder.DropColumn(
                name: "title",
                table: "category");

            migrationBuilder.DropColumn(
                name: "update_time",
                table: "category");

            migrationBuilder.DropColumn(
                name: "view_count",
                table: "category");

            migrationBuilder.DropColumn(
                name: "description",
                table: "article");

            migrationBuilder.DropColumn(
                name: "name",
                table: "article");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "category",
                newName: "pid");

            migrationBuilder.RenameColumn(
                name: "pid",
                table: "article",
                newName: "update_by");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "category",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "category",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

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
                comment: "status (true: published, false: draft)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "category");

            migrationBuilder.DropColumn(
                name: "name",
                table: "category");

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
                name: "pid",
                table: "category",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "article",
                newName: "pid");

            migrationBuilder.AddColumn<long>(
                name: "category_id",
                table: "category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "category",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_time",
                table: "category",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "del_flag",
                table: "category",
                type: "int",
                nullable: false,
                defaultValueSql: "'0'",
                comment: "delete flag(0 not deleted，1 deleted)");

            migrationBuilder.AddColumn<bool>(
                name: "is_comment",
                table: "category",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "true",
                comment: "Allow comment");

            migrationBuilder.AddColumn<bool>(
                name: "is_top",
                table: "category",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: true,
                comment: "is top");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "category",
                type: "tinyint(1)",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "true",
                comment: "status (true: published, false: draft)");

            migrationBuilder.AddColumn<string>(
                name: "summary",
                table: "category",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "article summary",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "thumbnail",
                table: "category",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "缩略图",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "category",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                comment: "标题",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "update_time",
                table: "category",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "view_count",
                table: "category",
                type: "bigint",
                nullable: false,
                defaultValueSql: "'0'");

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
        }
    }
}
