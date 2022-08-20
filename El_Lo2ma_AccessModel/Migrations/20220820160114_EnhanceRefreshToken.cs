using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class EnhanceRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_UserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14b81ea8-1015-4900-be0f-2d01a1f991d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b5108d0-6da9-4e09-99a1-4fbd929b09ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c898059-711d-4741-8b9d-04fc2dd58b1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4346cc-ff5a-4c40-b208-e936b65a5bfd");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshTokens");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshTokens",
                newName: "IX_RefreshTokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "572eba89-af54-40e9-83b2-3c00f126ab5e", "80fa9c09-f72a-4ccf-b42e-56e51b7249c3", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "62f728c8-d117-4e9e-ad0f-52eda51d6781", "a1917348-d955-4bf3-9af5-d875010b6c5d", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b08f3001-266e-418d-af1c-74844c66ae2c", "b8a3bb75-dc7f-4404-b20f-578980087f4f", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ef7a3941-f7bc-47c2-b9f1-e55a8a2cdf4e", "28fc7148-7322-45e3-a834-aa266be53a9b", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3436), new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3449) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3454), new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3456), new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3458), new DateTime(2022, 8, 20, 18, 1, 13, 826, DateTimeKind.Local).AddTicks(3459) });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572eba89-af54-40e9-83b2-3c00f126ab5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62f728c8-d117-4e9e-ad0f-52eda51d6781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b08f3001-266e-418d-af1c-74844c66ae2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef7a3941-f7bc-47c2-b9f1-e55a8a2cdf4e");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "14b81ea8-1015-4900-be0f-2d01a1f991d1", "3cce2cbb-0d57-4c1e-927b-c8857378aba0", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5b5108d0-6da9-4e09-99a1-4fbd929b09ec", "0c3eaf65-5a8e-40c0-9f8e-1ac3f49dff29", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8c898059-711d-4741-8b9d-04fc2dd58b1e", "ba3943ab-0bdf-45d8-a5a7-7e7e8315974d", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "bf4346cc-ff5a-4c40-b208-e936b65a5bfd", "d4989998-4c3f-471e-8cd4-4dfcf064ab3e", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1693), new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1703) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1710), new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1711), new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1713), new DateTime(2022, 8, 20, 17, 0, 47, 667, DateTimeKind.Local).AddTicks(1714) });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
