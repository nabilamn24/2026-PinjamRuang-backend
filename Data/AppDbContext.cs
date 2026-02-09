using Microsoft.EntityFrameworkCore;
using _2026_PinjamRuang_backend.Models;

namespace _2026_PinjamRuang_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Peminjaman> Peminjamans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kita masukin data palsu biar database gak kosong melompong
            modelBuilder.Entity<Peminjaman>().HasData(
                new Peminjaman
                {
                    Id = 1,
                    NamaPeminjam = "Admin Kampus",
                    Ruangan = "Aula Utama",
                    Keperluan = "Gladi Bersih Wisuda",
                    TanggalPeminjaman = DateTime.Now.AddDays(2), // Pinjam buat lusa
                    Status = "Approved",
                    CreatedAt = DateTime.Now
                },
                new Peminjaman
                {
                    Id = 2,
                    NamaPeminjam = "Mahasiswa Tamu",
                    Ruangan = "Lab Komputer 1",
                    Keperluan = "Kunjungan Industri",
                    TanggalPeminjaman = DateTime.Now.AddDays(5),
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}