using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class SeedingUserTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824e650c-5c64-4752-bb22-a964366f5b5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2ce90bd-ce4d-40c0-86fd-668f6ecb7924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e42bdcd4-7cf9-4405-8055-8bce1580d32f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff952795-5092-4059-b0d2-da5657965381");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "42944f42-d73f-4efa-8e29-8ad8c0a56e31", "8b12f413-5c83-43e8-93c3-84b0c7c19365", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4c94d86b-7544-44a3-87d3-d3a2db42ca29", "42b52ee2-f018-4d52-8b22-ecb31246bf03", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "69dd0cb5-d45d-45f4-97b3-c8b5d1562dea", "6ed65b94-5320-45b5-88fe-b12e53f6259e", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d637687c-3134-4bca-95a7-e2e7dedb32a9", "1063c2a4-e1be-460b-85c8-ebbfe48ab15c", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "ExpirationTime", "InsertBy", "InsertDate", "IsDeleted", "Licenses", "Name", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, 24.0, null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3458), false, "", "Admin", null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3473) },
                    { 2, null, null, 8.0, null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3475), false, "شهادة صحية , صور البطاقة", "Chief", null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3476) },
                    { 3, null, null, 24.0, null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3476), false, "رخصة قيادة , صور البطاقة", "Delivery", null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3477) },
                    { 4, null, null, 8.0, null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3477), false, "", "Client", null, new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3478) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42944f42-d73f-4efa-8e29-8ad8c0a56e31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c94d86b-7544-44a3-87d3-d3a2db42ca29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69dd0cb5-d45d-45f4-97b3-c8b5d1562dea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d637687c-3134-4bca-95a7-e2e7dedb32a9");

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "824e650c-5c64-4752-bb22-a964366f5b5a", "56edb2c3-7279-4d2c-b141-f8ef008e1661", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d2ce90bd-ce4d-40c0-86fd-668f6ecb7924", "3bfdb6c1-259f-4bf2-aefb-66e61effde51", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e42bdcd4-7cf9-4405-8055-8bce1580d32f", "e1d1fdfd-9d6e-4883-ba51-2d3fa76a4e19", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ff952795-5092-4059-b0d2-da5657965381", "d2656739-c769-4ecd-b9bf-5afce716dedf", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
