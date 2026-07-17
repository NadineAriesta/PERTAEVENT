using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventSupportApp.Data
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        
        public bool StatusAktif { get; set; } = true;

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string NamaRole { get; set; } = string.Empty; // Admin, Helpdesk, Teknisi
        
        [MaxLength(250)]
        public string Deskripsi { get; set; } = string.Empty;
    }

    public class UserRole
    {
        [Key]
        public int IdUserRole { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User? User { get; set; }
        
        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public virtual Role? Role { get; set; }
    }

    public class MappingTeknisi
    {
        [Key]
        public int IdTeknisi { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User? User { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Spesialisasi { get; set; } = string.Empty; // e.g., Sound System, Layar/Proyektor
        
        [Required]
        [MaxLength(50)]
        public string StatusKetersediaan { get; set; } = "Tersedia"; // Tersedia, Sibuk, Tidak Aktif
    }

    public class SupportAcara
    {
        [Key]
        public int IdAcara { get; set; }
        
        public int IdUserHelpdesk { get; set; }
        [ForeignKey("IdUserHelpdesk")]
        public virtual User? Helpdesk { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string NamaAcara { get; set; } = string.Empty;
        
        [Required]
        public DateTime Tanggal { get; set; } = DateTime.Today;
        
        [Required]
        public TimeSpan JamMulai { get; set; } = new TimeSpan(8, 0, 0);
        
        [Required]
        public TimeSpan JamSelesai { get; set; } = new TimeSpan(17, 0, 0);
        
        [Required]
        [MaxLength(200)]
        public string Lokasi { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string StatusAcara { get; set; } = "Belum Ditugaskan"; // Belum Ditugaskan, Ditugaskan, Dikonfirmasi, Dokumen Diunggah, Selesai

        public virtual ICollection<KebutuhanAcara> Kebutuhan { get; set; } = new List<KebutuhanAcara>();
        public virtual ICollection<Penugasan> PenugasanList { get; set; } = new List<Penugasan>();
    }

    public class KebutuhanAcara
    {
        [Key]
        public int IdKebutuhan { get; set; }
        
        public int IdAcara { get; set; }
        [ForeignKey("IdAcara")]
        public virtual SupportAcara? Acara { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string JenisKebutuhan { get; set; } = string.Empty; // Proyektor, Sound System, Layar, dll.
        
        public int Jumlah { get; set; } = 1;
        
        [MaxLength(250)]
        public string Keterangan { get; set; } = string.Empty;
    }

    public class Penugasan
    {
        [Key]
        public int IdPenugasan { get; set; }
        
        public int IdAcara { get; set; }
        [ForeignKey("IdAcara")]
        public virtual SupportAcara? Acara { get; set; }
        
        public int IdTeknisi { get; set; }
        [ForeignKey("IdTeknisi")]
        public virtual MappingTeknisi? Teknisi { get; set; }
        
        public int IdUserAdmin { get; set; } // Admin yang menugaskan
        [ForeignKey("IdUserAdmin")]
        public virtual User? Admin { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string StatusPenugasan { get; set; } = "Ditugaskan"; // Ditugaskan (Kuning), Dikonfirmasi (Hijau), Dokumen Diunggah (Biru), Selesai (Abu-abu)
        
        public DateTime? WaktuKonfirmasi { get; set; }
        
        [MaxLength(500)]
        public string? DokumentasiKegiatanFile { get; set; } // Path/Base64 untuk demo
        
        public DateTime? WaktuUpload { get; set; }

        public int Progress { get; set; } = 0; // e.g. 0 to 100
        
        [MaxLength(500)]
        public string? CatatanTeknisi { get; set; }
    }

    public class Notification
    {
        [Key]
        public int IdNotification { get; set; }
        
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User? User { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Message { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Unread"; // Unread, Read
    }

    public class RiwayatAcara
    {
        [Key]
        public int IdRiwayat { get; set; }
        
        public int IdAcara { get; set; }
        
        public int IdPenugasan { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string NamaAcara { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string NamaTeknisi { get; set; } = string.Empty;
        
        public DateTime TanggalAcara { get; set; }
        
        [MaxLength(500)]
        public string? DokumentasiKegiatanFile { get; set; }
        
        public DateTime WaktuSelesai { get; set; } = DateTime.Now;
    }
}
