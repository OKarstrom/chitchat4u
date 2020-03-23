using Microsoft.EntityFrameworkCore.Migrations;

namespace chat.Migrations
{
    public partial class UpdateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Connection_ConnectionId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectionId",
                table: "Message",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Connection_ConnectionId",
                table: "Message",
                column: "ConnectionId",
                principalTable: "Connection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Connection_ConnectionId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "ConnectionId",
                table: "Message",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Connection_ConnectionId",
                table: "Message",
                column: "ConnectionId",
                principalTable: "Connection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
