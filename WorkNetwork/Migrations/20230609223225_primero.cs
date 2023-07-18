using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class primero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5855b573-cb19-43f2-99ee-1714f7392210", "8cfebec1-bb38-4818-a6a9-448417df5915", "SuperUsuario", "SUPERUSUARIO" },
                    { "6bf89cf3-c00f-4398-b7c7-f58d07f47655", "6028906b-2115-4618-b91f-0e43dda65d8e", "Usuario", "USUARIO" },
                    { "8527e3b8-785c-44c0-85ac-f1f4074fe8a3", "b3d9a497-a740-4a53-b0d9-f350c3d411b4", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc10b25b-e776-4fdc-b665-0a5a2128ccde", 0, "7ea19548-f5f2-4b3c-87d3-4278d76ad576", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEAqW43M14rKrlwYqh5AnXVDWmlakNRMUQYwD446xiap+qYIrvviL2fPINshKBLJtIQ==", null, false, "9f538230-9e9b-43c1-99a9-c67cbf070f3f", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5855b573-cb19-43f2-99ee-1714f7392210", "fc10b25b-e776-4fdc-b665-0a5a2128ccde" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf89cf3-c00f-4398-b7c7-f58d07f47655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8527e3b8-785c-44c0-85ac-f1f4074fe8a3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5855b573-cb19-43f2-99ee-1714f7392210", "fc10b25b-e776-4fdc-b665-0a5a2128ccde" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5855b573-cb19-43f2-99ee-1714f7392210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc10b25b-e776-4fdc-b665-0a5a2128ccde");

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
    }
}
