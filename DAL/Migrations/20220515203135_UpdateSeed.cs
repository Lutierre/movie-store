using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class UpdateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("519163b2-8e11-4c61-9b11-5e88bf98a2ed"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8d90e4a3-c819-4fdd-99be-95f8bc9a422c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ad177ab5-e43b-4070-8a30-2ca9d929c025"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e294e90c-429c-4d95-85b5-a764c0cf4978"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("0464545f-fb58-4d8c-99eb-cb660c70cb37"), 1, "Action" },
                    { new Guid("08471614-5e71-4505-b613-c1e56f2c0568"), 3, "Drama" },
                    { new Guid("b146eb88-82b3-4508-9e58-2a27c55e7ee4"), 2, "Comedy" },
                    { new Guid("c69c0ed1-2df6-43ca-8c1d-ecd3908d03cc"), 4, "Misc" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0464545f-fb58-4d8c-99eb-cb660c70cb37"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("08471614-5e71-4505-b613-c1e56f2c0568"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b146eb88-82b3-4508-9e58-2a27c55e7ee4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c69c0ed1-2df6-43ca-8c1d-ecd3908d03cc"));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("519163b2-8e11-4c61-9b11-5e88bf98a2ed"), 2, "Comedy" },
                    { new Guid("8d90e4a3-c819-4fdd-99be-95f8bc9a422c"), 3, "Drama" },
                    { new Guid("ad177ab5-e43b-4070-8a30-2ca9d929c025"), 1, "Action" },
                    { new Guid("e294e90c-429c-4d95-85b5-a764c0cf4978"), 4, "Misc" }
                });
        }
    }
}
