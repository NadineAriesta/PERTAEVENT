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
        public DbSet<RiwayatAcara> RiwayatAcara => Set<RiwayatAcara>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<DiskusiPenugasan> DiskusiPenugasan => Set<DiskusiPenugasan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { IdRole = 1, NamaRole = "Admin", Deskripsi = "Administrator yang menugaskan teknisi dan melihat laporan" },
                new Role { IdRole = 2, NamaRole = "Helpdesk", Deskripsi = "Staff yang memasukkan data acara dan kebutuhan support" },
                new Role { IdRole = 3, NamaRole = "Teknisi", Deskripsi = "Staff teknis lapangan yang bertugas mensupport acara" }
            );

            // Seed Users (IdRole: 1=Admin, 2=Helpdesk, 3=Teknisi)
            modelBuilder.Entity<User>().HasData(
                new User { IdUser = 1, Username = "admin",      Password = "123", StatusAktif = true, IdRole = 1 },
                new User { IdUser = 2, Username = "helpdesk",   Password = "123", StatusAktif = true, IdRole = 2 },
                new User { IdUser = 3, Username = "pak_joko",   Password = "123", StatusAktif = true, IdRole = 3 },
                new User { IdUser = 4, Username = "pak_budi",   Password = "123", StatusAktif = true, IdRole = 3 },
                new User { IdUser = 5, Username = "pak_bambang",Password = "123", StatusAktif = true, IdRole = 3 }
            );

            // Seed MappingTeknisi
            modelBuilder.Entity<MappingTeknisi>().HasData(
                new MappingTeknisi { IdTeknisi = 1, IdUser = 3, Spesialisasi = "Sound System & Audio", StatusKetersediaan = "Tersedia" },
                new MappingTeknisi { IdTeknisi = 2, IdUser = 4, Spesialisasi = "Proyektor & Layar Lebar", StatusKetersediaan = "Tersedia" },
                new MappingTeknisi { IdTeknisi = 3, IdUser = 5, Spesialisasi = "Multimedia & Kelistrikan", StatusKetersediaan = "Sibuk" }
            );

            // Seed SupportAcara (Sample Events)
            modelBuilder.Entity<SupportAcara>().HasData(
                new SupportAcara 
                { 
                    IdAcara = 1, 
                    IdUserHelpdesk = 2, 
                    NamaAcara = "Rapat Pleno Senat Universitas", 
                    Tanggal = DateTime.Today, 
                    JamMulai = new TimeSpan(9, 0, 0), 
                    JamSelesai = new TimeSpan(12, 0, 0), 
                    Lokasi = "Aula Utama Gedung Rektorat Lt. 3", 
                    StatusAcara = "Ditugaskan" 
                },
                new SupportAcara 
                { 
                    IdAcara = 2, 
                    IdUserHelpdesk = 2, 
                    NamaAcara = "Seminar Nasional IT & AI", 
                    Tanggal = DateTime.Today.AddDays(1), 
                    JamMulai = new TimeSpan(13, 0, 0), 
                    JamSelesai = new TimeSpan(16, 30, 0), 
                    Lokasi = "Auditorium BJ Habibie", 
                    StatusAcara = "Ditugaskan" 
                }
            );

            // Seed KebutuhanAcara
            modelBuilder.Entity<KebutuhanAcara>().HasData(
                new KebutuhanAcara { IdKebutuhan = 1, IdAcara = 1, JenisKebutuhan = "Sound System", Jumlah = 1, Keterangan = "Microphone wireless 4 buah & Audio Mixer" },
                new KebutuhanAcara { IdKebutuhan = 2, IdAcara = 1, JenisKebutuhan = "Proyektor", Jumlah = 1, Keterangan = "Proyektor utama & Layar gantung" },
                new KebutuhanAcara { IdKebutuhan = 3, IdAcara = 2, JenisKebutuhan = "Layar LED", Jumlah = 1, Keterangan = "Videotron latar panggung utama" },
                new KebutuhanAcara { IdKebutuhan = 4, IdAcara = 2, JenisKebutuhan = "Sound System", Jumlah = 1, Keterangan = "Sound system konser outdoor / semi-indoor" }
            );

            // Seed Penugasan
            modelBuilder.Entity<Penugasan>().HasData(
                new Penugasan { IdPenugasan = 1, IdAcara = 1, IdTeknisi = 1, IdUserAdmin = 1, StatusPenugasan = "Ditugaskan", Progress = 0 },
                new Penugasan { IdPenugasan = 2, IdAcara = 2, IdTeknisi = 2, IdUserAdmin = 1, StatusPenugasan = "Ditugaskan", Progress = 0 }
            );

            // User -> Role relation
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.IdRole)
                .OnDelete(DeleteBehavior.Restrict);

            // Avoid multiple cascade paths on SQL Server
            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.Acara)
                .WithMany()
                .HasForeignKey(p => p.IdAcara)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.Admin)
                .WithMany()
                .HasForeignKey(p => p.IdUserAdmin)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Penugasan>()
                .HasOne(p => p.Teknisi)
                .WithMany()
                .HasForeignKey(p => p.IdTeknisi)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiskusiPenugasan>()
                .HasOne(d => d.Penugasan)
                .WithMany(p => p.DiskusiList)
                .HasForeignKey(d => d.IdPenugasan)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiskusiPenugasan>()
                .HasOne(d => d.Pengirim)
                .WithMany()
                .HasForeignKey(d => d.IdUserPengirim)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
