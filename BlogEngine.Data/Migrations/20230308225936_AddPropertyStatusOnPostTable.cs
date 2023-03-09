using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyStatusOnPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Blog_Post",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELZU6WHu2DY6IiqE5m/MJC9X+3zeHniCrsUoR3M14Z646vCvTuLgykSiPhJQcNYa+w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDb1VZsBHP/ffvKN6GiIViiHwviUK6vTYL/O7fuIop+xj1XBdLdIUWQnaIrR1QWaIg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDoGMLwnzITcrYb26rZ30TjwyQwEBIpmUpyEz6fHiOLHSgrwKNr9sSqXd94RiMs4RQ==");

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "Status" },
                values: new object[] { new DateTime(2023, 3, 5, 17, 59, 36, 683, DateTimeKind.Local).AddTicks(6454), 0 });

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishDate", "Status" },
                values: new object[] { new DateTime(2023, 3, 6, 17, 59, 36, 683, DateTimeKind.Local).AddTicks(6474), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Blog_Post");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOCeNC7XiCXmG8xAi74llLwnpJUHwXqQ4fP3m99eG1rMeJo0Uk7IV/rlWHnz+NgPJA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFCZOK/7zF0v6V5NF/nv1Ruy2TBA+xeMwukR6pZDe6hxgVBbKY0rK3/yb4kqVXlEXg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGD4VSVwCdcBh5VdMfLohof+qHPr3pZS2Ftpi9annZcdt7zIwJhNPOJuTln9e2/+pQ==");

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 3, 5, 15, 48, 44, 718, DateTimeKind.Local).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 3, 6, 15, 48, 44, 718, DateTimeKind.Local).AddTicks(5541));
        }
    }
}
