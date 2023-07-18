using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "591dd891-60e3-4c48-90ee-3ca057bf0c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf607d8b-33c7-4de4-9aec-d585c2c20546");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c888b23a-325c-4085-9abc-3e14897a86fc", "16268120-d134-45cb-b022-80e847812ba4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c888b23a-325c-4085-9abc-3e14897a86fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16268120-d134-45cb-b022-80e847812ba4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bb53d1e-1cfc-42be-a593-5570dd81d29f", "849c18e1-8dfe-4f62-b840-466722b0c0d4", "SuperUsuario", "SUPERUSUARIO" },
                    { "8bc6811d-b0d4-4e41-812d-a794b25b1605", "96578ae1-0bee-4f23-8670-18d68bc433b2", "Empresa", "EMPRESA" },
                    { "944979be-4d03-44aa-a63c-31b5a0108242", "72532062-ea15-4f3b-9414-6d50807cc959", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01ecc4fd-d4d8-4945-8fcb-529fb42b9098", 0, "c0bc9709-c4f9-4aa0-b167-93663c993fdc", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEBckyL7mObS02FxxbKK9I0zXuBJ7aYW+QL9AgrCvOuNaOr0uXXFlCDkPAui5shMs1g==", null, false, "f0d1bb05-9ee5-409c-ad1e-723429934644", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4bb53d1e-1cfc-42be-a593-5570dd81d29f", "01ecc4fd-d4d8-4945-8fcb-529fb42b9098" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc6811d-b0d4-4e41-812d-a794b25b1605");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "944979be-4d03-44aa-a63c-31b5a0108242");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4bb53d1e-1cfc-42be-a593-5570dd81d29f", "01ecc4fd-d4d8-4945-8fcb-529fb42b9098" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bb53d1e-1cfc-42be-a593-5570dd81d29f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01ecc4fd-d4d8-4945-8fcb-529fb42b9098");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "591dd891-60e3-4c48-90ee-3ca057bf0c33", "7167fcd2-1aec-492a-a522-03d4934dd9d8", "Empresa", "EMPRESA" },
                    { "c888b23a-325c-4085-9abc-3e14897a86fc", "5ed3ff4e-8cbf-4a65-b735-259ea2a30760", "SuperUsuario", "SUPERUSUARIO" },
                    { "cf607d8b-33c7-4de4-9aec-d585c2c20546", "d843673b-2207-4509-9f9c-0e44ae672e7e", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "16268120-d134-45cb-b022-80e847812ba4", 0, "88484a55-f77f-4df2-945c-97aecbb05920", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEOcgQ5XeaYE2sjd/4P1knlWVtJIXAQxnTZ7zYcVM4kERkWGc0lmaaFR+/qpiTDerdA==", null, false, "fced3435-2135-4ba2-b0fc-5adfbfbde2db", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c888b23a-325c-4085-9abc-3e14897a86fc", "16268120-d134-45cb-b022-80e847812ba4" });
        }
    }
}
