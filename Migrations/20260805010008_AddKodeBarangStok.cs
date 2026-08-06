using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventSupportApp.Migrations
{
    /// <inheritdoc />
    public partial class AddKodeBarangStok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskusiPenugasan");

            migrationBuilder.DropColumn(
                name: "Lokasi",
                table: "SupportAcara");

            migrationBuilder.DropColumn(
                name: "NamaBarang",
                table: "KebutuhanAcara");

            migrationBuilder.AddColumn<int>(
                name: "IdLokasi",
                table: "SupportAcara",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdBarang",
                table: "KebutuhanAcara",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MasterBarang",
                columns: table => new
                {
                    IdBarang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaBarang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KodeBarang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JumlahStok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBarang", x => x.IdBarang);
                });

            migrationBuilder.CreateTable(
                name: "MasterLokasi",
                columns: table => new
                {
                    IdLokasi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaLokasi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLokasi", x => x.IdLokasi);
                });

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 1,
                column: "IdBarang",
                value: 1);

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 2,
                column: "IdBarang",
                value: 3);

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 3,
                column: "IdBarang",
                value: 4);

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 4,
                column: "IdBarang",
                value: 12);

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 5,
                column: "IdBarang",
                value: 3);

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 6,
                column: "IdBarang",
                value: 1);

            migrationBuilder.InsertData(
                table: "MasterBarang",
                columns: new[] { "IdBarang", "Icon", "JumlahStok", "Kategori", "KodeBarang", "NamaBarang" },
                values: new object[,]
                {
                    { 1, "📹", 5, "Video", "VID-01", "Proyektor" },
                    { 2, "🖥️", 4, "Video", "VID-02", "Layar Proyektor" },
                    { 3, "🔊", 3, "Audio", "AUD-01", "Sound System" },
                    { 4, "🎤", 10, "Audio", "AUD-02", "Mic Wireless" },
                    { 5, "🎤", 8, "Audio", "AUD-03", "Mic Kabel" },
                    { 6, "💻", 6, "Komputer", "KOM-01", "Laptop" },
                    { 7, "🔌", 15, "Kelistrikan", "ELC-01", "Kabel Roll" },
                    { 8, "🔌", 20, "Kelistrikan", "ELC-02", "Kabel HDMI" },
                    { 9, "📍", 7, "Aksesoris", "AKS-01", "Pointer Presentasi" },
                    { 10, "📷", 5, "Video", "VID-03", "Webcam" },
                    { 11, "🎛️", 3, "Audio", "AUD-04", "Mixer Audio" },
                    { 12, "📺", 2, "Video", "VID-04", "Videotron / LED Wall" }
                });

            migrationBuilder.InsertData(
                table: "MasterLokasi",
                columns: new[] { "IdLokasi", "Keterangan", "NamaLokasi" },
                values: new object[,]
                {
                    { 1, "Gedung amanah Lantai 1", "Gedung amanah Lt. 1" },
                    { 2, "Gedung amanah Lantai 2", "Gedung amanah Lt. 2" },
                    { 3, "Gedung kompeten pintu depan", "Gedung kompeten (pintu depan)" },
                    { 4, "Gedung kompeten pintu belakang", "Gedung kompeten (pintu belakang)" },
                    { 5, "Gedung kolaboratif Lantai 1", "Gedung kolaboratif Lt.1" },
                    { 6, "Gedung kolaboratif Lantai 2", "Gedung kolaboratif Lt.2" }
                });

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 1,
                column: "IdLokasi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 2,
                column: "IdLokasi",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 3,
                columns: new[] { "IdLokasi", "Tanggal" },
                values: new object[] { 3, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_SupportAcara_IdLokasi",
                table: "SupportAcara",
                column: "IdLokasi");

            migrationBuilder.CreateIndex(
                name: "IX_KebutuhanAcara_IdBarang",
                table: "KebutuhanAcara",
                column: "IdBarang");

            migrationBuilder.AddForeignKey(
                name: "FK_KebutuhanAcara_MasterBarang_IdBarang",
                table: "KebutuhanAcara",
                column: "IdBarang",
                principalTable: "MasterBarang",
                principalColumn: "IdBarang",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportAcara_MasterLokasi_IdLokasi",
                table: "SupportAcara",
                column: "IdLokasi",
                principalTable: "MasterLokasi",
                principalColumn: "IdLokasi",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KebutuhanAcara_MasterBarang_IdBarang",
                table: "KebutuhanAcara");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportAcara_MasterLokasi_IdLokasi",
                table: "SupportAcara");

            migrationBuilder.DropTable(
                name: "MasterBarang");

            migrationBuilder.DropTable(
                name: "MasterLokasi");

            migrationBuilder.DropIndex(
                name: "IX_SupportAcara_IdLokasi",
                table: "SupportAcara");

            migrationBuilder.DropIndex(
                name: "IX_KebutuhanAcara_IdBarang",
                table: "KebutuhanAcara");

            migrationBuilder.DropColumn(
                name: "IdLokasi",
                table: "SupportAcara");

            migrationBuilder.DropColumn(
                name: "IdBarang",
                table: "KebutuhanAcara");

            migrationBuilder.AddColumn<string>(
                name: "Lokasi",
                table: "SupportAcara",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NamaBarang",
                table: "KebutuhanAcara",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DiskusiPenugasan",
                columns: table => new
                {
                    IdDiskusi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPenugasan = table.Column<int>(type: "int", nullable: false),
                    IdUserPengirim = table.Column<int>(type: "int", nullable: false),
                    IdAcara = table.Column<int>(type: "int", nullable: false),
                    Pesan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    WaktuKirim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskusiPenugasan", x => x.IdDiskusi);
                    table.ForeignKey(
                        name: "FK_DiskusiPenugasan_Penugasan_IdPenugasan",
                        column: x => x.IdPenugasan,
                        principalTable: "Penugasan",
                        principalColumn: "IdPenugasan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiskusiPenugasan_Users_IdUserPengirim",
                        column: x => x.IdUserPengirim,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 1,
                column: "NamaBarang",
                value: "Proyektor");

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 2,
                column: "NamaBarang",
                value: "Sound System");

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 3,
                column: "NamaBarang",
                value: "Mic Wireless");

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 4,
                column: "NamaBarang",
                value: "Proyektor");

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 5,
                column: "NamaBarang",
                value: "Sound System");

            migrationBuilder.UpdateData(
                table: "KebutuhanAcara",
                keyColumn: "IdKebutuhan",
                keyValue: 6,
                column: "NamaBarang",
                value: "Proyektor");

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 1,
                column: "Lokasi",
                value: "Gedung Rektorat Lt. 1");

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 2,
                column: "Lokasi",
                value: "Auditorium BJ Habibie");

            migrationBuilder.UpdateData(
                table: "SupportAcara",
                keyColumn: "IdAcara",
                keyValue: 3,
                columns: new[] { "Lokasi", "Tanggal" },
                values: new object[] { "Aula Utama Gedung Rektorat Lt. 3", new DateTime(2026, 7, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_DiskusiPenugasan_IdPenugasan",
                table: "DiskusiPenugasan",
                column: "IdPenugasan");

            migrationBuilder.CreateIndex(
                name: "IX_DiskusiPenugasan_IdUserPengirim",
                table: "DiskusiPenugasan",
                column: "IdUserPengirim");
        }
    }
}
