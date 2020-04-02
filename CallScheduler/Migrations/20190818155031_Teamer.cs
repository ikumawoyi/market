using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class Teamer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isteamlead",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.DropColumn(
                name: "zone",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.AddColumn<int>(
                name: "teamleadid",
                schema: "callscheduler",
                table: "engineers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "teamleads",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstname = table.Column<string>(nullable: true),
                    othername = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true),
                    dateupdated = table.Column<DateTime>(nullable: true),
                    passport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamleads", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_engineers_teamleadid",
                schema: "callscheduler",
                table: "engineers",
                column: "teamleadid");

            migrationBuilder.AddForeignKey(
                name: "FK_engineers_teamleads_teamleadid",
                schema: "callscheduler",
                table: "engineers",
                column: "teamleadid",
                principalSchema: "callscheduler",
                principalTable: "teamleads",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_engineers_teamleads_teamleadid",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.DropTable(
                name: "teamleads",
                schema: "callscheduler");

            migrationBuilder.DropIndex(
                name: "IX_engineers_teamleadid",
                schema: "callscheduler",
                table: "engineers");

            migrationBuilder.DropColumn(
                name: "teamleadid",
                schema: "callscheduler",
                table: "engineers");

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
    }
}
