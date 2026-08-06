using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventSupportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIconAddCodeStok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MasterBarang");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MasterBarang",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stok",
                table: "MasterBarang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 1,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "PRY-001", 5 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 2,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "LAY-001", 5 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 3,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "SND-001", 3 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 4,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "MCW-001", 10 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 5,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "MCK-001", 8 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 6,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "LPT-001", 4 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 7,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "KBR-001", 6 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 8,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "KBH-001", 10 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 9,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "PTR-001", 5 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 10,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "WBC-001", 3 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 11,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "MXR-001", 2 });

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 12,
                columns: new[] { "Code", "Stok" },
                values: new object[] { "VDT-001", 1 });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 1,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung amanah Lantai 1", "Gedung amanah Lt. 1" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 2,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung amanah Lantai 2", "Gedung amanah Lt. 2" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 3,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung kompeten pintu depan", "Gedung kompeten (pintu depan)" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 4,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung kompeten pintu belakang", "Gedung kompeten (pintu belakang)" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 5,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung kolaboratif Lantai 1", "Gedung kolaboratif Lt.1" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 6,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Gedung kolaboratif Lantai 2", "Gedung kolaboratif Lt.2" });

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 3,
                column: "Tanggal",
                value: new DateTime(2026, 8, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MasterBarang");

            migrationBuilder.DropColumn(
                name: "Stok",
                table: "MasterBarang");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MasterBarang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 1,
                column: "Icon",
                value: "📹");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 2,
                column: "Icon",
                value: "🖥️");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 3,
                column: "Icon",
                value: "🔊");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 4,
                column: "Icon",
                value: "🎤");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 5,
                column: "Icon",
                value: "🎤");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 6,
                column: "Icon",
                value: "💻");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 7,
                column: "Icon",
                value: "🔌");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 8,
                column: "Icon",
                value: "🔌");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 9,
                column: "Icon",
                value: "📍");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 10,
                column: "Icon",
                value: "📷");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 11,
                column: "Icon",
                value: "🎛️");

            migrationBuilder.UpdateData(
                table: "MasterBarang",
                keyColumn: "IdBarang",
                keyValue: 12,
                column: "Icon",
                value: "📺");

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 1,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Ruang rapat utama lantai 1", "Gedung Rektorat Lt. 1" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 2,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Ruang rapat lantai 2", "Gedung Rektorat Lt. 2" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 3,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Aula besar untuk acara resmi", "Gedung Rektorat Lt. 3 - Aula Utama" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 4,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Auditorium utama kampus", "Auditorium BJ Habibie" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 5,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Ruang serbaguna untuk seminar dan workshop", "Ruang Serbaguna Gedung B" });

            migrationBuilder.UpdateData(
                table: "MasterLokasi",
                keyColumn: "IdLokasi",
                keyValue: 6,
                columns: new[] { "Keterangan", "NamaLokasi" },
                values: new object[] { "Lab komputer untuk pelatihan", "Lab Komputer Gedung C" });

            migrationBuilder.InsertData(
                table: "MasterLokasi",
                columns: new[] { "IdLokasi", "Keterangan", "NamaLokasi" },
                values: new object[] { 7, "Area outdoor untuk event besar", "Lapangan Utama" });

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 3,
                column: "Tanggal",
                value: new DateTime(2026, 7, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
