using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class ModeloDePersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2da9f8d6-383d-4885-884f-e95f967bebae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d2aa42c-e4fc-4644-924c-de7c33bd38b9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "124364bf-22ae-4743-8641-3e028a1c7f8d", "ce356ee4-4510-4403-8c2d-183098594844" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "124364bf-22ae-4743-8641-3e028a1c7f8d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce356ee4-4510-4403-8c2d-183098594844");

            migrationBuilder.DropColumn(
                name: "CantidadHijos",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ImagenRecortada",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "SituacionLaboral",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Telefono2",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "TituloAcademico",
                table: "Persona",
                newName: "TipoCV");

            migrationBuilder.AddColumn<byte[]>(
                name: "Curriculum",
                table: "Persona",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "TipoCV",
                table: "Persona",
                newName: "TituloAcademico");

            migrationBuilder.AddColumn<int>(
                name: "CantidadHijos",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenRecortada",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SituacionLaboral",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefono2",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumento",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "124364bf-22ae-4743-8641-3e028a1c7f8d", "0996a0d9-7ef2-4edd-a07c-fbd0ca2e1f44", "SuperUsuario", "SUPERUSUARIO" },
                    { "2da9f8d6-383d-4885-884f-e95f967bebae", "91235342-ad10-487c-acd5-adfa01739ffa", "Usuario", "USUARIO" },
                    { "9d2aa42c-e4fc-4644-924c-de7c33bd38b9", "1ff1fe2b-4a6f-4ff1-9ca4-d97034898403", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce356ee4-4510-4403-8c2d-183098594844", 0, "e3acb226-986d-4169-bc11-cddc4a8bccb5", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAECV83WAD2lNdEpPjoSMk+hC67g0i6rNNfKUikw/6HlH84wL7e07ZtYIDLy3XiXbswg==", null, false, "5f98ca87-4789-404b-8572-704a02ebf154", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "124364bf-22ae-4743-8641-3e028a1c7f8d", "ce356ee4-4510-4403-8c2d-183098594844" });
        }
    }
}
