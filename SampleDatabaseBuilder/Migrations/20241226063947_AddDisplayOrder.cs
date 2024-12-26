using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleDatabaseBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisItem_AnalysisItemCatagory_AnalysisItemCatagoryId",
                table: "AnalysisItem");

            migrationBuilder.DropTable(
                name: "AnalysisItemCatagory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnalysisItem",
                table: "AnalysisItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AnalysisItem");

            migrationBuilder.RenameTable(
                name: "AnalysisItem",
                newName: "AnalysisItems");

            migrationBuilder.RenameColumn(
                name: "FoodCatagory",
                table: "Samples",
                newName: "FoodCatagoryId");

            migrationBuilder.RenameColumn(
                name: "SampleId",
                table: "Samples",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "AnalysisItems",
                newName: "SampleId");

            migrationBuilder.RenameColumn(
                name: "AnalysisItemCatagoryId",
                table: "AnalysisItems",
                newName: "AnalysisItemInfoId");

            migrationBuilder.RenameColumn(
                name: "AnalysisItemId",
                table: "AnalysisItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AnalysisItem_AnalysisItemCatagoryId",
                table: "AnalysisItems",
                newName: "IX_AnalysisItems_AnalysisItemInfoId");

            migrationBuilder.AlterColumn<string>(
                name: "EnglishName",
                table: "Samples",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ContentDescription",
                table: "Samples",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                table: "Samples",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AnalysisItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnalysisItems",
                table: "AnalysisItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnalysisItemCatagoryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisItemCatagoryInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCatagories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCatagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisItemInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    AnalysisItemCatagoryInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisItemInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisItemInfos_AnalysisItemCatagoryInfos_AnalysisItemCatagoryInfoId",
                        column: x => x.AnalysisItemCatagoryInfoId,
                        principalTable: "AnalysisItemCatagoryInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samples_FoodCatagoryId",
                table: "Samples",
                column: "FoodCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisItems_SampleId",
                table: "AnalysisItems",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisItemInfos_AnalysisItemCatagoryInfoId",
                table: "AnalysisItemInfos",
                column: "AnalysisItemCatagoryInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisItems_AnalysisItemInfos_AnalysisItemInfoId",
                table: "AnalysisItems",
                column: "AnalysisItemInfoId",
                principalTable: "AnalysisItemInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisItems_Samples_SampleId",
                table: "AnalysisItems",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samples_FoodCatagories_FoodCatagoryId",
                table: "Samples",
                column: "FoodCatagoryId",
                principalTable: "FoodCatagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisItems_AnalysisItemInfos_AnalysisItemInfoId",
                table: "AnalysisItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisItems_Samples_SampleId",
                table: "AnalysisItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Samples_FoodCatagories_FoodCatagoryId",
                table: "Samples");

            migrationBuilder.DropTable(
                name: "AnalysisItemInfos");

            migrationBuilder.DropTable(
                name: "FoodCatagories");

            migrationBuilder.DropTable(
                name: "AnalysisItemCatagoryInfos");

            migrationBuilder.DropIndex(
                name: "IX_Samples_FoodCatagoryId",
                table: "Samples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnalysisItems",
                table: "AnalysisItems");

            migrationBuilder.DropIndex(
                name: "IX_AnalysisItems_SampleId",
                table: "AnalysisItems");

            migrationBuilder.RenameTable(
                name: "AnalysisItems",
                newName: "AnalysisItem");

            migrationBuilder.RenameColumn(
                name: "FoodCatagoryId",
                table: "Samples",
                newName: "FoodCatagory");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Samples",
                newName: "SampleId");

            migrationBuilder.RenameColumn(
                name: "SampleId",
                table: "AnalysisItem",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "AnalysisItemInfoId",
                table: "AnalysisItem",
                newName: "AnalysisItemCatagoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AnalysisItem",
                newName: "AnalysisItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AnalysisItems_AnalysisItemInfoId",
                table: "AnalysisItem",
                newName: "IX_AnalysisItem_AnalysisItemCatagoryId");

            migrationBuilder.AlterColumn<string>(
                name: "EnglishName",
                table: "Samples",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentDescription",
                table: "Samples",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                table: "Samples",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AnalysisItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AnalysisItem",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnalysisItem",
                table: "AnalysisItem",
                column: "AnalysisItemId");

            migrationBuilder.CreateTable(
                name: "AnalysisItemCatagory",
                columns: table => new
                {
                    AnalysisItemCatagoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SampleId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisItemCatagory_SampleId",
                table: "AnalysisItemCatagory",
                column: "SampleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisItem_AnalysisItemCatagory_AnalysisItemCatagoryId",
                table: "AnalysisItem",
                column: "AnalysisItemCatagoryId",
                principalTable: "AnalysisItemCatagory",
                principalColumn: "AnalysisItemCatagoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
