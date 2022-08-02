using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebChat.Migrations
{
    public partial class AddUniqueIndexesUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Login",
                table: "Users",
                columns: new[] { "UserName", "Login" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName_Login",
                table: "Users");
        }
    }
}
