using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.DAL.Migrations
{
    public partial class Addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "malewski@wp.pl", "Andrzej", "Malewski" },
                    { 2, "moleda@wp.pl", "Marcin", "Malędowski" },
                    { 3, "kowalewicz@wp.pl", "Krzysztof", "Kowalewicz" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum...", "Xanax", "Depression" },
                    { 2, "Lorem", "Abilify", "Tabletki" },
                    { 3, "Lorem ips", "Abra", "Żel" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 22, 4, 42, 337, DateTimeKind.Local).AddTicks(9347), "Jan", "Andrzejewski" },
                    { 2, new DateTime(2021, 5, 24, 22, 4, 42, 340, DateTimeKind.Local).AddTicks(5365), "Krzysztof", "Kowalewicz" },
                    { 3, new DateTime(2021, 5, 24, 22, 4, 42, 340, DateTimeKind.Local).AddTicks(5411), "Marcin", "Andrzejewicz" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2019, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2009, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2013, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), 3, 3 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdPrescriptionMedicament", "Details", "Dose", "IdMedicament", "IdPrescription" },
                values: new object[] { 1, "Take every morning", 4, 1, 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdPrescriptionMedicament", "Details", "Dose", "IdMedicament", "IdPrescription" },
                values: new object[] { 2, "Once a week", 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdPrescriptionMedicament", "Details", "Dose", "IdMedicament", "IdPrescription" },
                values: new object[] { 3, "once every two weeks", 3, 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumn: "IdPrescriptionMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumn: "IdPrescriptionMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumn: "IdPrescriptionMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
