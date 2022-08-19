using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Lo2ma_AccessModel.Migrations
{
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InsertBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Discriminator", "InsertBy", "InsertDate", "IsDeleted", "Name", "NormalizedName", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { "8a2bc507-892a-41b3-8fa3-edf4120a71e1", "03f25720-8786-4b87-8419-e1c486a0f6c6", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Delivery", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "90e9b5c7-a8e0-4fea-8087-953c461c91f6", "5b1810cc-8fab-4305-bb92-52a7980c6f00", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Client", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a8cd4406-42f2-4403-96ab-0392c7135a5b", "ed06e985-0a44-4690-8070-e101233f3d8d", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chief", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c529c31e-0278-4475-9b17-cee75f475677", "2d643110-fe85-470b-ae3c-73b9e89f666d", null, null, "ApplicationRole", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Admin", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a2bc507-892a-41b3-8fa3-edf4120a71e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90e9b5c7-a8e0-4fea-8087-953c461c91f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8cd4406-42f2-4403-96ab-0392c7135a5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c529c31e-0278-4475-9b17-cee75f475677");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "InsertBy",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AspNetRoles");
        }
    }
}
