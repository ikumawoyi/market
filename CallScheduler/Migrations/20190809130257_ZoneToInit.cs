using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class ZoneToInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "zone",
                schema: "callscheduler",
                table: "initiatedcalls",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "zone",
                schema: "callscheduler",
                table: "initiatedcalls");
        }
    }
}
