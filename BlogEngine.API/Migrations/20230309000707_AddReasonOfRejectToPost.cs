using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.API.Migrations
{
    /// <inheritdoc />
    public partial class AddReasonOfRejectToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonOfReject",
                table: "Blog_Post",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBR1X6orjffkEjxugC6oj5sUWwkc0XOo1gHPTrUPpPjCDlyQTcs+azH0/JKA6Op7yg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPtJHy4yr3Miu8zK3IOVaUBaqbovrv8jS0RZbgGwxNHEhrno68EuawZYN6JqN/XrhA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHiktoEO6XcDC5Em82NhShPaut3xxqH1psKhzP3vptooEVlyI2xo8Uv1A+bcaWkSrw==");

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "ReasonOfReject" },
                values: new object[] { new DateTime(2023, 3, 5, 19, 7, 7, 424, DateTimeKind.Local).AddTicks(3252), null });

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishDate", "ReasonOfReject" },
                values: new object[] { new DateTime(2023, 3, 6, 19, 7, 7, 424, DateTimeKind.Local).AddTicks(3279), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonOfReject",
                table: "Blog_Post");

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
                column: "PublishDate",
                value: new DateTime(2023, 3, 5, 17, 59, 36, 683, DateTimeKind.Local).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 3, 6, 17, 59, 36, 683, DateTimeKind.Local).AddTicks(6474));
        }
    }
}
