using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SourceId",
                table: "News",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_SourceId",
                table: "News",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Source_SourceId",
                table: "News",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Source_SourceId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropIndex(
                name: "IX_News_SourceId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "News");
        }
    }
}
