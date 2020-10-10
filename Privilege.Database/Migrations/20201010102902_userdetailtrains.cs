using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Privilege.Database.Migrations
{
    public partial class userdetailtrains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserInterests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDetailTrains",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
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
                    Gender = table.Column<string>(maxLength: 5, nullable: false),
                    Married = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailTrains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetailTrains");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserInterests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDetails");
        }
    }
}
