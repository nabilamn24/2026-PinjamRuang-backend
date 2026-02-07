using Microsoft.EntityFrameworkCore;
using _2026_PinjamRuang_backend.Models;

namespace _2026_PinjamRuang_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mendaftarkan tabel Peminjaman
        public DbSet<Peminjaman> Peminjamans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi Soft Delete (Data yang ada DeletedAt-nya gak bakal muncul kalau di-query biasa)
            modelBuilder.Entity<Peminjaman>().HasQueryFilter(p => p.DeletedAt == null);

            // === INI SEEDERNYA (Data Awal) ===
            modelBuilder.Entity<Peminjaman>().HasData(
                new Peminjaman 
                { 
                    Id = 1, 
                    NamaPeminjam = "Nabila", 
                    Ruangan = "Aula Utama", 
                    TanggalPeminjaman = DateTime.Now.AddDays(1), 
                    Keperluan = "Seminar Proposal", 
                    Status = "Approved" 
                },
                new Peminjaman 
                { 
                    Id = 2, 
                    NamaPeminjam = "Budi Santoso", 
                    Ruangan = "Lab Komputer 1", 
                    TanggalPeminjaman = DateTime.Now.AddDays(3), 
                    Keperluan = "Praktikum Tambahan", 
                    Status = "Pending" 
                }
            );
        }
    }
}