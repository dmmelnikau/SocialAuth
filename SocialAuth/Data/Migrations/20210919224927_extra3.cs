using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialAuth.Data.Migrations
{
    public partial class extra3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "AspNetUsers",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AspNetUsers",
                newName: "status");
        }
    }
}
