using Microsoft.EntityFrameworkCore.Migrations;

namespace Privilege.Database.Migrations
{
    public partial class userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "UserInterests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "UserDetailTrains",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "LenderProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "BorrowerProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "UserInterests");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "UserDetailTrains");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "LenderProjects");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "BorrowerProjects");
        }
    }
}
