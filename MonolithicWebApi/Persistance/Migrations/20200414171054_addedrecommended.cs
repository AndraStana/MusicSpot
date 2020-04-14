using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedrecommended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarArtistsRelationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstArtistId = table.Column<Guid>(nullable: false),
                    SecondArtistId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarArtistsRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarArtistsRelationship_Artists_FirstArtistId",
                        column: x => x.FirstArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SimilarArtistsRelationship_Artists_SecondArtistId",
                        column: x => x.SecondArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarArtistsRelationship_FirstArtistId",
                table: "SimilarArtistsRelationship",
                column: "FirstArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarArtistsRelationship_SecondArtistId",
                table: "SimilarArtistsRelationship",
                column: "SecondArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarArtistsRelationship");
        }
    }
}
