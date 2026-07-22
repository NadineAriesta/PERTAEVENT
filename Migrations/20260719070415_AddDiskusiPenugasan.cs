using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventSupportApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDiskusiPenugasan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiwayatAcara",
                columns: table => new
                {
                    IdRiwayat = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAcara = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPenugasan = table.Column<int>(type: "INTEGER", nullable: false),
                    NamaAcara = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NamaTeknisi = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TanggalAcara = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DokumentasiKegiatanFile = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    WaktuSelesai = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatAcara", x => x.IdRiwayat);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaRole = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Deskripsi = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StatusAktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "MappingTeknisi",
                columns: table => new
                {
                    IdTeknisi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    Spesialisasi = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    StatusKetersediaan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
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
                    IdNotification = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
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
                    IdAcara = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUserHelpdesk = table.Column<int>(type: "INTEGER", nullable: false),
                    NamaAcara = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Tanggal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JamMulai = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    JamSelesai = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Lokasi = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StatusAcara = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportAcara", x => x.IdAcara);
                    table.ForeignKey(
                        name: "FK_SupportAcara_Users_IdUserHelpdesk",
                        column: x => x.IdUserHelpdesk,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    IdUserRole = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.IdUserRole);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KebutuhanAcara",
                columns: table => new
                {
                    IdKebutuhan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAcara = table.Column<int>(type: "INTEGER", nullable: false),
                    JenisKebutuhan = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Jumlah = table.Column<int>(type: "INTEGER", nullable: false),
                    Keterangan = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
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
                    IdPenugasan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdAcara = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTeknisi = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUserAdmin = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusPenugasan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WaktuKonfirmasi = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DokumentasiKegiatanFile = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    WaktuUpload = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Progress = table.Column<int>(type: "INTEGER", nullable: false),
                    CatatanTeknisi = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    AlasanPenolakan = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penugasan", x => x.IdPenugasan);
                    table.ForeignKey(
                        name: "FK_Penugasan_MappingTeknisi_IdTeknisi",
                        column: x => x.IdTeknisi,
                        principalTable: "MappingTeknisi",
                        principalColumn: "IdTeknisi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penugasan_SupportAcara_IdAcara",
                        column: x => x.IdAcara,
                        principalTable: "SupportAcara",
                        principalColumn: "IdAcara",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penugasan_Users_IdUserAdmin",
                        column: x => x.IdUserAdmin,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiskusiPenugasan",
                columns: table => new
                {
                    IdDiskusi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPenugasan = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUserPengirim = table.Column<int>(type: "INTEGER", nullable: false),
                    Pesan = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    WaktuKirim = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiskusiPenugasan", x => x.IdDiskusi);
                    table.ForeignKey(
                        name: "FK_DiskusiPenugasan_Penugasan_IdPenugasan",
                        column: x => x.IdPenugasan,
                        principalTable: "Penugasan",
                        principalColumn: "IdPenugasan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiskusiPenugasan_Users_IdUserPengirim",
                        column: x => x.IdUserPengirim,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRole", "Deskripsi", "NamaRole" },
                values: new object[,]
                {
                    { 1, "Administrator yang menugaskan teknisi dan melihat laporan", "Admin" },
                    { 2, "Staff yang memasukkan data acara dan kebutuhan support", "Helpdesk" },
                    { 3, "Staff teknis lapangan yang bertugas mensupport acara", "Teknisi" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Password", "StatusAktif", "Username" },
                values: new object[,]
                {
                    { 1, "123", true, "admin" },
                    { 2, "123", true, "helpdesk" },
                    { 3, "123", true, "pak_joko" },
                    { 4, "123", true, "pak_budi" },
                    { 5, "123", true, "pak_bambang" }
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
                columns: new[] { "IdAcara", "IdUserHelpdesk", "JamMulai", "JamSelesai", "Lokasi", "NamaAcara", "StatusAcara", "Tanggal" },
                values: new object[,]
                {
                    { 1, 2, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Aula Utama Gedung Rektorat Lt. 3", "Rapat Pleno Senat Universitas", "Belum Ditugaskan", new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 16, 30, 0, 0), "Auditorium BJ Habibie", "Seminar Nasional IT & AI", "Belum Ditugaskan", new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "IdUserRole", "IdRole", "IdUser" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "KebutuhanAcara",
                columns: new[] { "IdKebutuhan", "IdAcara", "JenisKebutuhan", "Jumlah", "Keterangan" },
                values: new object[,]
                {
                    { 1, 1, "Sound System", 1, "Microphone wireless 4 buah & Audio Mixer" },
                    { 2, 1, "Proyektor", 1, "Proyektor utama & Layar gantung" },
                    { 3, 2, "Layar LED", 1, "Videotron latar panggung utama" },
                    { 4, 2, "Sound System", 1, "Sound system konser outdoor / semi-indoor" }
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
                name: "IX_Penugasan_IdTeknisi",
                table: "Penugasan",
                column: "IdTeknisi");

            migrationBuilder.CreateIndex(
                name: "IX_Penugasan_IdUserAdmin",
                table: "Penugasan",
                column: "IdUserAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_SupportAcara_IdUserHelpdesk",
                table: "SupportAcara",
                column: "IdUserHelpdesk");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IdRole",
                table: "UserRoles",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IdUser",
                table: "UserRoles",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiskusiPenugasan");

            migrationBuilder.DropTable(
                name: "KebutuhanAcara");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RiwayatAcara");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Penugasan");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MappingTeknisi");

            migrationBuilder.DropTable(
                name: "SupportAcara");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
