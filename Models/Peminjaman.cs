using System.ComponentModel.DataAnnotations; // <-- INI WAJIB BIAR SATPAMNYA MUNCUL

namespace _2026_PinjamRuang_backend.Models
{
  public class Peminjaman
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Waduh, Nama Peminjam wajib diisi ya!")]
    public string NamaPeminjam { get; set; }

    [Required(ErrorMessage = "Ruangan harus dipilih dong!")]
    public string Ruangan { get; set; }

    [Required]
    public DateTime TanggalPeminjaman { get; set; }

    [Required(ErrorMessage = "Keperluan gak boleh kosong!")]
    [MinLength(10, ErrorMessage = "Keperluan harus jelas, minimal 10 karakter ya.")]
    public string Keperluan { get; set; }

    public string Status { get; set; } = "Pending"; // Default otomatis Pending

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DeletedAt { get; set; } // Boleh kosong (nullable)
  }
}