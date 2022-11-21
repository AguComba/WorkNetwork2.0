using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class RedesPersonasNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
