using Microsoft.EntityFrameworkCore.Migrations;

namespace chat.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connection_AspNetUsers_UserDataId",
                table: "Connection");

            migrationBuilder.DropIndex(
                name: "IX_Connection_UserDataId",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "Connection");

            migrationBuilder.CreateTable(
                name: "ApplicationUserConnection",
                columns: table => new
                {
                    ApplicationUserID = table.Column<string>(nullable: false),
                    ConnectionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserConnection", x => new { x.ConnectionID, x.ApplicationUserID });
                    table.ForeignKey(
                        name: "FK_ApplicationUserConnection_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserConnection_Connection_ConnectionID",
                        column: x => x.ConnectionID,
                        principalTable: "Connection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserConnection_ApplicationUserID",
                table: "ApplicationUserConnection",
                column: "ApplicationUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserConnection");

            migrationBuilder.AddColumn<string>(
                name: "UserDataId",
                table: "Connection",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserDataId",
                table: "Connection",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connection_AspNetUsers_UserDataId",
                table: "Connection",
                column: "UserDataId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
