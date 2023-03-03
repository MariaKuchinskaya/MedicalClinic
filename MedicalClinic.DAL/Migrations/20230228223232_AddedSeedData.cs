using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Analyzes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Blood" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Surname", "UserId" },
                values: new object[] { 2, "mary11@gmail.com", "Mary", "555", "Pavlova", 1 });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Cordiology" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserType" },
                values: new object[,]
                {
                    { 2, "kate@gmail.com", "115067039670abb4571a74e8e8585e5d", 1 },
                    { 3, "lena@gmail.com", "20398ce448540c947edc4c30399e2ced", 2 }
                });

            migrationBuilder.InsertData(
                table: "AnalyzesResults",
                columns: new[] { "Id", "AnalyzeId", "PatientId", "Result", "TimeStamp" },
                values: new object[] { 1, 1, 2, "Bad", new DateTime(2023, 2, 28, 23, 32, 32, 523, DateTimeKind.Local).AddTicks(6372) });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "SpecialityId", "Surname", "UserId" },
                values: new object[] { 1, "lena@gmail.com", "Lena", "999", 1, "Petrova", 3 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Surname", "UserId" },
                values: new object[] { 1, "kate@gmail.com", "Kate", "666", "Pavlova", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "PatientId", "Results", "TimeStamp" },
                values: new object[] { 1, 1, 2, "Bad", new DateTime(2023, 2, 28, 23, 32, 32, 523, DateTimeKind.Local).AddTicks(6438) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnalyzesResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Analyzes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
