using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class FirstLocationS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "location",
                schema: "callscheduler",
                table: "machines",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "location",
                schema: "callscheduler",
                table: "machines",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
