using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleDatabaseBuilder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    SampleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    整合編號 = table.Column<string>(type: "TEXT", nullable: false),
                    樣品名稱 = table.Column<string>(type: "TEXT", nullable: false),
                    俗名 = table.Column<string>(type: "TEXT", nullable: false),
                    樣品英文名稱 = table.Column<string>(type: "TEXT", nullable: false),
                    內容物描述 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.SampleId);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisItemCatagory",
                columns: table => new
                {
                    AnalysisItemCatagoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    分析項分類 = table.Column<string>(type: "TEXT", nullable: false),
                    SampleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisItemCatagory", x => x.AnalysisItemCatagoryId);
                    table.ForeignKey(
                        name: "FK_AnalysisItemCatagory_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "SampleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisItem",
                columns: table => new
                {
                    AnalysisItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    分析項 = table.Column<string>(type: "TEXT", nullable: false),
                    單位 = table.Column<string>(type: "TEXT", nullable: false),
                    每100克含量 = table.Column<string>(type: "TEXT", nullable: false),
                    AnalysisItemCatagoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisItem", x => x.AnalysisItemId);
                    table.ForeignKey(
                        name: "FK_AnalysisItem_AnalysisItemCatagory_AnalysisItemCatagoryId",
                        column: x => x.AnalysisItemCatagoryId,
                        principalTable: "AnalysisItemCatagory",
                        principalColumn: "AnalysisItemCatagoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisItem_AnalysisItemCatagoryId",
                table: "AnalysisItem",
                column: "AnalysisItemCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisItemCatagory_SampleId",
                table: "AnalysisItemCatagory",
                column: "SampleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisItem");

            migrationBuilder.DropTable(
                name: "AnalysisItemCatagory");

            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
