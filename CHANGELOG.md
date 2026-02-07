# Changelog

Semua perubahan penting pada project ini akan didokumentasikan di file ini.

Format berdasarkan [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
dan project ini mematuhi [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v1.0.0] - 2026-02-07

Rilis pertama untuk sistem backend Peminjaman Ruangan.

### Added

- **CRUD Peminjaman**: Endpoint API untuk Create, Read, Update, Delete data peminjaman.
- **Validasi Input**:
  - Mencegah input field kosong (Nama, Ruangan, Keperluan).
  - Validasi panjang karakter minimum untuk 'Keperluan'.
  - Validasi logika tanggal (tidak boleh meminjam di masa lalu).
- **Soft Delete**: Implementasi penghapusan data aman menggunakan kolom `DeletedAt`.
- **Database**: Migrasi awal menggunakan Entity Framework Core & SQL Server.
- **Documentation**: File README.md lengkap dengan panduan instalasi.

### Fixed

- Memperbaiki isu di mana data soft-delete masih muncul di endpoint GET by ID.
- Memperbaiki logika Update (PUT) agar tidak merusak data `CreatedAt`.
