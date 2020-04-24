using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class newTeacherID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d5b12fa-ba1d-4af4-904e-d10fd0c72e14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d10a9da3-15cb-48c6-8f78-f320219c3b1e");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "a4adfb21-0785-4613-930c-94097512c240", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "3b9a064c-52b4-4e23-8c26-22bb36ce8b92", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "1fe2a0b1-a81a-4ff3-b2e8-fb43318bcc3c", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "d3da6015-9063-4376-9dbb-47e4e473a6e5", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "aefde5e0-7405-4bcc-a3fd-a5bb7e0b091c", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "91dbc8de-5dd8-4ae6-baab-48ed83d5d4d4", 1011, "300", false, "2", null });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherID",
                table: "AspNetUsers",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherID",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4adfb21-0785-4613-930c-94097512c240");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3da6015-9063-4376-9dbb-47e4e473a6e5");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherID",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "3d5b12fa-ba1d-4af4-904e-d10fd0c72e14", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "f9055171-8000-4aaf-ba5a-0b14064b7cb7", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "ba559306-f248-42de-a227-dbba6ac51c1c", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "d10a9da3-15cb-48c6-8f78-f320219c3b1e", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "959f6529-7e63-4223-8862-65e19f0e0ef9", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "9817647f-fa5d-4643-9b70-c1c5e7c9881c", 1011, "300", false, "2", null });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teachers_TeacherID",
                table: "AspNetUsers",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
