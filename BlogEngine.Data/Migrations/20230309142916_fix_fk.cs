using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEngine.API.Migrations
{
    /// <inheritdoc />
    public partial class fix_fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPqLmrhQpXOyTGj1re3KctLpfMjUshQGyrBcEKDtlRdpnXo/E5Gddp2FGhHnQrYZRA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFm4Dk76PoxXRdyDS7UglqAG4ad4vDOJ9DpH6ytUksPah455Q1emjpmuhRxAfj7kMg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOB2twIQMKz/doFvmk7JvOsneRzHtno1C2nlM1sC9d6s0MnXgnH7mBTB0HJxg2RQ6w==");

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 3, 6, 9, 29, 16, 184, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 3, 7, 9, 29, 16, 184, DateTimeKind.Local).AddTicks(5983));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "PublishDate",
                value: new DateTime(2023, 3, 5, 19, 7, 7, 424, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Blog_Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 3, 6, 19, 7, 7, 424, DateTimeKind.Local).AddTicks(3279));
        }
    }
}
