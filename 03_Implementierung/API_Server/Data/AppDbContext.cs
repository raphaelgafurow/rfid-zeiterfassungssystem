using Microsoft.EntityFrameworkCore;
using Shared;

namespace API_Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
    public DbSet<Zeitbuchung> Zeitbuchung { get; set; }
    public DbSet<RFID_Karte> RFID_Karte { get; set; }
    public DbSet<Urlaub>  Urlaub { get; set; }
}