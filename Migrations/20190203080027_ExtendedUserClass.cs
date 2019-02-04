using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class ExtendedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Usres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Usres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "Usres",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Usres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "Usres",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Usres_UserId",
                        column: x => x.UserId,
                        principalTable: "Usres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Usres");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "Usres");
        }
    }
}
