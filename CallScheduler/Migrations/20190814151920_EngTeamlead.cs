using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class EngTeamlead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supervisor",
                schema: "callscheduler",
                table: "initiatedcalls");

            migrationBuilder.DropColumn(
                name: "supervisor",
                schema: "callscheduler",
                table: "calls");

            migrationBuilder.AddColumn<string>(
                name: "teamlead",
                schema: "callscheduler",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "teamlead",
                schema: "callscheduler",
                table: "engineers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teamlead",
                schema: "callscheduler",
                table: "users");

            migrationBuilder.DropColumn(
                name: "teamlead",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.AddColumn<string>(
                name: "supervisor",
                schema: "callscheduler",
                table: "initiatedcalls",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "supervisor",
                schema: "callscheduler",
                table: "calls",
                nullable: true);
        }
    }
}
