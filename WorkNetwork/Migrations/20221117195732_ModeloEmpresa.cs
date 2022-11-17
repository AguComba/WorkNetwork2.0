using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkNetwork.Migrations
{
    public partial class ModeloEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8373f26b-34da-4a06-a658-5f4dfd2fbaba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b22909f5-c51b-4fe6-9e48-e3cb632c09a7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3380b1f9-07df-401f-93a3-4e30701816bd", "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3380b1f9-07df-401f-93a3-4e30701816bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b");

            migrationBuilder.DropColumn(
                name: "NumeroDeDocumento",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "TipoEmpresa",
                table: "Empresa");

            migrationBuilder.RenameColumn(
                name: "Telefono2",
                table: "Empresa",
                newName: "Twitter");

            migrationBuilder.AlterColumn<string>(
                name: "CUIT",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Descripcion",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Empresa");

            migrationBuilder.RenameColumn(
                name: "Twitter",
                table: "Empresa",
                newName: "Telefono2");

            migrationBuilder.AlterColumn<int>(
                name: "CUIT",
                table: "Empresa",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NumeroDeDocumento",
                table: "Empresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoEmpresa",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3380b1f9-07df-401f-93a3-4e30701816bd", "a4187714-f350-40aa-a6e9-40216da05548", "SuperUsuario", "SUPERUSUARIO" },
                    { "8373f26b-34da-4a06-a658-5f4dfd2fbaba", "ac08c022-0235-49f5-9f21-d74482d78bb9", "Usuario", "USUARIO" },
                    { "b22909f5-c51b-4fe6-9e48-e3cb632c09a7", "9d993b3d-78f1-4e02-98df-616235eee5f2", "Empresa", "EMPRESA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b", 0, "6d3ff0a5-5c27-44fe-95c2-7270a0161d13", "ApplicationUser", "wkntk@gmail.com", false, false, null, "WKNTK@GMAIL.COM", "WKNTK@GMAIL.COM", "AQAAAAEAACcQAAAAEHL47gMg/YhBYnrXoACEK4kKqrt33zV/52h89T8gk97Q3HdwXRJRDkwWiuqpaje3dw==", null, false, "f68f8548-1d8f-443b-9451-387dde865078", false, "wkntk@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3380b1f9-07df-401f-93a3-4e30701816bd", "b3ee778a-fc8e-4490-8451-7f0cdc6f8d5b" });
        }
    }
}
