using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinjamRuang_backend.Data;
using _2026_PinjamRuang_backend.Models;

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

    // 1. GET: Ambil Semua Data (Yg belum dihapus)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjamans()
    {
      return await _context.Peminjamans
          .Where(x => x.DeletedAt == null) // Filter sampah
          .ToListAsync();
    }

    // 2. GET: Ambil 1 Data (Cek Soft Delete juga)
    [HttpGet("{id}")]
    public async Task<ActionResult<Peminjaman>> GetPeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);

      // Kalau gak ada ATAU udah dihapus --> Not Found
      if (peminjaman == null || peminjaman.DeletedAt != null)
      {
        // Pakai object anonim biar responnya JSON rapi
        return NotFound(new { message = "Data gak ketemu nih!" });
      }

      return peminjaman;
    }

    // 3. POST: Tambah Data (Validasi Tanggal)
    [HttpPost]
    public async Task<ActionResult<Peminjaman>> PostPeminjaman(Peminjaman peminjaman)
    {
      // Validasi: Gak boleh tanggal lampau
      if (peminjaman.TanggalPeminjaman < DateTime.Now)
      {
        return BadRequest(new { message = "Gak bisa minjem tanggal lampau ya!" });
      }

      peminjaman.CreatedAt = DateTime.UtcNow;
      peminjaman.Status = "Pending"; // Pastikan status awal selalu Pending

      _context.Peminjamans.Add(peminjaman);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPeminjaman", new { id = peminjaman.Id }, peminjaman);
    }

    // 4. PUT: Update Data (VERSI AMAN)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeminjaman(int id, Peminjaman peminjaman)
    {
      if (id != peminjaman.Id) return BadRequest();

      // A. Ambil data aslinya dulu di database
      var dataAsli = await _context.Peminjamans.FindAsync(id);

      // B. Cek valid gak datanya
      if (dataAsli == null || dataAsli.DeletedAt != null)
      {
        return NotFound(new { message = "Data yang mau diedit gak ada!" });
      }

      // C. Update CUMA field yang boleh diubah
      // (CreatedAt JANGAN disentuh!)
      dataAsli.NamaPeminjam = peminjaman.NamaPeminjam;
      dataAsli.Ruangan = peminjaman.Ruangan;
      dataAsli.Keperluan = peminjaman.Keperluan;
      dataAsli.TanggalPeminjaman = peminjaman.TanggalPeminjaman;
      dataAsli.Status = peminjaman.Status;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }

      return NoContent();
    }

    // 5. DELETE: Soft Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);

      // Kalau udah dihapus duluan, balikin NotFound aja
      if (peminjaman == null || peminjaman.DeletedAt != null)
      {
        return NotFound(new { message = "Datanya emang udah gak ada kok." });
      }

      // Cap stempel "Dihapus" (Soft Delete)
      peminjaman.DeletedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}