using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class FKinPracticeLogChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeLog_AspNetUsers_UserID",
                table: "PracticeLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PracticeLog",
                table: "PracticeLog");

            migrationBuilder.DropIndex(
                name: "IX_PracticeLog_UserID",
                table: "PracticeLog");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4adfb21-0785-4613-930c-94097512c240");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3da6015-9063-4376-9dbb-47e4e473a6e5");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "PracticeLog");

            migrationBuilder.AlterColumn<int>(
                name: "PracticeLogID",
                table: "PracticeLog",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PracticeLog",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PracticeLog",
                table: "PracticeLog",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "7028af38-e34c-4a66-ae40-4f22e6af253d", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "719f6b48-2ce8-4014-a216-9cfa1fc6f75f", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "d5cc94ed-e70c-4da5-b16c-9d22c98174bf", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "cdc67bdd-d9a9-4194-9d32-09b2625c271c", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "22fa2d35-ae8f-4ae2-afec-e9e33064603c", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "29a69089-3a10-469a-bcf5-4e8c0852df40", 1011, "300", false, "2", null });

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeLog_AspNetUsers_Id",
                table: "PracticeLog",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PracticeLog_AspNetUsers_Id",
                table: "PracticeLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PracticeLog",
                table: "PracticeLog");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7028af38-e34c-4a66-ae40-4f22e6af253d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdc67bdd-d9a9-4194-9d32-09b2625c271c");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PracticeLog");

            migrationBuilder.AlterColumn<int>(
                name: "PracticeLogID",
                table: "PracticeLog",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "PracticeLog",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PracticeLog",
                table: "PracticeLog",
                column: "PracticeLogID");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "a4adfb21-0785-4613-930c-94097512c240", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "3b9a064c-52b4-4e23-8c26-22bb36ce8b92", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "1fe2a0b1-a81a-4ff3-b2e8-fb43318bcc3c", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "d3da6015-9063-4376-9dbb-47e4e473a6e5", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "aefde5e0-7405-4bcc-a3fd-a5bb7e0b091c", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "91dbc8de-5dd8-4ae6-baab-48ed83d5d4d4", 1011, "300", false, "2", null });

            migrationBuilder.CreateIndex(
                name: "IX_PracticeLog_UserID",
                table: "PracticeLog",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeLog_AspNetUsers_UserID",
                table: "PracticeLog",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
