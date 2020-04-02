using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class TeamLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "zone",
                schema: "callscheduler",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isteamlead",
                schema: "callscheduler",
                table: "engineers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "zone",
                schema: "callscheduler",
                table: "engineers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "zone",
                schema: "callscheduler",
                table: "users");

            migrationBuilder.DropColumn(
                name: "isteamlead",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.DropColumn(
                name: "zone",
                schema: "callscheduler",
                table: "engineers");
        }
    }
}
