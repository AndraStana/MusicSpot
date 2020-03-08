using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PopularityRankingId",
                table: "Songs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PopularityRanking",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopularityRanking", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PopularityRankingId",
                table: "Songs",
                column: "PopularityRankingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PopularityRanking_PopularityRankingId",
                table: "Songs",
                column: "PopularityRankingId",
                principalTable: "PopularityRanking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PopularityRanking_PopularityRankingId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "PopularityRanking");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PopularityRankingId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PopularityRankingId",
                table: "Songs");
        }
    }
}
