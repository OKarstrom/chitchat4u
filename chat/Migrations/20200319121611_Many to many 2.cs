using Microsoft.EntityFrameworkCore.Migrations;

namespace chat.Migrations
{
    public partial class Manytomany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserConnection_AspNetUsers_ApplicationUserID",
                table: "ApplicationUserConnection");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserConnection_Connection_ConnectionID",
                table: "ApplicationUserConnection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserConnection",
                table: "ApplicationUserConnection");

            migrationBuilder.RenameTable(
                name: "ApplicationUserConnection",
                newName: "UserConnections");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserConnection_ApplicationUserID",
                table: "UserConnections",
                newName: "IX_UserConnections_ApplicationUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConnections",
                table: "UserConnections",
                columns: new[] { "ConnectionID", "ApplicationUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserConnections_AspNetUsers_ApplicationUserID",
                table: "UserConnections",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConnections_Connection_ConnectionID",
                table: "UserConnections",
                column: "ConnectionID",
                principalTable: "Connection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserConnections_AspNetUsers_ApplicationUserID",
                table: "UserConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConnections_Connection_ConnectionID",
                table: "UserConnections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConnections",
                table: "UserConnections");

            migrationBuilder.RenameTable(
                name: "UserConnections",
                newName: "ApplicationUserConnection");

            migrationBuilder.RenameIndex(
                name: "IX_UserConnections_ApplicationUserID",
                table: "ApplicationUserConnection",
                newName: "IX_ApplicationUserConnection_ApplicationUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserConnection",
                table: "ApplicationUserConnection",
                columns: new[] { "ConnectionID", "ApplicationUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserConnection_AspNetUsers_ApplicationUserID",
                table: "ApplicationUserConnection",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserConnection_Connection_ConnectionID",
                table: "ApplicationUserConnection",
                column: "ConnectionID",
                principalTable: "Connection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
