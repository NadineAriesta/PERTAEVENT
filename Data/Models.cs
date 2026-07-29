using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventSupportApp.Data
{
    public class MasterLokasi
    {
        [Key]
        public int IdLokasi { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string NamaLokasi { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Keterangan { get; set; }
    }

    public class MasterBarang
    {
        [Key]
        public int IdBarang { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string NamaBarang { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string Kategori { get; set; } = string.Empty; // e.g., Audio, Video, Kelistrikan
        
        [MaxLength(50)]
        public string Icon { get; set; } = "🛠️";
    }

    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public int IdRole { get; set; } = 0;
        [ForeignKey("IdRole")]
        public virtual Role? Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        
        public bool StatusAktif { get; set; } = true;
    }

    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string NamaRole { get; set; } = string.Empty; // Admin, Helpdesk, Teknisi
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
        public string Spesialisasi { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string StatusKetersediaan { get; set; } = "Tersedia"; // Tersedia, Sibuk, Tidak Aktif
    }

    public class SupportAcara
    {
        [Key]
        public int IdAcara { get; set; }
        
        public int IdPembuatAcara { get; set; }
        [ForeignKey("IdPembuatAcara")]
        public virtual User? PembuatAcara { get; set; }
        
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
        public int IdLokasi { get; set; }
        [ForeignKey("IdLokasi")]
        public virtual MasterLokasi? LokasiNavigation { get; set; }
        
        [Required]
        [MaxLength(50)]
        // Belum Ditugaskan, Ditugaskan, Diterima, Berlangsung, Selesai
        public string StatusAcara { get; set; } = "Belum Ditugaskan";

        public virtual ICollection<KebutuhanAcara> Kebutuhan { get; set; } = new List<KebutuhanAcara>();
        public virtual ICollection<Penugasan> PenugasanList { get; set; } = new List<Penugasan>();
    }

    // Tabel ini menyimpan barang/peralatan yang dibutuhkan untuk suatu acara
    public class KebutuhanAcara
    {
        [Key]
        public int IdKebutuhan { get; set; }
        
        public int IdAcara { get; set; }
        [ForeignKey("IdAcara")]
        public virtual SupportAcara? Acara { get; set; }
        
        public int IdBarang { get; set; }
        [ForeignKey("IdBarang")]
        public virtual MasterBarang? Barang { get; set; }
        
        public int Jumlah { get; set; } = 1;
        
        [MaxLength(250)]
        public string Keterangan { get; set; } = string.Empty;

        // Status pengambilan barang oleh teknisi
        public bool IsAmbil { get; set; } = false;

        // Status pengembalian barang setelah acara selesai
        public bool IsKembali { get; set; } = false;
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
        
        // Siapa yang menugaskan teknisi ini (bisa Admin atau Helpdesk)
        public int IdPenugasTeknisi { get; set; }
        [ForeignKey("IdPenugasTeknisi")]
        public virtual User? PenugasTeknisi { get; set; }
        
        [Required]
        [MaxLength(50)]
        // Ditugaskan, Diterima, Berlangsung, Selesai
        public string StatusPenugasan { get; set; } = "Ditugaskan";
        
        public DateTime? WaktuKonfirmasi { get; set; }
        
        public string? DokumentasiKegiatanFile { get; set; }
        
        public DateTime? WaktuUpload { get; set; }

        public int Progress { get; set; } = 0;
        
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
        
        // Nama acara yang bersangkutan agar penerima tahu notif dari acara mana
        [MaxLength(200)]
        public string? NamaAcara { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Unread"; // Unread, Read
    }

    public static class UIHelpers
    {
        public static string GetNeedBaseClass(string? needName)
        {
            var name = needName?.ToLower() ?? "";
            if (name.Contains("proyektor") || name.Contains("screen") || name.Contains("layar"))
                return "cat-blue";
            if (name.Contains("sound") || name.Contains("mic") || name.Contains("audio") || name.Contains("speaker") || name.Contains("wireless"))
                return "cat-purple";
            if (name.Contains("laptop") || name.Contains("pc") || name.Contains("multimedia") || name.Contains("komputer"))
                return "cat-green";
            if (name.Contains("kabel") || name.Contains("listrik") || name.Contains("roll") || name.Contains("colokan") || name.Contains("kelistrikan"))
                return "cat-orange";
            return "cat-default";
        }

        public static string GetNeedIcon(string? needName)
        {
            var name = needName?.ToLower() ?? "";
            if (name.Contains("proyektor")) return "📹";
            if (name.Contains("layar") || name.Contains("screen")) return "🖥️";
            if (name.Contains("sound") || name.Contains("speaker")) return "🔊";
            if (name.Contains("mic") || name.Contains("wireless")) return "🎤";
            if (name.Contains("laptop") || name.Contains("pc") || name.Contains("komputer")) return "💻";
            if (name.Contains("kabel") || name.Contains("listrik") || name.Contains("roll") || name.Contains("colokan")) return "🔌";
            return "🛠️";
        }

        public static string CleanNeedName(string? needName)
        {
            if (string.IsNullOrEmpty(needName)) return string.Empty;
            return needName
                .Replace("🔹", "")
                .Replace("🔸", "")
                .TrimStart('•', '▪', '●', '*', ' ', '-', '•', '▪', '●');
        }
    }

    [Table("AuditLogs")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLog { get; set; }
        
        public DateTime Waktu { get; set; } = DateTime.Now;
        
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Aksi { get; set; } = string.Empty;
        
        public string Detail { get; set; } = string.Empty;
    }
}
