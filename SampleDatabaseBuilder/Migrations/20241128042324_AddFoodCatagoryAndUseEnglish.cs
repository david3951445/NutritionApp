using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleDatabaseBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodCatagoryAndUseEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "樣品英文名稱",
                table: "Samples",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "樣品名稱",
                table: "Samples",
                newName: "FoodCatagory");

            migrationBuilder.RenameColumn(
                name: "整合編號",
                table: "Samples",
                newName: "EnglishName");

            migrationBuilder.RenameColumn(
                name: "內容物描述",
                table: "Samples",
                newName: "ContentDescription");

            migrationBuilder.RenameColumn(
                name: "俗名",
                table: "Samples",
                newName: "CommonName");

            migrationBuilder.RenameColumn(
                name: "分析項分類",
                table: "AnalysisItemCatagory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "每100克含量",
                table: "AnalysisItem",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "單位",
                table: "AnalysisItem",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "分析項",
                table: "AnalysisItem",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "SampleId",
                table: "Samples",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "SampleId",
                table: "AnalysisItemCatagory",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Samples",
                newName: "樣品英文名稱");

            migrationBuilder.RenameColumn(
                name: "FoodCatagory",
                table: "Samples",
                newName: "樣品名稱");

            migrationBuilder.RenameColumn(
                name: "EnglishName",
                table: "Samples",
                newName: "整合編號");

            migrationBuilder.RenameColumn(
                name: "ContentDescription",
                table: "Samples",
                newName: "內容物描述");

            migrationBuilder.RenameColumn(
                name: "CommonName",
                table: "Samples",
                newName: "俗名");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AnalysisItemCatagory",
                newName: "分析項分類");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AnalysisItem",
                newName: "每100克含量");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "AnalysisItem",
                newName: "單位");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AnalysisItem",
                newName: "分析項");

            migrationBuilder.AlterColumn<int>(
                name: "SampleId",
                table: "Samples",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "SampleId",
                table: "AnalysisItemCatagory",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
