using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessRuleApplication.Migrations
{
    public partial class BusinessRuleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentCommission",
                columns: table => new
                {
                    AgentCommisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(nullable: false),
                    CommisionAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCommission", x => x.AgentCommisionId);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CommisionPercentage = table.Column<decimal>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ActiveDate = table.Column<DateTime>(nullable: false),
                    DeactiveDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShip", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentOptionId = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOption",
                columns: table => new
                {
                    PaymentOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOption", x => x.PaymentOptionId);
                });

            migrationBuilder.CreateTable(
                name: "SlipDeatil",
                columns: table => new
                {
                    SlipDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(nullable: false),
                    SlipAddress = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    SlipType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlipDeatil", x => x.SlipDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessRule",
                columns: table => new
                {
                    BusinessRuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(nullable: false),
                    PaymentOptionId = table.Column<int>(nullable: false),
                    PaymentOptionsPaymentOptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRule", x => x.BusinessRuleId);
                    table.ForeignKey(
                        name: "FK_BusinessRule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessRule_PaymentOption_PaymentOptionsPaymentOptionId",
                        column: x => x.PaymentOptionsPaymentOptionId,
                        principalTable: "PaymentOption",
                        principalColumn: "PaymentOptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRule_ModuleId",
                table: "BusinessRule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRule_PaymentOptionsPaymentOptionId",
                table: "BusinessRule",
                column: "PaymentOptionsPaymentOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentCommission");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "BusinessRule");

            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "SlipDeatil");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "PaymentOption");
        }
    }
}
