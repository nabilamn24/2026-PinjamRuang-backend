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

    // 1. Konstruktor: Minta akses ke 'Gudang' (Database)
    public PeminjamanController(AppDbContext context)
    {
      _context = context;
    }

    // 2. GET: Ambil Semua Data (Yg belum dihapus)
    // Cara panggil: GET /api/peminjaman
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjamans()
    {
      // Ambil semua data dari tabel Peminjamans jadi list
      return await _context.Peminjamans.ToListAsync();
    }

    // 3. GET: Ambil 1 Data berdasarkan ID
    // Cara panggil: GET /api/peminjaman/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Peminjaman>> GetPeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);

      if (peminjaman == null)
      {
        return NotFound("Data gak ketemu bestie!");
      }

      return peminjaman;
    }

    // 4. POST: Tambah Data Baru
    // POST: api/Peminjaman
    [HttpPost]
    public async Task<ActionResult<Peminjaman>> PostPeminjaman(Peminjaman peminjaman)
    {
      // VALIDASI TAMBAHAN: Cek Tanggal Masa Lalu
      if (peminjaman.TanggalPeminjaman < DateTime.Now)
      {
        return BadRequest(new { message = "Gak bisa minjem tanggal lampau, emangnya punya mesin waktu?" });
      }

      // Kalau lolos, lanjut simpan
      peminjaman.CreatedAt = DateTime.UtcNow;
      _context.Peminjamans.Add(peminjaman);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPeminjaman", new { id = peminjaman.Id }, peminjaman);
    }

    // 5. PUT: Update/Edit Data
    // Cara panggil: PUT /api/peminjaman/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPeminjaman(int id, Peminjaman peminjaman)
    {
      if (id != peminjaman.Id)
      {
        return BadRequest();
      }

      _context.Entry(peminjaman).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PeminjamanExists(id)) return NotFound();
        else throw;
      }

      return NoContent(); // Berhasil tapi gak balikin data apa2
    }

    // 6. DELETE: Hapus Data (Soft Delete)
    // Cara panggil: DELETE /api/peminjaman/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePeminjaman(int id)
    {
      var peminjaman = await _context.Peminjamans.FindAsync(id);
      if (peminjaman == null)
      {
        return NotFound();
      }

      // SOFT DELETE: Gak dihapus beneran, cuma dikasih tanggal wafat
      peminjaman.DeletedAt = DateTime.UtcNow;

      // Simpan perubahan status
      _context.Entry(peminjaman).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool PeminjamanExists(int id)
    {
      return _context.Peminjamans.Any(e => e.Id == id);
    }
  }
}