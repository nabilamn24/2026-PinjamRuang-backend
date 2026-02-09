using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_PinjamRuang_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peminjamans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Keperluan", "NamaPeminjam", "TanggalPeminjaman" },
                values: new object[] { new DateTime(2026, 2, 9, 13, 2, 16, 886, DateTimeKind.Local).AddTicks(5946), "Gladi Bersih Wisuda", "Admin Kampus", new DateTime(2026, 2, 11, 13, 2, 16, 886, DateTimeKind.Local).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "Peminjamans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Keperluan", "NamaPeminjam", "TanggalPeminjaman" },
                values: new object[] { new DateTime(2026, 2, 9, 13, 2, 16, 886, DateTimeKind.Local).AddTicks(5952), "Kunjungan Industri", "Mahasiswa Tamu", new DateTime(2026, 2, 14, 13, 2, 16, 886, DateTimeKind.Local).AddTicks(5950) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peminjamans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Keperluan", "NamaPeminjam", "TanggalPeminjaman" },
                values: new object[] { new DateTime(2026, 2, 7, 10, 55, 7, 581, DateTimeKind.Utc).AddTicks(430), "Seminar Proposal", "Nabila", new DateTime(2026, 2, 8, 17, 55, 7, 581, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "Peminjamans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Keperluan", "NamaPeminjam", "TanggalPeminjaman" },
                values: new object[] { new DateTime(2026, 2, 7, 10, 55, 7, 581, DateTimeKind.Utc).AddTicks(451), "Praktikum Tambahan", "Budi Santoso", new DateTime(2026, 2, 10, 17, 55, 7, 581, DateTimeKind.Local).AddTicks(452) });
        }
    }
}
