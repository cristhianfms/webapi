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
                    Name = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "ValueExpressions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueExpressions", x => x.Id);
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
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ValueIzqId = table.Column<Guid>(nullable: true),
                    ValueDerId = table.Column<Guid>(nullable: true),
                    Operation = table.Column<string>(nullable: true),
                    CompIzqId = table.Column<Guid>(nullable: true),
                    CompDerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_ValueExpressions_ValueDerId",
                        column: x => x.ValueDerId,
                        principalTable: "ValueExpressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_ValueExpressions_ValueIzqId",
                        column: x => x.ValueIzqId,
                        principalTable: "ValueExpressions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_Components_CompDerId",
                        column: x => x.CompDerId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_Components_CompIzqId",
                        column: x => x.CompIzqId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    ComponentId = table.Column<Guid>(nullable: true),
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
                        name: "FK_Indicators_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaManager_ManagerId",
                table: "AreaManager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ValueDerId",
                table: "Components",
                column: "ValueDerId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ValueIzqId",
                table: "Components",
                column: "ValueIzqId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_CompDerId",
                table: "Components",
                column: "CompDerId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_CompIzqId",
                table: "Components",
                column: "CompIzqId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_AreaId",
                table: "Indicators",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_ComponentId",
                table: "Indicators",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaManager");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "ValueExpressions");
        }
    }
}
