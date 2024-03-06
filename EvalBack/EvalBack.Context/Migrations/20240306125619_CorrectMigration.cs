using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvalBack.Context.Migrations
{
    /// <inheritdoc />
    public partial class CorrectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Evenements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evenements",
                table: "Evenements",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Evenements",
                table: "Evenements");

            migrationBuilder.RenameTable(
                name: "Evenements",
                newName: "Applications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");
        }
    }
}
