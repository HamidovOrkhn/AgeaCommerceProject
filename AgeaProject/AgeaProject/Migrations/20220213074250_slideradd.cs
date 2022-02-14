using Microsoft.EntityFrameworkCore.Migrations;

namespace AgeaProject.Migrations
{
    public partial class slideradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "SliderAds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderAds",
                table: "SliderAds",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderAds",
                table: "SliderAds");

            migrationBuilder.RenameTable(
                name: "SliderAds",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
