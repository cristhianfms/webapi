using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reports.DataAccess.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ConnectionString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.UniqueConstraint("AK_Area_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Data = table.Column<int>(nullable: true),
                    Query = table.Column<string>(nullable: true),
                    StringValue_Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaManager",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaManager", x => new { x.AreaId, x.ManagerId });
                    table.ForeignKey(
                        name: "FK_AreaManager_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaManager_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IzqId = table.Column<Guid>(nullable: true),
                    DerId = table.Column<Guid>(nullable: true),
                    ValueIzqId = table.Column<Guid>(nullable: true),
                    ValueDerId = table.Column<Guid>(nullable: true),
                    Operator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Conditions_DerId",
                        column: x => x.DerId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conditions_Conditions_IzqId",
                        column: x => x.IzqId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conditions_Values_ValueDerId",
                        column: x => x.ValueDerId,
                        principalTable: "Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conditions_Values_ValueIzqId",
                        column: x => x.ValueIzqId,
                        principalTable: "Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GreenConditionId = table.Column<Guid>(nullable: true),
                    YellowConditionId = table.Column<Guid>(nullable: true),
                    RedConditionId = table.Column<Guid>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicators_Conditions_GreenConditionId",
                        column: x => x.GreenConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicators_Conditions_RedConditionId",
                        column: x => x.RedConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicators_Conditions_YellowConditionId",
                        column: x => x.YellowConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorDisplay",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    IndicatorId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<Guid>(nullable: false),
                    Orden = table.Column<int>(nullable: false),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorDisplay", x => new { x.AreaId, x.UserId, x.IndicatorId });
                    table.ForeignKey(
                        name: "FK_IndicatorDisplay_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorDisplay_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaManager_ManagerId",
                table: "AreaManager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_DerId",
                table: "Conditions",
                column: "DerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_IzqId",
                table: "Conditions",
                column: "IzqId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ValueDerId",
                table: "Conditions",
                column: "ValueDerId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ValueIzqId",
                table: "Conditions",
                column: "ValueIzqId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorDisplay_IndicatorId",
                table: "IndicatorDisplay",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_AreaId",
                table: "Indicators",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_GreenConditionId",
                table: "Indicators",
                column: "GreenConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_RedConditionId",
                table: "Indicators",
                column: "RedConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_YellowConditionId",
                table: "Indicators",
                column: "YellowConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaManager");

            migrationBuilder.DropTable(
                name: "IndicatorDisplay");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
