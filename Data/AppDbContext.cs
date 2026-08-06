using Microsoft.EntityFrameworkCore;

namespace EventSupportApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<MappingTeknisi> MappingTeknisi => Set<MappingTeknisi>();
        public DbSet<SupportAcara> SupportAcara => Set<SupportAcara>();
        public DbSet<KebutuhanAcara> KebutuhanAcara => Set<KebutuhanAcara>();
        public DbSet<Penugasan> Penugasan => Set<Penugasan>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<MasterLokasi> MasterLokasi => Set<MasterLokasi>();
        public DbSet<MasterBarang> MasterBarang => Set<MasterBarang>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========== SEED: Master Lokasi ==========
            modelBuilder.Entity<MasterLokasi>().HasData(
                new MasterLokasi { IdLokasi = 1, NamaLokasi = "Gedung amanah Lt. 1", Keterangan = "Gedung amanah Lantai 1" },
                new MasterLokasi { IdLokasi = 2, NamaLokasi = "Gedung amanah Lt. 2", Keterangan = "Gedung amanah Lantai 2" },
                new MasterLokasi { IdLokasi = 3, NamaLokasi = "Gedung kompeten (pintu depan)", Keterangan = "Gedung kompeten pintu depan" },
                new MasterLokasi { IdLokasi = 4, NamaLokasi = "Gedung kompeten (pintu belakang)", Keterangan = "Gedung kompeten pintu belakang" },
                new MasterLokasi { IdLokasi = 5, NamaLokasi = "Gedung kolaboratif Lt.1", Keterangan = "Gedung kolaboratif Lantai 1" },
                new MasterLokasi { IdLokasi = 6, NamaLokasi = "Gedung kolaboratif Lt.2", Keterangan = "Gedung kolaboratif Lantai 2" }
            );

            // ========== SEED: Master Barang ==========
            modelBuilder.Entity<MasterBarang>().HasData(
                new MasterBarang { IdBarang = 1,  Code = "PRY-001", NamaBarang = "Proyektor",            Kategori = "Video",       Stok = 5  },
                new MasterBarang { IdBarang = 2,  Code = "LAY-001", NamaBarang = "Layar Proyektor",      Kategori = "Video",       Stok = 5  },
                new MasterBarang { IdBarang = 3,  Code = "SND-001", NamaBarang = "Sound System",         Kategori = "Audio",       Stok = 3  },
                new MasterBarang { IdBarang = 4,  Code = "MCW-001", NamaBarang = "Mic Wireless",         Kategori = "Audio",       Stok = 10 },
                new MasterBarang { IdBarang = 5,  Code = "MCK-001", NamaBarang = "Mic Kabel",            Kategori = "Audio",       Stok = 8  },
                new MasterBarang { IdBarang = 6,  Code = "LPT-001", NamaBarang = "Laptop",               Kategori = "Komputer",    Stok = 4  },
                new MasterBarang { IdBarang = 7,  Code = "KBR-001", NamaBarang = "Kabel Roll",           Kategori = "Kelistrikan", Stok = 6  },
                new MasterBarang { IdBarang = 8,  Code = "KBH-001", NamaBarang = "Kabel HDMI",           Kategori = "Kelistrikan", Stok = 10 },
                new MasterBarang { IdBarang = 9,  Code = "PTR-001", NamaBarang = "Pointer Presentasi",   Kategori = "Aksesoris",   Stok = 5  },
                new MasterBarang { IdBarang = 10, Code = "WBC-001", NamaBarang = "Webcam",               Kategori = "Video",       Stok = 3  },
                new MasterBarang { IdBarang = 11, Code = "MXR-001", NamaBarang = "Mixer Audio",          Kategori = "Audio",       Stok = 2  },
                new MasterBarang { IdBarang = 12, Code = "VDT-001", NamaBarang = "Videotron / LED Wall", Kategori = "Video",       Stok = 1  }
            );

            // ========== SEED: Roles ==========
            modelBuilder.Entity<Role>().HasData(
                new Role { IdRole = 1, NamaRole = "Admin" },
                new Role { IdRole = 2, NamaRole = "Helpdesk" },
                new Role { IdRole = 3, NamaRole = "Teknisi" }
            );

            // ========== SEED: Users ==========
            modelBuilder.Entity<User>().HasData(
                new User { IdUser = 1, IdRole = 1, Username = "admin",       Password = "123", StatusAktif = true },
                new User { IdUser = 2, IdRole = 2, Username = "helpdesk",    Password = "123", StatusAktif = true },
                new User { IdUser = 3, IdRole = 3, Username = "pak_joko",    Password = "123", StatusAktif = true },
                new User { IdUser = 4, IdRole = 3, Username = "pak_budi",    Password = "123", StatusAktif = true },
                new User { IdUser = 5, IdRole = 3, Username = "pak_bambang", Password = "123", StatusAktif = true }
            );

            // ========== SEED: MappingTeknisi ==========
            modelBuilder.Entity<MappingTeknisi>().HasData(
                new MappingTeknisi { IdTeknisi = 1, IdUser = 3, Spesialisasi = "Sound System & Audio",      StatusKetersediaan = "Tersedia" },
                new MappingTeknisi { IdTeknisi = 2, IdUser = 4, Spesialisasi = "Proyektor & Layar Lebar",   StatusKetersediaan = "Tersedia" },
                new MappingTeknisi { IdTeknisi = 3, IdUser = 5, Spesialisasi = "Multimedia & Kelistrikan",  StatusKetersediaan = "Sibuk" }
            );

            // ========== SEED: SupportAcara (menggunakan IdLokasi) ==========
            modelBuilder.Entity<SupportAcara>().HasData(
                new SupportAcara
                {
                    IdAcara = 1,
                    IdPembuatAcara = 2,
                    NamaAcara = "Rapat Pleno Dekanat",
                    Tanggal = new DateTime(2026, 7, 23),
                    JamMulai = new TimeSpan(8, 0, 0),
                    JamSelesai = new TimeSpan(12, 0, 0),
                    IdLokasi = 1, // Gedung amanah Lt. 1
                    StatusAcara = "Selesai"
                },
                new SupportAcara
                {
                    IdAcara = 2,
                    IdPembuatAcara = 2,
                    NamaAcara = "Seminar Nasional IT & AI",
                    Tanggal = new DateTime(2026, 7, 25),
                    JamMulai = new TimeSpan(8, 0, 0),
                    JamSelesai = new TimeSpan(12, 0, 0),
                    IdLokasi = 4, // Gedung kompeten (pintu belakang)
                    StatusAcara = "Ditugaskan"
                },
                new SupportAcara
                {
                    IdAcara = 3,
                    IdPembuatAcara = 2,
                    NamaAcara = "Rapat Pleno Senat Universitas",
                    Tanggal = DateTime.Today,
                    JamMulai = new TimeSpan(9, 0, 0),
                    JamSelesai = new TimeSpan(12, 0, 0),
                    IdLokasi = 3, // Gedung kompeten (pintu depan)
                    StatusAcara = "Ditugaskan"
                }
            );

            // ========== SEED: KebutuhanAcara (menggunakan IdBarang) ==========
            modelBuilder.Entity<KebutuhanAcara>().HasData(
                new KebutuhanAcara { IdKebutuhan = 1, IdAcara = 1, IdBarang = 1,  Jumlah = 1,  Keterangan = "Proyektor utama & Layar gantung",         IsAmbil = true,  IsKembali = true  },
                new KebutuhanAcara { IdKebutuhan = 2, IdAcara = 1, IdBarang = 3,  Jumlah = 1,  Keterangan = "Microphone wireless 4 buah & Audio Mixer", IsAmbil = true,  IsKembali = true  },
                new KebutuhanAcara { IdKebutuhan = 3, IdAcara = 1, IdBarang = 4,  Jumlah = 4,  Keterangan = "",                                        IsAmbil = true,  IsKembali = true  },
                new KebutuhanAcara { IdKebutuhan = 4, IdAcara = 2, IdBarang = 12, Jumlah = 1,  Keterangan = "Videotron latar panggung utama",          IsAmbil = false, IsKembali = false },
                new KebutuhanAcara { IdKebutuhan = 5, IdAcara = 2, IdBarang = 3,  Jumlah = 1,  Keterangan = "Sound system outdoor",                   IsAmbil = false, IsKembali = false },
                new KebutuhanAcara { IdKebutuhan = 6, IdAcara = 3, IdBarang = 1,  Jumlah = 1,  Keterangan = "Proyektor utama & Layar gantung",         IsAmbil = false, IsKembali = false }
            );

            // ========== SEED: Penugasan ==========
            modelBuilder.Entity<Penugasan>().HasData(
                new Penugasan
                {
                    IdPenugasan = 1, IdAcara = 1, IdTeknisi = 1, IdPenugasTeknisi = 1,
                    StatusPenugasan = "Selesai", Progress = 100,
                    DokumentasiKegiatanFile = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=300&h=300&fit=crop"
                },
                new Penugasan
                {
                    IdPenugasan = 2, IdAcara = 2, IdTeknisi = 1, IdPenugasTeknisi = 1,
                    StatusPenugasan = "Ditugaskan", Progress = 0
                },
                new Penugasan
                {
                    IdPenugasan = 3, IdAcara = 3, IdTeknisi = 2, IdPenugasTeknisi = 1,
                    StatusPenugasan = "Ditugaskan", Progress = 0
                }
            );

            // =============== RELATIONS ===============

            // User -> Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.IdRole)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportAcara -> PembuatAcara (User)
            modelBuilder.Entity<SupportAcara>()
                .HasOne(a => a.PembuatAcara)
                .WithMany()
                .HasForeignKey(a => a.IdPembuatAcara)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportAcara -> MasterLokasi
            modelBuilder.Entity<SupportAcara>()
                .HasOne(a => a.LokasiNavigation)
                .WithMany()
                .HasForeignKey(a => a.IdLokasi)
                .OnDelete(DeleteBehavior.Restrict);

            // KebutuhanAcara -> SupportAcara
            modelBuilder.Entity<KebutuhanAcara>()
                .HasOne(k => k.Acara)
                .WithMany(a => a.Kebutuhan)
                .HasForeignKey(k => k.IdAcara)
                .OnDelete(DeleteBehavior.Cascade);

            // KebutuhanAcara -> MasterBarang
            modelBuilder.Entity<KebutuhanAcara>()
                .HasOne(k => k.Barang)
                .WithMany()
                .HasForeignKey(k => k.IdBarang)
                .OnDelete(DeleteBehavior.Restrict);

            // Penugasan -> SupportAcara
            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.Acara)
                .WithMany(a => a.PenugasanList)
                .HasForeignKey(p => p.IdAcara)
                .OnDelete(DeleteBehavior.Restrict);

            // Penugasan -> MappingTeknisi
            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.Teknisi)
                .WithMany()
                .HasForeignKey(p => p.IdTeknisi)
                .OnDelete(DeleteBehavior.Restrict);

            // Penugasan -> PenugasTeknisi (User)
            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.PenugasTeknisi)
                .WithMany()
                .HasForeignKey(p => p.IdPenugasTeknisi)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification -> User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
