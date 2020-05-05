using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class AddingChatToTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48792bae-956f-4a57-b5bb-d578f57ed457");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8daa80d2-c4dd-4a71-be0a-b326c576ae00");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "1acb196b-794b-4335-b859-ff5f1635b41f", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "cf8d2d94-82f1-4d37-b1a1-73adfb647c83", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "089c1f6d-80db-4f9c-a7a8-1eae1f0d6c56", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "bc3fea00-1a32-4c4e-8cd6-5546fb76677c", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "5adc3623-af62-4dc6-9a23-1b2bf105458b", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "d70e44df-3705-4c81-bcd9-0440515419db", 1011, "300", false, "2", null });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1acb196b-794b-4335-b859-ff5f1635b41f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc3fea00-1a32-4c4e-8cd6-5546fb76677c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "8daa80d2-c4dd-4a71-be0a-b326c576ae00", 0, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "45b38971-f1d3-4f3f-8f48-ee063c251228", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Aliaksandra", "gtr", "Hrechka", false, null, "Guitar, Choir", null, null, null, "970-777-7777", null, false, "RA", "75b81d23-cde6-4657-8908-07e6ea795d3d", 1010, "500", false, "1", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Bio", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "InstrumentID", "LastName", "LockoutEnabled", "LockoutEnd", "MyClasses", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SchoolID", "SecurityStamp", "StudentNumber", "TeacherID", "TwoFactorEnabled", "UserID", "UserName" },
                values: new object[] { "48792bae-956f-4a57-b5bb-d578f57ed457", 0, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", "4e981466-d168-4b6b-87a0-97c362cc4b22", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Stacy", "pno", "Miller", false, null, "Piano, Choir", null, null, null, "720-303-6367", null, false, "HSM", "3e40bf73-65ca-4e68-8e3c-67297fbed258", 1011, "300", false, "2", null });
        }
    }
}
