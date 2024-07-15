using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpDateOnSumColumnsinTabelsStudentandDepatmentandInstrctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "School");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subjects",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "StudentSubjects",
                newName: "StudentSubjects",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructor",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Ins_Subject",
                newName: "Ins_Subject",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "DepartmetSubjects",
                newName: "DepartmetSubjects",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departments",
                newSchema: "School");

            migrationBuilder.RenameColumn(
                name: "SubjectNameEn",
                schema: "School",
                table: "Subjects",
                newName: "Name in English");

            migrationBuilder.RenameColumn(
                name: "SubjectNameAr",
                schema: "School",
                table: "Subjects",
                newName: "Name in Arabic ");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                schema: "School",
                table: "Students",
                newName: "Name in English");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                schema: "School",
                table: "Students",
                newName: "Name in Arabic ");

            migrationBuilder.RenameColumn(
                name: "ENameEn",
                schema: "School",
                table: "Instructor",
                newName: "Name in English");

            migrationBuilder.RenameColumn(
                name: "ENameAr",
                schema: "School",
                table: "Instructor",
                newName: "Name in Arabic ");

            migrationBuilder.RenameColumn(
                name: "DNameEn",
                schema: "School",
                table: "Departments",
                newName: "Name in English");

            migrationBuilder.RenameColumn(
                name: "DNameAr",
                schema: "School",
                table: "Departments",
                newName: "Name in Arabic ");

            migrationBuilder.AlterColumn<string>(
                name: "Name in English",
                schema: "School",
                table: "Subjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in Arabic ",
                schema: "School",
                table: "Subjects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "School",
                table: "Students",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "School",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in English",
                schema: "School",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in Arabic ",
                schema: "School",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "School",
                table: "Instructor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "School",
                table: "Instructor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name in English",
                schema: "School",
                table: "Instructor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in Arabic ",
                schema: "School",
                table: "Instructor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in English",
                schema: "School",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name in Arabic ",
                schema: "School",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Subjects",
                schema: "School",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "StudentSubjects",
                schema: "School",
                newName: "StudentSubjects");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "School",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Instructor",
                schema: "School",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Ins_Subject",
                schema: "School",
                newName: "Ins_Subject");

            migrationBuilder.RenameTable(
                name: "DepartmetSubjects",
                schema: "School",
                newName: "DepartmetSubjects");

            migrationBuilder.RenameTable(
                name: "Departments",
                schema: "School",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "Name in English",
                table: "Subjects",
                newName: "SubjectNameEn");

            migrationBuilder.RenameColumn(
                name: "Name in Arabic ",
                table: "Subjects",
                newName: "SubjectNameAr");

            migrationBuilder.RenameColumn(
                name: "Name in English",
                table: "Students",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name in Arabic ",
                table: "Students",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "Name in English",
                table: "Instructor",
                newName: "ENameEn");

            migrationBuilder.RenameColumn(
                name: "Name in Arabic ",
                table: "Instructor",
                newName: "ENameAr");

            migrationBuilder.RenameColumn(
                name: "Name in English",
                table: "Departments",
                newName: "DNameEn");

            migrationBuilder.RenameColumn(
                name: "Name in Arabic ",
                table: "Departments",
                newName: "DNameAr");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameEn",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectNameAr",
                table: "Subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ENameEn",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENameAr",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNameEn",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
