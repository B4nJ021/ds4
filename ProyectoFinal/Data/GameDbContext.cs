using ProyectoFinal.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProyectoFinal.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext() : base("name=GameDbConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteGame> FavoriteGames { get; set; }
        public DbSet<GameSales> GameSales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<FavoriteGame>()
                .HasRequired(f => f.User)
                .WithMany(u => u.FavoriteGames)
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}