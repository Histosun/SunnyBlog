using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunnyBlog.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "article",
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
                    status = table.Column<bool>(type: "tinyint(1)", maxLength: 1, nullable: false, defaultValueSql: "true", comment: "状态（0已发布，1草稿）"),
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
                    table.PrimaryKey("PK_article", x => x.id);
                },
                comment: "article table")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");
        }
    }
}
