using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallScheduler.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "callscheduler");

            migrationBuilder.CreateTable(
                name: "assigners",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assignercode = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_assigners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audits",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(maxLength: 256, nullable: true),
                    entity = table.Column<string>(maxLength: 100, nullable: true),
                    entityid = table.Column<string>(maxLength: 50, nullable: true),
                    originalvalues = table.Column<string>(maxLength: 2000, nullable: true),
                    newvalues = table.Column<string>(maxLength: 2000, nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false),
                    user = table.Column<string>(maxLength: 100, nullable: true),
                    userid = table.Column<string>(maxLength: 50, nullable: true),
                    ipaddress = table.Column<string>(maxLength: 20, nullable: true),
                    scope = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "authorizations",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action = table.Column<string>(maxLength: 40, nullable: true),
                    entityid = table.Column<string>(maxLength: 50, nullable: true),
                    entitytype = table.Column<string>(maxLength: 30, nullable: true),
                    requester = table.Column<string>(maxLength: 30, nullable: true),
                    requesttimestamp = table.Column<DateTime>(nullable: true),
                    isapproved = table.Column<bool>(nullable: true),
                    authorizer = table.Column<string>(maxLength: 25, nullable: true),
                    description = table.Column<string>(maxLength: 150, nullable: true),
                    authorizetimestamp = table.Column<DateTime>(nullable: true),
                    entityjson = table.Column<string>(maxLength: 2000, nullable: true),
                    declinereason = table.Column<string>(maxLength: 200, nullable: true),
                    agent = table.Column<string>(maxLength: 30, nullable: true),
                    audittype = table.Column<int>(nullable: false),
                    status = table.Column<string>(maxLength: 50, nullable: true),
                    ipaddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banks",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bankcode = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    shortname = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    rcno = table.Column<string>(maxLength: 25, nullable: true),
                    banklogo = table.Column<string>(nullable: true),
                    slastarttime = table.Column<string>(nullable: true),
                    slaendtime = table.Column<string>(nullable: true),
                    sladuration = table.Column<int>(nullable: false),
                    slaamount = table.Column<decimal>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "engineers",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    engineercode = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_engineers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "machinevariants",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machinevariants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(maxLength: 256, nullable: true),
                    description = table.Column<string>(nullable: true),
                    isactive = table.Column<bool>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false),
                    concurrencystamp = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    callid = table.Column<int>(nullable: true),
                    callordernumber = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: false),
                    datetorun = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    key = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    username = table.Column<string>(maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(nullable: false),
                    passwordhash = table.Column<string>(nullable: true),
                    securitystamp = table.Column<string>(nullable: true),
                    phonenumber = table.Column<string>(nullable: true),
                    phonenumberconfirmed = table.Column<bool>(nullable: false),
                    twofactorenabled = table.Column<bool>(nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(nullable: true),
                    lockoutenabled = table.Column<bool>(nullable: false),
                    accessfailedcount = table.Column<int>(nullable: false),
                    concurrencystamp = table.Column<string>(maxLength: 256, nullable: true),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    assignercode = table.Column<string>(nullable: true),
                    engineercode = table.Column<string>(nullable: true),
                    initiatorcode = table.Column<string>(nullable: true),
                    bankcode = table.Column<string>(nullable: true),
                    firstname = table.Column<string>(maxLength: 256, nullable: true),
                    lastname = table.Column<string>(maxLength: 256, nullable: true),
                    othername = table.Column<string>(maxLength: 256, nullable: true),
                    isactive = table.Column<bool>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: true),
                    dateupdated = table.Column<DateTime>(nullable: true),
                    imagename = table.Column<string>(nullable: true),
                    revokedpermissions = table.Column<string>(maxLength: 2000, nullable: true),
                    lastlogin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "initiators",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    initiatorcode = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_initiators", x => x.id);
                    table.ForeignKey(
                        name: "FK_initiators_banks_bankid",
                        column: x => x.bankid,
                        principalSchema: "callscheduler",
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "machines",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    machinecode = table.Column<string>(nullable: true),
                    bankid = table.Column<int>(nullable: false),
                    machinevariantid = table.Column<int>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machines", x => x.id);
                    table.ForeignKey(
                        name: "FK_machines_banks_bankid",
                        column: x => x.bankid,
                        principalSchema: "callscheduler",
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_machines_machinevariants_machinevariantid",
                        column: x => x.machinevariantid,
                        principalSchema: "callscheduler",
                        principalTable: "machinevariants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    partcode = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    machinevariantid = table.Column<int>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.id);
                    table.ForeignKey(
                        name: "FK_parts_machinevariants_machinevariantid",
                        column: x => x.machinevariantid,
                        principalSchema: "callscheduler",
                        principalTable: "machinevariants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roleclaims",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    roleid = table.Column<string>(nullable: false),
                    claimtype = table.Column<string>(nullable: true),
                    claimvalue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_roleclaims_roles_roleid",
                        column: x => x.roleid,
                        principalSchema: "callscheduler",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tokens",
                schema: "callscheduler",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: false),
                    loginprovider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "FK_tokens_users_userid",
                        column: x => x.userid,
                        principalSchema: "callscheduler",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userclaims",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<string>(nullable: false),
                    claimtype = table.Column<string>(nullable: true),
                    claimvalue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_userclaims_users_userid",
                        column: x => x.userid,
                        principalSchema: "callscheduler",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userlogins",
                schema: "callscheduler",
                columns: table => new
                {
                    loginprovider = table.Column<string>(nullable: false),
                    providerkey = table.Column<string>(nullable: false),
                    providerdisplayname = table.Column<string>(nullable: true),
                    userid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "FK_userlogins_users_userid",
                        column: x => x.userid,
                        principalSchema: "callscheduler",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                schema: "callscheduler",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: false),
                    roleid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_userroles_roles_roleid",
                        column: x => x.roleid,
                        principalSchema: "callscheduler",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userroles_users_userid",
                        column: x => x.userid,
                        principalSchema: "callscheduler",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calls",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    callordernumber = table.Column<string>(nullable: true),
                    errordescription = table.Column<string>(nullable: true),
                    errorcode = table.Column<string>(nullable: true),
                    engineerlocation = table.Column<string>(nullable: true),
                    sladuration = table.Column<int>(nullable: false),
                    slaamount = table.Column<decimal>(nullable: false),
                    assignerid = table.Column<int>(nullable: false),
                    initiatorid = table.Column<int>(nullable: false),
                    engineerid = table.Column<int>(nullable: false),
                    bankid = table.Column<int>(nullable: false),
                    machineid = table.Column<int>(nullable: false),
                    metsla = table.Column<bool>(nullable: false),
                    iscompleted = table.Column<bool>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false),
                    dateupdated = table.Column<DateTime>(nullable: false),
                    datecompleted = table.Column<DateTime>(nullable: true),
                    parts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calls", x => x.id);
                    table.ForeignKey(
                        name: "FK_calls_assigners_assignerid",
                        column: x => x.assignerid,
                        principalSchema: "callscheduler",
                        principalTable: "assigners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calls_banks_bankid",
                        column: x => x.bankid,
                        principalSchema: "callscheduler",
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calls_engineers_engineerid",
                        column: x => x.engineerid,
                        principalSchema: "callscheduler",
                        principalTable: "engineers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calls_initiators_initiatorid",
                        column: x => x.initiatorid,
                        principalSchema: "callscheduler",
                        principalTable: "initiators",
                        principalColumn: "id",
                        onUpdate: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calls_machines_machineid",
                        column: x => x.machineid,
                        principalSchema: "callscheduler",
                        principalTable: "machines",
                        principalColumn: "id",
                        onUpdate: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "initiatedcalls",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    callordernumber = table.Column<string>(nullable: true),
                    errordescription = table.Column<string>(nullable: true),
                    errorcode = table.Column<string>(nullable: true),
                    bankid = table.Column<int>(nullable: false),
                    machineid = table.Column<int>(nullable: false),
                    initiatorid = table.Column<int>(nullable: false),
                    isassigned = table.Column<bool>(nullable: false),
                    datecreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_initiatedcalls", x => x.id);
                    table.ForeignKey(
                        name: "FK_initiatedcalls_banks_bankid",
                        column: x => x.bankid,
                        principalSchema: "callscheduler",
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_initiatedcalls_initiators_initiatorid",
                        column: x => x.initiatorid,
                        principalSchema: "callscheduler",
                        principalTable: "initiators",
                        principalColumn: "id",
                        onUpdate: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_initiatedcalls_machines_machineid",
                        column: x => x.machineid,
                        principalSchema: "callscheduler",
                        principalTable: "machines",
                        principalColumn: "id",
                        onUpdate: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "calltimelines",
                schema: "callscheduler",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    callid = table.Column<int>(nullable: false),
                    callordernumber = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    engineerlocation = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: false),
                    datechanged = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calltimelines", x => x.id);
                    table.ForeignKey(
                        name: "FK_calltimelines_calls_callid",
                        column: x => x.callid,
                        principalSchema: "callscheduler",
                        principalTable: "calls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calls_assignerid",
                schema: "callscheduler",
                table: "calls",
                column: "assignerid");

            migrationBuilder.CreateIndex(
                name: "IX_calls_bankid",
                schema: "callscheduler",
                table: "calls",
                column: "bankid");

            migrationBuilder.CreateIndex(
                name: "IX_calls_engineerid",
                schema: "callscheduler",
                table: "calls",
                column: "engineerid");

            migrationBuilder.CreateIndex(
                name: "IX_calls_initiatorid",
                schema: "callscheduler",
                table: "calls",
                column: "initiatorid");

            migrationBuilder.CreateIndex(
                name: "IX_calls_machineid",
                schema: "callscheduler",
                table: "calls",
                column: "machineid");

            migrationBuilder.CreateIndex(
                name: "IX_calltimelines_callid",
                schema: "callscheduler",
                table: "calltimelines",
                column: "callid");

            migrationBuilder.CreateIndex(
                name: "IX_initiatedcalls_bankid",
                schema: "callscheduler",
                table: "initiatedcalls",
                column: "bankid");

            migrationBuilder.CreateIndex(
                name: "IX_initiatedcalls_initiatorid",
                schema: "callscheduler",
                table: "initiatedcalls",
                column: "initiatorid");

            migrationBuilder.CreateIndex(
                name: "IX_initiatedcalls_machineid",
                schema: "callscheduler",
                table: "initiatedcalls",
                column: "machineid");

            migrationBuilder.CreateIndex(
                name: "IX_initiators_bankid",
                schema: "callscheduler",
                table: "initiators",
                column: "bankid");

            migrationBuilder.CreateIndex(
                name: "IX_machines_bankid",
                schema: "callscheduler",
                table: "machines",
                column: "bankid");

            migrationBuilder.CreateIndex(
                name: "IX_machines_machinevariantid",
                schema: "callscheduler",
                table: "machines",
                column: "machinevariantid");

            migrationBuilder.CreateIndex(
                name: "IX_parts_machinevariantid",
                schema: "callscheduler",
                table: "parts",
                column: "machinevariantid");

            migrationBuilder.CreateIndex(
                name: "IX_roleclaims_roleid",
                schema: "callscheduler",
                table: "roleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "callscheduler",
                table: "roles",
                column: "normalizedname",
                unique: true,
                filter: "[normalizedname] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_userclaims_userid",
                schema: "callscheduler",
                table: "userclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_userlogins_userid",
                schema: "callscheduler",
                table: "userlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_userroles_roleid",
                schema: "callscheduler",
                table: "userroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "callscheduler",
                table: "users",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "callscheduler",
                table: "users",
                column: "normalizedusername",
                unique: true,
                filter: "[normalizedusername] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audits",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "authorizations",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "calltimelines",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "initiatedcalls",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "parts",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "roleclaims",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "schedules",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "settings",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "tokens",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "userclaims",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "userlogins",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "userroles",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "calls",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "users",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "assigners",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "engineers",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "initiators",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "machines",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "banks",
                schema: "callscheduler");

            migrationBuilder.DropTable(
                name: "machinevariants",
                schema: "callscheduler");
        }
    }
}
