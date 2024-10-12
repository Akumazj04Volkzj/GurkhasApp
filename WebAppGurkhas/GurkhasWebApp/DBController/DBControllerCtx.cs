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
        public DbSet<TeamRoles> TeamRoles { get; set; }
        public DbSet<UserTeamRole> UserRoles { get; set; }
        public DbSet<UserRoles> UtilizRoles { get; set; }
        public DbSet<User_UserRoles> Utiliz_UtilizRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar as entidades

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.User_Id);

                entity.Property(e => e.User_Name)
                    .IsRequired();

                entity.Property(e => e.User_Email)
                    .HasMaxLength(256);

                entity.Property(e => e.User_PhoneNumber)
                    .IsRequired(false);

                entity.HasOne(e => e.User_Team)
                    .WithMany(t => t.Users)
                    .HasForeignKey(e => e.User_TeamId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.UserTeamRole)
                    .WithOne()
                    .HasForeignKey<UserTeamRole>(e => e.User_Id);
            });

            // Configuração da entidade Teams
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.Team_Id);

                entity.Property(e => e.Team_Name)
                    .IsRequired();

                entity.Property(e => e.Team_Email)
                    .HasMaxLength(256);
            });

            // Configuração da entidade TeamRoles
            modelBuilder.Entity<TeamRoles>(entity =>
            {
                entity.HasKey(e => e.Role_Id);

                entity.Property(e => e.Role_Name)
                    .IsRequired();
            });

            // Configuração da entidade UserTeamRole
            modelBuilder.Entity<UserTeamRole>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithOne(u => u.UserTeamRole)
                    .HasForeignKey<UserTeamRole>(e => e.User_Id);

                entity.HasOne(e => e.Team)
                    .WithMany()
                    .HasForeignKey(e => e.Team_Id);

                entity.HasOne(e => e.TeamRole)
                    .WithMany()
                    .HasForeignKey(e => e.TeamRole_Id);
            });

            // Configuração da entidade UserRoles
            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.Role_Id);

                entity.Property(e => e.Role_Name)
                    .IsRequired();
            });

            // Configuração da entidade User_UserRoles
            modelBuilder.Entity<User_UserRoles>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.User_UserRoles) // Um usuário pode ter múltiplos papéis
                    .HasForeignKey(e => e.User_Id)
                    .OnDelete(DeleteBehavior.Cascade); // Excluir as relações se o usuário for deletado

                entity.HasOne(e => e.UserRole)
                    .WithMany() // Um papel pode ser associado a múltiplos usuários
                    .HasForeignKey(e => e.UserRole_Id)
                    .OnDelete(DeleteBehavior.Cascade); // Excluir as relações se o papel for deletado
            });

            // Seeding Database
            // Adicionar dados iniciais para UserRoles
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { Role_Id = 1, Role_Name = "Admin", Role_Level = UserRoleLevel.Admin },
                new UserRoles { Role_Id = 2, Role_Name = "Advanced User", Role_Level = UserRoleLevel.AdvancedUser },
                new UserRoles { Role_Id = 3, Role_Name = "User", Role_Level = UserRoleLevel.User },
                new UserRoles { Role_Id = 4, Role_Name = "Restricted Group", Role_Level = UserRoleLevel.RestrictedGroup }
            );

            // Adicionar dados iniciais para TeamRoles
            modelBuilder.Entity<TeamRoles>().HasData(
                new TeamRoles { Role_Id = 1, Role_Name = "Leader", Role_Level = TeamRoleLevel.Leader },
                new TeamRoles { Role_Id = 2, Role_Name = "SubLeader", Role_Level = TeamRoleLevel.SubLeader },
                new TeamRoles { Role_Id = 3, Role_Name = "Member", Role_Level = TeamRoleLevel.Member }
            );
        }

        // Método para configurar as opções
        //public static void Configure(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DataBaseConnection", b =>
        //        b.MigrationsAssembly("GurkhasWebApp")); // Especifique a assembly do projeto de migrações
        //}
    }
}