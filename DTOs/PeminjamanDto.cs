using System.ComponentModel.DataAnnotations;

namespace _2026_PinjamRuang_backend.DTOs
{
  // 1. INI KOTAK BUAT NERIMA INPUT DARI USER (Request)
  // Isinya cuma field yang boleh diisi user aja.
  public class CreatePeminjamanDto
  {
    [Required(ErrorMessage = "Nama Peminjam wajib diisi!")]
    public string NamaPeminjam { get; set; }

    [Required(ErrorMessage = "Ruangan harus dipilih!")]
    public string Ruangan { get; set; }

    [Required]
    public DateTime TanggalPeminjaman { get; set; }

    [Required(ErrorMessage = "Keperluan gak boleh kosong!")]
    [MinLength(10, ErrorMessage = "Keperluan minimal 10 karakter ya.")]
    public string Keperluan { get; set; }
    public string? Status { get; set; }
  }

  // 2. INI KOTAK BUAT NGIRIM DATA KE FRONTEND (Response)
  // Isinya lengkap termasuk ID dan Status.
  public class PeminjamanDto
  {
    public int Id { get; set; }
    public string NamaPeminjam { get; set; }
    public string Ruangan { get; set; }
    public DateTime TanggalPeminjaman { get; set; }
    public string Keperluan { get; set; }
    public string Status { get; set; }
  }
}