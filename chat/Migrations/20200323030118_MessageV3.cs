using Microsoft.EntityFrameworkCore.Migrations;

namespace chat.Migrations
{
    public partial class MessageV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_aspnetusersId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_aspnetusersId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "aspnetusersId",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Message",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Message");

            migrationBuilder.AddColumn<string>(
                name: "aspnetusersId",
                table: "Message",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_aspnetusersId",
                table: "Message",
                column: "aspnetusersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_aspnetusersId",
                table: "Message",
                column: "aspnetusersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
