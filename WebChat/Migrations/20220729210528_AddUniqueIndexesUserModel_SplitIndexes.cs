using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebChat.Migrations
{
    public partial class AddUniqueIndexesUserModel_SplitIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName_Login",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Login",
                table: "Users",
                columns: new[] { "UserName", "Login" },
                unique: true);
        }
    }
}
