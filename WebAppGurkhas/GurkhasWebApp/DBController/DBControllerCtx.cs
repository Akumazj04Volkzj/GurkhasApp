using DBController.Models;
using Microsoft.EntityFrameworkCore;

namespace DBController
{
    public class DBControllerCtx : DbContext
    {
        public DBControllerCtx(DbContextOptions<DBControllerCtx> options) : base(options)
        { 
        }

        //Definir DbSets para as entidades
        //public DbSet<YourEntity> YourEntities { get; set; } <-- Exemplo

        public DbSet<Users> Users { get; set; }
        public DbSet<Teams> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar as entidades
        }

        // Método para configurar as opções
        //public static void Configure(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DataBaseConnection", b =>
        //        b.MigrationsAssembly("GurkhasWebApp")); // Especifique a assembly do projeto de migrações
        //}
    }
}