using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gilde.SchietScore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CompetitieIsAfgerond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAfgerond",
                table: "Competities",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAfgerond",
                table: "Competities");
        }
    }
}
