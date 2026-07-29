using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventSupportApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waktu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aksi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusAktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MappingTeknisi",
                columns: table => new
                {
                    IdTeknisi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Spesialisasi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StatusKetersediaan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingTeknisi", x => x.IdTeknisi);
                    table.ForeignKey(
                        name: "FK_MappingTeknisi_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    IdNotification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NamaAcara = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.IdNotification);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportAcara",
                columns: table => new
                {
                    IdAcara = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPembuatAcara = table.Column<int>(type: "int", nullable: false),
                    NamaAcara = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JamMulai = table.Column<TimeSpan>(type: "time", nullable: false),
                    JamSelesai = table.Column<TimeSpan>(type: "time", nullable: false),
                    Lokasi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusAcara = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportAcara", x => x.IdAcara);
                    table.ForeignKey(
                        name: "FK_SupportAcara_Users_IdPembuatAcara",
                        column: x => x.IdPembuatAcara,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KebutuhanAcara",
                columns: table => new
                {
                    IdKebutuhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAcara = table.Column<int>(type: "int", nullable: false),
                    NamaBarang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jumlah = table.Column<int>(type: "int", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsAmbil = table.Column<bool>(type: "bit", nullable: false),
                    IsKembali = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KebutuhanAcara", x => x.IdKebutuhan);
                    table.ForeignKey(
                        name: "FK_KebutuhanAcara_SupportAcara_IdAcara",
                        column: x => x.IdAcara,
                        principalTable: "SupportAcara",
                        principalColumn: "IdAcara",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penugasan",
                columns: table => new
                {
                    IdPenugasan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAcara = table.Column<int>(type: "int", nullable: false),
                    IdTeknisi = table.Column<int>(type: "int", nullable: false),
                    IdPenugasTeknisi = table.Column<int>(type: "int", nullable: false),
                    StatusPenugasan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WaktuKonfirmasi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DokumentasiKegiatanFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaktuUpload = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    CatatanTeknisi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penugasan", x => x.IdPenugasan);
                    table.ForeignKey(
                        name: "FK_Penugasan_MappingTeknisi_IdTeknisi",
                        column: x => x.IdTeknisi,
                        principalTable: "MappingTeknisi",
                        principalColumn: "IdTeknisi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Penugasan_SupportAcara_IdAcara",
                        column: x => x.IdAcara,
                        principalTable: "SupportAcara",
                        principalColumn: "IdAcara",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Penugasan_Users_IdPenugasTeknisi",
                        column: x => x.IdPenugasTeknisi,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiskusiPenugasan",
                columns: table => new
                {
                    IdDiskusi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPenugasan = table.Column<int>(type: "int", nullable: false),
                    IdAcara = table.Column<int>(type: "int", nullable: false),
                    IdUserPengirim = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRole", "NamaRole" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Helpdesk" },
                    { 3, "Teknisi" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "IdRole", "Password", "StatusAktif", "Username" },
                values: new object[,]
                {
                    { 1, 1, "123", true, "admin" },
                    { 2, 2, "123", true, "helpdesk" },
                    { 3, 3, "123", true, "pak_joko" },
                    { 4, 3, "123", true, "pak_budi" },
                    { 5, 3, "123", true, "pak_bambang" }
                });

            migrationBuilder.InsertData(
                table: "MappingTeknisi",
                columns: new[] { "IdTeknisi", "IdUser", "Spesialisasi", "StatusKetersediaan" },
                values: new object[,]
                {
                    { 1, 3, "Sound System & Audio", "Tersedia" },
                    { 2, 4, "Proyektor & Layar Lebar", "Tersedia" },
                    { 3, 5, "Multimedia & Kelistrikan", "Sibuk" }
                });

            migrationBuilder.InsertData(
                table: "SupportAcara",
                columns: new[] { "IdAcara", "IdPembuatAcara", "JamMulai", "JamSelesai", "Lokasi", "NamaAcara", "StatusAcara", "Tanggal" },
                values: new object[,]
                {
                    { 1, 2, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Gedung Rektorat Lt. 1", "Rapat Pleno Dekanat", "Selesai", new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Auditorium BJ Habibie", "Seminar Nasional IT & AI", "Ditugaskan", new DateTime(2026, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Aula Utama Gedung Rektorat Lt. 3", "Rapat Pleno Senat Universitas", "Ditugaskan", new DateTime(2026, 7, 28, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "KebutuhanAcara",
                columns: new[] { "IdKebutuhan", "IdAcara", "IsAmbil", "IsKembali", "Jumlah", "Keterangan", "NamaBarang" },
                values: new object[,]
                {
                    { 1, 1, true, true, 1, "Proyektor utama & Layar gantung", "Proyektor" },
                    { 2, 1, true, true, 1, "Microphone wireless 4 buah & Audio Mixer", "Sound System" },
                    { 3, 1, true, true, 4, "", "Mic Wireless" },
                    { 4, 2, false, false, 1, "Videotron latar panggung utama", "Proyektor" },
                    { 5, 2, false, false, 1, "Sound system outdoor", "Sound System" },
                    { 6, 3, false, false, 1, "Proyektor utama & Layar gantung", "Proyektor" }
                });

            migrationBuilder.InsertData(
                table: "Penugasan",
                columns: new[] { "IdPenugasan", "CatatanTeknisi", "DokumentasiKegiatanFile", "IdAcara", "IdPenugasTeknisi", "IdTeknisi", "Progress", "StatusPenugasan", "WaktuKonfirmasi", "WaktuUpload" },
                values: new object[,]
                {
                    { 1, null, "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=300&h=300&fit=crop", 1, 1, 1, 100, "Selesai", null, null },
                    { 2, null, null, 2, 1, 1, 0, "Ditugaskan", null, null },
                    { 3, null, null, 3, 1, 2, 0, "Ditugaskan", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiskusiPenugasan_IdPenugasan",
                table: "DiskusiPenugasan",
                column: "IdPenugasan");

            migrationBuilder.CreateIndex(
                name: "IX_DiskusiPenugasan_IdUserPengirim",
                table: "DiskusiPenugasan",
                column: "IdUserPengirim");

            migrationBuilder.CreateIndex(
                name: "IX_KebutuhanAcara_IdAcara",
                table: "KebutuhanAcara",
                column: "IdAcara");

            migrationBuilder.CreateIndex(
                name: "IX_MappingTeknisi_IdUser",
                table: "MappingTeknisi",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdUser",
                table: "Notifications",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Penugasan_IdAcara",
                table: "Penugasan",
                column: "IdAcara");

            migrationBuilder.CreateIndex(
                name: "IX_Penugasan_IdPenugasTeknisi",
                table: "Penugasan",
                column: "IdPenugasTeknisi");

            migrationBuilder.CreateIndex(
                name: "IX_Penugasan_IdTeknisi",
                table: "Penugasan",
                column: "IdTeknisi");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAcara_IdPembuatAcara",
                table: "SupportAcara",
                column: "IdPembuatAcara");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DiskusiPenugasan");

            migrationBuilder.DropTable(
                name: "KebutuhanAcara");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Penugasan");

            migrationBuilder.DropTable(
                name: "MappingTeknisi");

            migrationBuilder.DropTable(
                name: "SupportAcara");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
