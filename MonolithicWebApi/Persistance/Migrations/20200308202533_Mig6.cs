using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstFriendId = table.Column<Guid>(nullable: false),
                    SecondFriendId = table.Column<Guid>(nullable: false),
                    FirstFriendId1 = table.Column<string>(nullable: true),
                    SecondFriendId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_FirstFriendId1",
                        column: x => x.FirstFriendId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendship_AspNetUsers_SecondFriendId1",
                        column: x => x.SecondFriendId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_FirstFriendId1",
                table: "Friendship",
                column: "FirstFriendId1");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_SecondFriendId1",
                table: "Friendship",
                column: "SecondFriendId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship");
        }
    }
}
