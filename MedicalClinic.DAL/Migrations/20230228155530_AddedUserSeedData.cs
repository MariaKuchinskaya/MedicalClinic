using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserType" },
                values: new object[] { 1, "mary11@gmail.com", "443c4ae87a0c358f1b2ee93692938444", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
