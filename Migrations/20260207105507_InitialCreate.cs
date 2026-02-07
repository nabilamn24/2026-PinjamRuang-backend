using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_PinjamRuang_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peminjamans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPeminjam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalPeminjaman = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Keperluan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjamans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Peminjamans",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Keperluan", "NamaPeminjam", "Ruangan", "Status", "TanggalPeminjaman" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 7, 10, 55, 7, 581, DateTimeKind.Utc).AddTicks(430), null, "Seminar Proposal", "Nabila", "Aula Utama", "Approved", new DateTime(2026, 2, 8, 17, 55, 7, 581, DateTimeKind.Local).AddTicks(436) },
                    { 2, new DateTime(2026, 2, 7, 10, 55, 7, 581, DateTimeKind.Utc).AddTicks(451), null, "Praktikum Tambahan", "Budi Santoso", "Lab Komputer 1", "Pending", new DateTime(2026, 2, 10, 17, 55, 7, 581, DateTimeKind.Local).AddTicks(452) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peminjamans");
        }
    }
}
