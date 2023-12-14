﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserMorph.DataManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "HR" },
                    { 3, "Lead" },
                    { 4, "Admin" },
                    { 5, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Company", "FirstName", "IsActive", "LastName", "Sex" },
                values: new object[,]
                {
                    { 1, "DSi", "Aurpan", true, "Dash", (byte)0 },
                    { 2, "CEL", "Aurgha", true, "Dash", (byte)0 },
                    { 3, "XYZ", "Jannatul", true, "Ferdaus", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "UserContact",
                columns: new[] { "Id", "Address", "City", "Country", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1, "Mirpur", "Dhaka", "BD", "01667002233", 1 },
                    { 2, "Hatirjheel", "Dhaka", "BD", "01767002233", 1 },
                    { 3, "Uttara", "Dhaka", "BD", "01557992233", 2 },
                    { 4, "Banani", "Dhaka", "BD", "01652937539", 2 },
                    { 5, "Oxyzen", "Ctg", "BD", "01557992233", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserContact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserContact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserContact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserContact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserContact",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
