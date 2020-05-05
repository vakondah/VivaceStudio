using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class TimeSentAddedToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1acb196b-794b-4335-b859-ff5f1635b41f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc3fea00-1a32-4c4e-8cd6-5546fb76677c");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeSent",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "9e0cc75b-bd26-4946-81df-d86616a6de2f", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "fb659f9b-8503-44d3-aa2e-4ccd6e987c9e", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "6711dc6d-f634-43b8-b5fb-adf2dcca9ef4", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "ebdd96d6-3331-49b4-a5ef-b63a4e3c74ca", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "57c3c958-1977-4a5c-b171-35049ce3824b", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "c19e3d26-b5fe-4e62-839c-505328355404", 1011, "300", false, "2", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0cc75b-bd26-4946-81df-d86616a6de2f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebdd96d6-3331-49b4-a5ef-b63a4e3c74ca");

            migrationBuilder.DropColumn(
                name: "TimeSent",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "1acb196b-794b-4335-b859-ff5f1635b41f", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "cf8d2d94-82f1-4d37-b1a1-73adfb647c83", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "089c1f6d-80db-4f9c-a7a8-1eae1f0d6c56", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "bc3fea00-1a32-4c4e-8cd6-5546fb76677c", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "5adc3623-af62-4dc6-9a23-1b2bf105458b", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "d70e44df-3705-4c81-bcd9-0440515419db", 1011, "300", false, "2", null });
        }
    }
}
