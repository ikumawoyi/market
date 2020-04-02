using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class Mod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "leadcode",
                schema: "callscheduler",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "leadcode",
                schema: "callscheduler",
                table: "teamleads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "leadcode",
                schema: "callscheduler",
                table: "users");

            migrationBuilder.DropColumn(
                name: "leadcode",
                schema: "callscheduler",
                table: "teamleads");
        }
    }
}
