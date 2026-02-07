using Microsoft.EntityFrameworkCore;
using _2026_PinjamRuang_backend.Data;
// Kalau ada using lain bawaan, biarin di sini juga

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Daftarkan DbContext ke SQL Server (Ini yang tadi kita tambah)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Daftarkan Controller (Biar API jalan)
builder.Services.AddControllers();

// 3. Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();