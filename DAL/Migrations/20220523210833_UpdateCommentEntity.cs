using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class UpdateCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2588cf3e-cb47-4c55-9805-07b34c783caf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("52622d5b-e493-4a48-a343-3df23ede3b57"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("64a0b8c5-ac8b-4d18-8ba0-da59cf92f36d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("98c07b7b-6029-4fbb-b415-1f4f715bc4b4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("0be539e9-a21a-4cc8-9e23-59d7c22a9cf6"), 4, "Misc" },
                    { new Guid("82848447-c7cb-4073-945e-68ed2518cd35"), 1, "Action" },
                    { new Guid("8345a4e1-45f4-4a8f-9e5b-abbc206831e9"), 2, "Comedy" },
                    { new Guid("a30cfde3-4e2f-4129-aacc-470ba8796459"), 3, "Drama" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0be539e9-a21a-4cc8-9e23-59d7c22a9cf6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("82848447-c7cb-4073-945e-68ed2518cd35"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8345a4e1-45f4-4a8f-9e5b-abbc206831e9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a30cfde3-4e2f-4129-aacc-470ba8796459"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("2588cf3e-cb47-4c55-9805-07b34c783caf"), 1, "Action" },
                    { new Guid("52622d5b-e493-4a48-a343-3df23ede3b57"), 4, "Misc" },
                    { new Guid("64a0b8c5-ac8b-4d18-8ba0-da59cf92f36d"), 3, "Drama" },
                    { new Guid("98c07b7b-6029-4fbb-b415-1f4f715bc4b4"), 2, "Comedy" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
