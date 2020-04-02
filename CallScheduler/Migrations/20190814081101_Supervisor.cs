using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class Supervisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zone",
                schema: "callscheduler",
                table: "initiatedcalls",
                newName: "supervisor");

            migrationBuilder.AddColumn<string>(
                name: "supervisor",
                schema: "callscheduler",
                table: "calls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supervisor",
                schema: "callscheduler",
                table: "calls");

            migrationBuilder.RenameColumn(
                name: "supervisor",
                schema: "callscheduler",
                table: "initiatedcalls",
                newName: "zone");
        }
    }
}
