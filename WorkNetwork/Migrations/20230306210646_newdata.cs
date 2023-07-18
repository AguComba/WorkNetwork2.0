using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
