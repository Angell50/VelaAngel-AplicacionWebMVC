using Microsoft.EntityFrameworkCore;
using VelaAngel_AplicacionWebMVC.Models;

namespace VelaAngel_AplicacionWebMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para cada entidad
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
    }
}
