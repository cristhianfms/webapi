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
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
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
                    Data = table.Column<bool>(nullable: true),
                    DateValue_Data = table.Column<DateTime>(nullable: true),
                    IntValue_Data = table.Column<int>(nullable: true),
                    Query = table.Column<string>(nullable: true),
                    StringValue_Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaUsers",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUsers", x => new { x.AreaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AreaUsers_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaUsers_Users_UserId",
                        column: x => x.UserId,
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
                    AreaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IndicatorConfigs",
                columns: table => new
                {
                    IndicatorId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CustomName = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorConfigs", x => new { x.IndicatorId, x.UserId });
                    table.ForeignKey(
                        name: "FK_IndicatorConfigs_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorConfigs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaUsers_UserId",
                table: "AreaUsers",
                column: "UserId");

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
                name: "IX_IndicatorConfigs_UserId",
                table: "IndicatorConfigs",
                column: "UserId");

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
                name: "AreaUsers");

            migrationBuilder.DropTable(
                name: "IndicatorConfigs");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
