using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountEmail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentID);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StudentNumber = table.Column<int>(nullable: false),
                    MyClasses = table.Column<string>(nullable: true),
                    SchoolID = table.Column<int>(nullable: false),
                    InstrumentID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false),
                    AccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Instruments_InstrumentID",
                        column: x => x.InstrumentID,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Schools_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "Schools",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ImageTitle = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountID", "AccountEmail", "Password" },
                values: new object[,]
                {
                    { 1, "ahrechka@gmail.com", "123" },
                    { 2, "stacym@gmail.com", "123" }
                });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentID", "InstrumentName" },
                values: new object[,]
                {
                    { 1, "Guitar" },
                    { 2, "Piano" },
                    { 3, "Violin" },
                    { 4, "Chello" },
                    { 5, "Saxophone" },
                    { 6, "Triangle" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolID", "SchoolName" },
                values: new object[,]
                {
                    { 1, "Rock Academy" },
                    { 2, "Harmony School of Music" },
                    { 3, "Centennial Piano School" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherID", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Andrew", "Rusinn", "720 666-4567" },
                    { 2, "Maria", "Ortega", "720 122-0809" },
                    { 3, "Lorena", "Kirkland", "720 898-3839" },
                    { 4, "Olga", "Kostenko", "303 920 1764" },
                    { 5, "John", "Stivens", "720 009-1890" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AccountID", "Address", "Bio", "DateOfBirth", "Email", "FirstName", "InstrumentID", "LastName", "MyClasses", "Phone", "SchoolID", "StudentNumber", "TeacherID" },
                values: new object[] { 1, 1, "9999 E Orange St, Aurora, CO, 80011", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahrechka@mail.com", "Aliaksandra", 1, "Hrechka", "Guitar, Choir", "970-777-7777", 2, 1010, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AccountID", "Address", "Bio", "DateOfBirth", "Email", "FirstName", "InstrumentID", "LastName", "MyClasses", "Phone", "SchoolID", "StudentNumber", "TeacherID" },
                values: new object[] { 2, 2, "367 S Limone St, Denver, CO, 80235", "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.", new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "smiller16@mail.com", "Stacy", 2, "Miller", "Piano, Choir", "720-303-6367", 3, 1011, 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ImageData", "ImageTitle", "UserID" },
                values: new object[] { 2, null, "", 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ImageData", "ImageTitle", "UserID" },
                values: new object[] { 1, null, "crow.png", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserID",
                table: "Images",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountID",
                table: "Users",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstrumentID",
                table: "Users",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolID",
                table: "Users",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherID",
                table: "Users",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
