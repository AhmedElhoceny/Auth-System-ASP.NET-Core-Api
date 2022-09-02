using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class ForgetPassWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AuthCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthCode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuthCode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "40f681db-234a-4b69-8862-5990a83c8aed", "328f3f6b-dc29-4dfb-bc58-469baa3fd79e", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "66992a83-793a-48ce-89e6-6a7aca279dc3", "615a6e5a-99ed-4455-8734-b3b42a30a259", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a87d5c06-4c1a-4a2f-9e0c-ef39ef6f810d", "0fee1ea3-daae-4a89-aff6-2a46b33b7359", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e66a9fef-5cbb-4e25-b53f-97af9ccc250a", "f3287c21-8848-4036-8894-cf045cfd3a58", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8319), new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8334), new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8335), new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "UserType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8336), new DateTime(2022, 9, 2, 18, 53, 15, 13, DateTimeKind.Local).AddTicks(8337) });

            migrationBuilder.CreateIndex(
                name: "IX_AuthCode_UserId",
                table: "AuthCode",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthCode");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40f681db-234a-4b69-8862-5990a83c8aed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66992a83-793a-48ce-89e6-6a7aca279dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a87d5c06-4c1a-4a2f-9e0c-ef39ef6f810d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66a9fef-5cbb-4e25-b53f-97af9ccc250a");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

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
        }
    }
}
