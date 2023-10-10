using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.User.Migrations
{
    public partial class removefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFreelancers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsHoliday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsHotel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsLimoDriver",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsResturant",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSafariGuide",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSpa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTour",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTourGuide",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFreelancers",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHoliday",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHotel",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimoDriver",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsResturant",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSafariGuide",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpa",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTour",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTourGuide",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTransfer",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }
    }
}
