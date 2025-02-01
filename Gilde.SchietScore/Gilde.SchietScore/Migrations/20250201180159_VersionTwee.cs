using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gilde.SchietScore.Migrations
{
    /// <inheritdoc />
    public partial class VersionTwee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_GameElements_GameElementId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Members_MemberId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Scores",
                newName: "WedstrijdId");

            migrationBuilder.RenameColumn(
                name: "GameElementId",
                table: "Scores",
                newName: "DeelnemerId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_MemberId",
                table: "Scores",
                newName: "IX_Scores_WedstrijdId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_GameElementId",
                table: "Scores",
                newName: "IX_Scores_DeelnemerId");

            migrationBuilder.CreateTable(
                name: "Leden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naam = table.Column<string>(type: "text", nullable: false),
                    IsSchietendLid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoresTwee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    GameElementId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoresTwee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoresTwee_GameElements_GameElementId",
                        column: x => x.GameElementId,
                        principalTable: "GameElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoresTwee_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wedstrijden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naam = table.Column<string>(type: "text", nullable: false),
                    StartDatum = table.Column<DateOnly>(type: "date", nullable: false),
                    EindDatum = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedstrijden", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoresTwee_GameElementId",
                table: "ScoresTwee",
                column: "GameElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoresTwee_MemberId",
                table: "ScoresTwee",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Leden_DeelnemerId",
                table: "Scores",
                column: "DeelnemerId",
                principalTable: "Leden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Wedstrijden_WedstrijdId",
                table: "Scores",
                column: "WedstrijdId",
                principalTable: "Wedstrijden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Leden_DeelnemerId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Wedstrijden_WedstrijdId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Leden");

            migrationBuilder.DropTable(
                name: "ScoresTwee");

            migrationBuilder.DropTable(
                name: "Wedstrijden");

            migrationBuilder.RenameColumn(
                name: "WedstrijdId",
                table: "Scores",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "DeelnemerId",
                table: "Scores",
                newName: "GameElementId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_WedstrijdId",
                table: "Scores",
                newName: "IX_Scores_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_DeelnemerId",
                table: "Scores",
                newName: "IX_Scores_GameElementId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Scores",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_GameElements_GameElementId",
                table: "Scores",
                column: "GameElementId",
                principalTable: "GameElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Members_MemberId",
                table: "Scores",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
