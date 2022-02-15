using Microsoft.EntityFrameworkCore.Migrations;

namespace AgeaProject.Migrations
{
    public partial class quotesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextHeader",
                table: "SliderAds",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextFooter",
                table: "SliderAds",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextBody",
                table: "SliderAds",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Src",
                table: "SliderAds",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Quotes",
                maxLength: 71,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Quotes",
                maxLength: 41,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Quotes",
                maxLength: 71,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Quotes",
                maxLength: 51,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Quotes",
                maxLength: 201,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Quotes",
                maxLength: 101,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "ContactUs",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "ContactUs",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactUs",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ContactUs",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TextHeader",
                table: "SliderAds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextFooter",
                table: "SliderAds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextBody",
                table: "SliderAds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Src",
                table: "SliderAds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 71);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 41);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 71);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 51);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 201);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Quotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 101);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "ContactUs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "ContactUs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactUs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ContactUs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
