using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApplication.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    UserRegisterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserMobileNumber = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.UserRegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    FriendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendFirstName = table.Column<string>(nullable: true),
                    FriendLastName = table.Column<string>(nullable: true),
                    FriendMobileNumber = table.Column<string>(nullable: true),
                    FriendEmail = table.Column<string>(nullable: true),
                    UserRegisterId = table.Column<int>(nullable: false),
                    GetRegisterUserRegisterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.FriendId);
                    table.ForeignKey(
                        name: "FK_Friend_Register_GetRegisterUserRegisterId",
                        column: x => x.GetRegisterUserRegisterId,
                        principalTable: "Register",
                        principalColumn: "UserRegisterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_GetRegisterUserRegisterId",
                table: "Friend",
                column: "GetRegisterUserRegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
