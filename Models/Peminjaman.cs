using System.ComponentModel.DataAnnotations;

namespace _2026_PinjamRuang_backend.Models
{
    public class Peminjaman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NamaPeminjam { get; set; } = string.Empty;

        [Required]
        public string Ruangan { get; set; } = string.Empty;

        public DateTime TanggalPeminjaman { get; set; }

        public string Keperluan { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}