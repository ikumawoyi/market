using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class DoneWithTeamSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankadmins",
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
                    bankid = table.Column<int>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: true),
                    dateupdated = table.Column<DateTime>(nullable: true),
                    passport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankadmins", x => x.id);
                    table.ForeignKey(
                        name: "FK_bankadmins_banks_bankid",
                        column: x => x.bankid,
                        principalSchema: "callscheduler",
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bankadmins_bankid",
                schema: "callscheduler",
                table: "bankadmins",
                column: "bankid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankadmins",
                schema: "callscheduler");
        }
    }
}
