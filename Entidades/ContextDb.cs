using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Entidades
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
