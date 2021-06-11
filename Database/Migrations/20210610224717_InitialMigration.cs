using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cathedra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "Date", nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Workbook = table.Column<bool>(type: "bit", nullable: false),
                    Workplaces = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Contacts = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aspirants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ForeignLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnducationForm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EnducationDirection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cathedra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Faculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Decree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DissertationTheme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspirants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aspirants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aspirants_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Excellent = table.Column<bool>(type: "bit", nullable: false),
                    CountSatisfactoryMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enducations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "Date", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryExams_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryExams_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diploms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspirantId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountSatisfactoryMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diploms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diploms_Aspirants_AspirantId",
                        column: x => x.AspirantId,
                        principalTable: "Aspirants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspirantId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "Date", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Aspirants_AspirantId",
                        column: x => x.AspirantId,
                        principalTable: "Aspirants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aspirants_PersonId",
                table: "Aspirants",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Aspirants_TeacherId",
                table: "Aspirants",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Diploms_AspirantId",
                table: "Diploms",
                column: "AspirantId");

            migrationBuilder.CreateIndex(
                name: "IX_Enducations_PersonId",
                table: "Enducations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryExams_PersonId",
                table: "EntryExams",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryExams_TeacherId",
                table: "EntryExams",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_AspirantId",
                table: "Exams",
                column: "AspirantId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TeacherId",
                table: "Exams",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diploms");

            migrationBuilder.DropTable(
                name: "Enducations");

            migrationBuilder.DropTable(
                name: "EntryExams");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Aspirants");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
