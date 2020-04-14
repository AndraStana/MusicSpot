using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarArtistsRelationship_Artists_FirstArtistId",
                table: "SimilarArtistsRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarArtistsRelationship_Artists_SecondArtistId",
                table: "SimilarArtistsRelationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimilarArtistsRelationship",
                table: "SimilarArtistsRelationship");

            migrationBuilder.RenameTable(
                name: "SimilarArtistsRelationship",
                newName: "SimilarArtistsRelationships");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarArtistsRelationship_SecondArtistId",
                table: "SimilarArtistsRelationships",
                newName: "IX_SimilarArtistsRelationships_SecondArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarArtistsRelationship_FirstArtistId",
                table: "SimilarArtistsRelationships",
                newName: "IX_SimilarArtistsRelationships_FirstArtistId");

            migrationBuilder.AddColumn<string>(
                name: "UrlPicture",
                table: "Albums",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimilarArtistsRelationships",
                table: "SimilarArtistsRelationships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarArtistsRelationships_Artists_FirstArtistId",
                table: "SimilarArtistsRelationships",
                column: "FirstArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarArtistsRelationships_Artists_SecondArtistId",
                table: "SimilarArtistsRelationships",
                column: "SecondArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarArtistsRelationships_Artists_FirstArtistId",
                table: "SimilarArtistsRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarArtistsRelationships_Artists_SecondArtistId",
                table: "SimilarArtistsRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimilarArtistsRelationships",
                table: "SimilarArtistsRelationships");

            migrationBuilder.DropColumn(
                name: "UrlPicture",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "SimilarArtistsRelationships",
                newName: "SimilarArtistsRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarArtistsRelationships_SecondArtistId",
                table: "SimilarArtistsRelationship",
                newName: "IX_SimilarArtistsRelationship_SecondArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarArtistsRelationships_FirstArtistId",
                table: "SimilarArtistsRelationship",
                newName: "IX_SimilarArtistsRelationship_FirstArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimilarArtistsRelationship",
                table: "SimilarArtistsRelationship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarArtistsRelationship_Artists_FirstArtistId",
                table: "SimilarArtistsRelationship",
                column: "FirstArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarArtistsRelationship_Artists_SecondArtistId",
                table: "SimilarArtistsRelationship",
                column: "SecondArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
