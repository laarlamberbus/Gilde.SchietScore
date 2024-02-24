using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gilde.SchietScore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CompetitionPropertyAddedIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitieDtoId",
                table: "Wedstrijden",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "EindDatum",
                table: "Wedstrijden",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDatum",
                table: "Wedstrijden",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "Datum",
                table: "Resultaten",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Competities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Wedstrijden_CompetitieDtoId",
                table: "Wedstrijden",
                column: "CompetitieDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wedstrijden_Competities_CompetitieDtoId",
                table: "Wedstrijden",
                column: "CompetitieDtoId",
                principalTable: "Competities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wedstrijden_Competities_CompetitieDtoId",
                table: "Wedstrijden");

            migrationBuilder.DropIndex(
                name: "IX_Wedstrijden_CompetitieDtoId",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "CompetitieDtoId",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "EindDatum",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "StartDatum",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Resultaten");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Competities");
        }
    }
}
