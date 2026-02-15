using System.ComponentModel.DataAnnotations;

namespace _2026_PinjamRuang_backend.DTOs
{
  // 1. INI KOTAK BUAT NERIMA INPUT DARI USER (Request) 
  public class CreatePeminjamanDto
  {
    [Required(ErrorMessage = "Nama wajib diisi ya!")]
    [MinLength(3, ErrorMessage = "Nama minimal 3 huruf!")]
    public string NamaPeminjam { get; set; }

    [Required(ErrorMessage = "Ruangan wajib dipilih!")]
    public string Ruangan { get; set; }

    [Required]
    public DateTime TanggalPeminjaman { get; set; }

    [Required]
    [MinLength(10, ErrorMessage = "Keperluan minimal 10 karakter ya.")]
    public string Keperluan { get; set; }

    public string Status { get; set; } = "Pending";
  }
}

// 2. INI KOTAK BUAT NGIRIM DATA KE FRONTEND (Response)
public class PeminjamanDto
{
  public int Id { get; set; }
  public string NamaPeminjam { get; set; }
  public string Ruangan { get; set; }
  public DateTime TanggalPeminjaman { get; set; }
  public string Keperluan { get; set; }
  public string Status { get; set; }
}
