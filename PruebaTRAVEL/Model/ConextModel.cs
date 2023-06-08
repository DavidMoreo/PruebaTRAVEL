

using Microsoft.EntityFrameworkCore;

namespace PruebaTRAVEL.Model
{
    public class ConextModel : DbContext
    {
        public DbSet<autores_has_libros> autores_has_libros { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<editoriales> editoriales { get; set; }
        public DbSet<autores> autores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Data Source=LOLO;Initial Catalog=Prueba;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<autores_has_libros>()
            //    .HasKey(al => new { al.autores_id, al.libros_ISBN });
            // modelBuilder.Entity<autores>()
            //    .HasKey(al => new { al.id });
        }

    }
}
