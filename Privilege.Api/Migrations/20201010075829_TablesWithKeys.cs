using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Privilege.Api.Migrations
{
    public partial class TablesWithKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowerProjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowerProjects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LenderProjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenderProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LenderProjects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Dependants = table.Column<int>(nullable: false),
                    Education = table.Column<int>(nullable: false),
                    NumberOfCars = table.Column<int>(nullable: false),
                    NumberOfProperties = table.Column<int>(nullable: false),
                    EmploymentType = table.Column<int>(nullable: false),
                    NumberOfLends = table.Column<int>(nullable: false),
                    NumberOfBorrows = table.Column<int>(nullable: false),
                    JobClass = table.Column<int>(nullable: false),
                    Income = table.Column<double>(nullable: false),
                    Debt = table.Column<double>(nullable: false),
                    Lending = table.Column<double>(nullable: false),
                    SocialStability = table.Column<double>(nullable: false),
                    SocialExposure = table.Column<double>(nullable: false),
                    SocialQuality = table.Column<double>(nullable: false),
                    CreditScore = table.Column<double>(nullable: false),
                    AvgIncomeOver2Years = table.Column<double>(nullable: false),
                    AvgIncomeOver5Years = table.Column<double>(nullable: false),
                    AvgIncomeOver10Years = table.Column<double>(nullable: false),
                    Savings = table.Column<double>(nullable: false),
                    AvgSavingsOver2Years = table.Column<double>(nullable: false),
                    AvgSavingsOver5Years = table.Column<double>(nullable: false),
                    AvgSavingsOver10Years = table.Column<double>(nullable: false),
                    Gender = table.Column<string>(maxLength: 5, nullable: true),
                    Married = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    Interest = table.Column<string>(maxLength: 250, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false),
                    BorrowerProjectId = table.Column<long>(nullable: false),
                    ContractStatusId = table.Column<int>(nullable: false),
                    LenderProjectId = table.Column<long>(nullable: false),
                    Expiration = table.Column<DateTimeOffset>(nullable: false),
                    Clause = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_BorrowerProjects_BorrowerProjectId",
                        column: x => x.BorrowerProjectId,
                        principalTable: "BorrowerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractStatus_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_LenderProjects_LenderProjectId",
                        column: x => x.LenderProjectId,
                        principalTable: "LenderProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerProjects_ApplicationUserId",
                table: "BorrowerProjects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ApplicationUserId",
                table: "Contracts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BorrowerProjectId",
                table: "Contracts",
                column: "BorrowerProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractStatusId",
                table: "Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_LenderProjectId",
                table: "Contracts",
                column: "LenderProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LenderProjects_ApplicationUserId",
                table: "LenderProjects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_ApplicationUserId",
                table: "UserInterests",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "BorrowerProjects");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "LenderProjects");
        }
    }
}
