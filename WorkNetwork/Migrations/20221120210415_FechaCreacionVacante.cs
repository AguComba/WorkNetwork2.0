using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class FechaCreacionVacante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4140ee84-1b67-4278-984e-7c3edca2c0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50eaf53f-2e48-4184-9432-fba44ee8e777");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81b0d6a9-54f5-4802-87f1-cf584ee7c634", "7d71494f-30c6-4037-91ec-03367b4dd86a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81b0d6a9-54f5-4802-87f1-cf584ee7c634");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d71494f-30c6-4037-91ec-03367b4dd86a");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Vacante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ebf01ee-a5d5-4ae1-b2eb-b38fe8fe009e", "674e84a3-1cad-400e-9b71-8aeb69fabd03", "SuperUsuario", "SUPERUSUARIO" },
                    { "75f20074-ee67-4d08-bdae-582734a92d3c", "ed3a6f5f-8500-4edf-93da-866245821fa7", "Empresa", "EMPRESA" },
                    { "d7ade3a5-3f0b-40a0-be91-3dc4e24c8f18", "6698d7de-279e-4848-b69f-28e1cc935cdd", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "97e3ab17-6c7d-4809-ba6a-078f4aaaaf4f", 0, "9e656267-7496-4f36-824f-3290aae17a01", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEGm9RhyVJpgpaGE2osjEGdYdeLr44VQ6grU8qks5VOI4mzRvjRI2mN3pnlmtSg0Bmg==", null, false, "f75b70a3-533c-4dc3-b8d7-aa926aad9bee", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ebf01ee-a5d5-4ae1-b2eb-b38fe8fe009e", "97e3ab17-6c7d-4809-ba6a-078f4aaaaf4f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f20074-ee67-4d08-bdae-582734a92d3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7ade3a5-3f0b-40a0-be91-3dc4e24c8f18");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ebf01ee-a5d5-4ae1-b2eb-b38fe8fe009e", "97e3ab17-6c7d-4809-ba6a-078f4aaaaf4f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ebf01ee-a5d5-4ae1-b2eb-b38fe8fe009e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97e3ab17-6c7d-4809-ba6a-078f4aaaaf4f");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Vacante");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4140ee84-1b67-4278-984e-7c3edca2c0c1", "4d431d48-fad1-4c16-b6f6-3781adf310a8", "Empresa", "EMPRESA" },
                    { "50eaf53f-2e48-4184-9432-fba44ee8e777", "94b2eede-2b6c-4654-9a6e-63d33c91ce58", "Usuario", "USUARIO" },
                    { "81b0d6a9-54f5-4802-87f1-cf584ee7c634", "6447cdbc-6f47-4b9a-83a6-ab1ce761ccaf", "SuperUsuario", "SUPERUSUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d71494f-30c6-4037-91ec-03367b4dd86a", 0, "122896eb-58d0-49a8-957b-c864988bb3de", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEK0rzjldoV65QcATDVpAz+v7U2/V5gGSfwmpQANxBfUNjJ322JuRXiTqwxqovHBHcA==", null, false, "cf3934c2-d36f-43b8-8e1d-f0cf815774e9", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81b0d6a9-54f5-4802-87f1-cf584ee7c634", "7d71494f-30c6-4037-91ec-03367b4dd86a" });
        }
    }
}
