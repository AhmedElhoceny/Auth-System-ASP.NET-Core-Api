using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class AddUserTypeNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04bb6f49-e2c3-4589-9311-22ddffd1c0ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e5398d1-6df8-4a3a-ae11-29cfaccb7021");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62fdea41-057e-4647-ab8a-9e78fe70f1c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea52d50a-9017-4b3f-b6cf-630934019653");

            migrationBuilder.AddColumn<int>(
                name: "UserType_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserType_Id",
                table: "AspNetUsers",
                column: "UserType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserType_UserType_Id",
                table: "AspNetUsers",
                column: "UserType_Id",
                principalTable: "UserType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserType_UserType_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserType_Id",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "UserType_Id",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "04bb6f49-e2c3-4589-9311-22ddffd1c0ab", "12cc074f-af41-41f3-ace7-9777b29d9e2a", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5e5398d1-6df8-4a3a-ae11-29cfaccb7021", "83cae6da-0f99-415f-a162-daf96c0fec1b", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "62fdea41-057e-4647-ab8a-9e78fe70f1c8", "410f7c30-5ef6-490f-bcd9-7b1b80dfbc77", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ea52d50a-9017-4b3f-b6cf-630934019653", "89482961-665f-4694-80ce-a1fa27c7e6c8", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
