using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PopularityRanking_PopularityRankingId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PopularityRanking",
                table: "PopularityRanking");

            migrationBuilder.RenameTable(
                name: "PopularityRanking",
                newName: "PopularityRankings");

            migrationBuilder.AlterColumn<Guid>(
                name: "PopularityRankingId",
                table: "Songs",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PopularityRankings",
                table: "PopularityRankings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PopularityRankings_PopularityRankingId",
                table: "Songs",
                column: "PopularityRankingId",
                principalTable: "PopularityRankings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PopularityRankings_PopularityRankingId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PopularityRankings",
                table: "PopularityRankings");

            migrationBuilder.RenameTable(
                name: "PopularityRankings",
                newName: "PopularityRanking");

            migrationBuilder.AlterColumn<Guid>(
                name: "PopularityRankingId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PopularityRanking",
                table: "PopularityRanking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PopularityRanking_PopularityRankingId",
                table: "Songs",
                column: "PopularityRankingId",
                principalTable: "PopularityRanking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
