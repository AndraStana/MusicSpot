using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendship_AspNetUsers_FirstFriendId1",
                table: "Friendship");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendship_AspNetUsers_SecondFriendId1",
                table: "Friendship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship");

            migrationBuilder.RenameTable(
                name: "Friendship",
                newName: "Friendships");

            migrationBuilder.RenameIndex(
                name: "IX_Friendship_SecondFriendId1",
                table: "Friendships",
                newName: "IX_Friendships_SecondFriendId1");

            migrationBuilder.RenameIndex(
                name: "IX_Friendship_FirstFriendId1",
                table: "Friendships",
                newName: "IX_Friendships_FirstFriendId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_FirstFriendId1",
                table: "Friendships",
                column: "FirstFriendId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_SecondFriendId1",
                table: "Friendships",
                column: "SecondFriendId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_FirstFriendId1",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_SecondFriendId1",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships");

            migrationBuilder.RenameTable(
                name: "Friendships",
                newName: "Friendship");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_SecondFriendId1",
                table: "Friendship",
                newName: "IX_Friendship_SecondFriendId1");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_FirstFriendId1",
                table: "Friendship",
                newName: "IX_Friendship_FirstFriendId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendship_AspNetUsers_FirstFriendId1",
                table: "Friendship",
                column: "FirstFriendId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendship_AspNetUsers_SecondFriendId1",
                table: "Friendship",
                column: "SecondFriendId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
