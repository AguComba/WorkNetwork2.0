using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class datetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4cc35ee0-4909-4e64-85c6-6b686c487caa", "3462487d-f03e-4704-8883-e71bec299a85", "SuperUsuario", "SUPERUSUARIO" },
                    { "634cc5b0-2815-49be-a318-a1c164fed568", "a76dbf19-15e2-4c5d-a25b-e55a11c2c25b", "Empresa", "EMPRESA" },
                    { "b1bc9dce-7627-457b-b82b-008137daaa17", "c6e6cbd5-b9f3-4ff6-b9da-993dad45e39f", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "35a510eb-4784-413b-8c31-3404881c2caf", 0, "82e48832-5d2e-45d2-84f1-cfea5b2d3b21", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEC/3ttDVCA21wv8inz1Q7lu4dB2HB6gw1fM4pGeovgoZxz6shGZAD/KBeX83VG+sSA==", null, false, "e36ee09e-5588-481b-b373-f862e93d799d", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cc35ee0-4909-4e64-85c6-6b686c487caa", "35a510eb-4784-413b-8c31-3404881c2caf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "634cc5b0-2815-49be-a318-a1c164fed568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bc9dce-7627-457b-b82b-008137daaa17");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cc35ee0-4909-4e64-85c6-6b686c487caa", "35a510eb-4784-413b-8c31-3404881c2caf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc35ee0-4909-4e64-85c6-6b686c487caa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35a510eb-4784-413b-8c31-3404881c2caf");

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
    }
}
