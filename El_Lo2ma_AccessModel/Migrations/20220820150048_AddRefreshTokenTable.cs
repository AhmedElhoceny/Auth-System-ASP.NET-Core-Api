using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class AddRefreshTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

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

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3458), new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3475), new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3476), new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3477), new DateTime(2022, 8, 19, 20, 56, 7, 479, DateTimeKind.Local).AddTicks(3478) });
        }
    }
}
