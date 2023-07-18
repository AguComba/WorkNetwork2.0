using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class nuevamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20048248-71d7-417e-9666-f01fcf780039");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f12b3e1a-c51b-4d40-ac77-c3b128d71bf5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "853fe18a-f66a-411a-921f-d26c1db82fd3", "02a22cd3-f1a1-4303-bef6-b3b69e339699" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "853fe18a-f66a-411a-921f-d26c1db82fd3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02a22cd3-f1a1-4303-bef6-b3b69e339699");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0701f287-db54-4e51-b75c-6708b574ed8d", "7ff3acbd-11e5-494c-bfdc-5dc6baf18514", "Usuario", "USUARIO" },
                    { "1f89acac-774d-49c1-9fa7-e6b6690e7549", "f44bac3d-1db4-434b-8d57-e5a41295de32", "Empresa", "EMPRESA" },
                    { "8bb81ef9-6329-4fd2-bcf8-b97b1cf96a73", "3f2e1dc9-406e-448f-b645-b54e9b2de121", "SuperUsuario", "SUPERUSUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f87fcc9-c88d-475d-8e30-e77845ee7c28", 0, "e6520d4e-2b8a-4deb-a0e3-dfdab5a6b49a", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEC26kJqpk3t7p6AT7iZpLYMz0w79kgv6ZRmzo8UWv7SXntCYbRqXcEeBl+KjYF1faQ==", null, false, "b551eb53-aeca-4929-a52e-62bf3f280345", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8bb81ef9-6329-4fd2-bcf8-b97b1cf96a73", "7f87fcc9-c88d-475d-8e30-e77845ee7c28" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0701f287-db54-4e51-b75c-6708b574ed8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f89acac-774d-49c1-9fa7-e6b6690e7549");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8bb81ef9-6329-4fd2-bcf8-b97b1cf96a73", "7f87fcc9-c88d-475d-8e30-e77845ee7c28" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bb81ef9-6329-4fd2-bcf8-b97b1cf96a73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f87fcc9-c88d-475d-8e30-e77845ee7c28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20048248-71d7-417e-9666-f01fcf780039", "ff549b27-9c5b-4fbd-96a7-c4939e24e4ae", "Usuario", "USUARIO" },
                    { "853fe18a-f66a-411a-921f-d26c1db82fd3", "3b1592a5-0dd7-438c-812a-bf9be072df39", "SuperUsuario", "SUPERUSUARIO" },
                    { "f12b3e1a-c51b-4d40-ac77-c3b128d71bf5", "70ed47a2-0484-4042-a28e-ed86362d72ba", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02a22cd3-f1a1-4303-bef6-b3b69e339699", 0, "d897a2db-12f6-4b6d-99a6-0bb7b2d8cbaf", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEHG/1Wy/ug4LQikLmVJbIFfxx55nXzKoEbeZAA/gkLpP3fGH8GfuBq/F0jYSmjzGwg==", null, false, "c97fdd6a-e3b4-4e10-a58a-b302761cabae", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "853fe18a-f66a-411a-921f-d26c1db82fd3", "02a22cd3-f1a1-4303-bef6-b3b69e339699" });
        }
    }
}
