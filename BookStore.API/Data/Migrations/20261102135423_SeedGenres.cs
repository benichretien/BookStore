using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c4f3b8e-5a1d-4e2b-9f6a-3d7c8b9e1f20"), "Programming" },
                    { new Guid("7d2a9e61-3c4b-4f8d-a1e5-6b0c2d3e4f51"), "Fantasy" },
                    { new Guid("a9e5c7d3-1b2f-4a6e-8c0d-9f8e7d6c5b42"), "Self-Help" },
                    { new Guid("e3b1d5f7-9a2c-4e6b-b8d0-1c3e5f7a9b63"), "Science Fiction" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c4f3b8e-5a1d-4e2b-9f6a-3d7c8b9e1f20"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7d2a9e61-3c4b-4f8d-a1e5-6b0c2d3e4f51"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a9e5c7d3-1b2f-4a6e-8c0d-9f8e7d6c5b42"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e3b1d5f7-9a2c-4e6b-b8d0-1c3e5f7a9b63"));
        }
    }
}
