using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinjamRuang_backend.Data;
using _2026_PinjamRuang_backend.Models;
using _2026_PinjamRuang_backend.DTOs; // <--- Jangan lupa ini!

namespace _2026_PinjamRuang_backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PeminjamanController : ControllerBase
  {
    private readonly AppDbContext _context;

    public PeminjamanController(AppDbContext context)
    {
      _context = context;
    }

    // 1. GET: Ambil Semua Data (Return DTO)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PeminjamanDto>>> GetPeminjamans()
    {
      // Ambil dari database, terus ubah (Map) jadi DTO
      var peminjamans = await _context.Peminjamans
          .Where(x => x.DeletedAt == null)
          .Select(x => new PeminjamanDto
          {
            Id = x.Id,
            NamaPeminjam = x.NamaPeminjam,
            Ruangan = x.Ruangan,
            TanggalPeminjaman = x.TanggalPeminjaman,
            Keperluan = x.Keperluan,
            Status = x.Status
          })
          .ToListAsync();

      return peminjamans;
    }

    // 2. GET: Ambil 1 Data (Return DTO)
    [HttpGet("{id}")]
    public async Task<ActionResult<PeminjamanDto>> GetPeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);

      if (peminjaman == null || peminjaman.DeletedAt != null)
      {
        return NotFound(new { message = "Data gak ketemu nih!" });
      }

      // Ubah Entity jadi DTO manual
      var dto = new PeminjamanDto
      {
        Id = peminjaman.Id,
        NamaPeminjam = peminjaman.NamaPeminjam,
        Ruangan = peminjaman.Ruangan,
        TanggalPeminjaman = peminjaman.TanggalPeminjaman,
        Keperluan = peminjaman.Keperluan,
        Status = peminjaman.Status
      };

      return dto;
    }

    // 3. POST: Tambah Data (Pakai CreatePeminjamanDto)
    [HttpPost]
    public async Task<ActionResult<PeminjamanDto>> PostPeminjaman(CreatePeminjamanDto input)
    {
      // Validasi Tanggal
      if (input.TanggalPeminjaman < DateTime.Now.Date)
      {
        return BadRequest(new { message = "Gak bisa minjem tanggal lampau ya!" });
      }

      // Pindahin data dari DTO (Formulir) ke Entity (Brankas)
      var peminjamanBaru = new Peminjaman
      {
        NamaPeminjam = input.NamaPeminjam,
        Ruangan = input.Ruangan,
        TanggalPeminjaman = input.TanggalPeminjaman,
        Keperluan = input.Keperluan,
        Status = "Pending", // Default
        CreatedAt = DateTime.UtcNow
      };

      _context.Peminjamans.Add(peminjamanBaru);
      await _context.SaveChangesAsync();

      // Balikin response bentuk DTO lagi
      var responseDto = new PeminjamanDto
      {
        Id = peminjamanBaru.Id,
        NamaPeminjam = peminjamanBaru.NamaPeminjam,
        Ruangan = peminjamanBaru.Ruangan,
        TanggalPeminjaman = peminjamanBaru.TanggalPeminjaman,
        Keperluan = peminjamanBaru.Keperluan,
        Status = peminjamanBaru.Status
      };

      return CreatedAtAction("GetPeminjaman", new { id = peminjamanBaru.Id }, responseDto);
    }

    // 4. PUT: Update Data (Pakai CreatePeminjamanDto)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeminjaman(int id, CreatePeminjamanDto input)
    {
      var dataAsli = await _context.Peminjamans.FindAsync(id);

      if (dataAsli == null || dataAsli.DeletedAt != null)
      {
        return NotFound(new { message = "Data yang mau diedit gak ada!" });
      }

      // Update data field
      dataAsli.NamaPeminjam = input.NamaPeminjam;
      dataAsli.Ruangan = input.Ruangan;
      dataAsli.Keperluan = input.Keperluan;
      dataAsli.TanggalPeminjaman = input.TanggalPeminjaman;

      // 👇 TAMBAHIN INI (Biar Statusnya ikut ke-update)
      if (!string.IsNullOrEmpty(input.Status))
      {
        dataAsli.Status = input.Status;
      }

      await _context.SaveChangesAsync();

      return NoContent();
    }

    // 5. DELETE: Soft Delete (Sama kayak sebelumnya)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);

      if (peminjaman == null || peminjaman.DeletedAt != null)
      {
        return NotFound(new { message = "Data tidak ditemukan." });
      }

      peminjaman.DeletedAt = DateTime.UtcNow;
      _context.Entry(peminjaman).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}