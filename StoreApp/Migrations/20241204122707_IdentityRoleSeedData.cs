using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0813c387-4f4a-40d9-a08c-141c1d56959d", "fb8ae4b0-663d-4f13-a373-4c798578a171", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b335610d-32e9-4a6c-bfbc-fbbc9f2e1d7b", "1d62977b-e6ab-4624-aea9-00d74aa296ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbf5a201-b7df-47c2-893d-2aefd95b5eaa", "a3b9c774-acab-463f-ba0a-a5292c9f913e", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0813c387-4f4a-40d9-a08c-141c1d56959d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b335610d-32e9-4a6c-bfbc-fbbc9f2e1d7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbf5a201-b7df-47c2-893d-2aefd95b5eaa");
        }
    }
}
