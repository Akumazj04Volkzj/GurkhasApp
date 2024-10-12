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
        public DbSet<UserTeamRole> UserTeamRole { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<User_UserRoles> User_UserRoles { get; set; }


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
                entity.HasKey(e => e.TeamRole_Id);

                entity.Property(e => e.TeamRole_Name)
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
                entity.HasKey(e => e.UserRole_Id);  // Define o Role_Id como chave primária

                entity.Property(e => e.UserRole_Name)
                    .IsRequired();  // Define Role_Name como um campo obrigatório

                //entity.Property(e => e.UserRole_Level)
                //    .IsRequired();  // Define Role_Level como um campo obrigatório
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
                new UserRoles { UserRole_Id = 1, UserRole_Name = "Admin", UserRole_Level = UserRoleLevel.Admin },
                new UserRoles { UserRole_Id = 2, UserRole_Name = "Advanced User", UserRole_Level = UserRoleLevel.AdvancedUser },
                new UserRoles { UserRole_Id = 3, UserRole_Name = "User", UserRole_Level = UserRoleLevel.User },
                new UserRoles { UserRole_Id = 4, UserRole_Name = "Restricted Group", UserRole_Level = UserRoleLevel.RestrictedGroup }
            );

            // Adicionar dados iniciais para TeamRoles
            modelBuilder.Entity<TeamRoles>().HasData(
                new TeamRoles { TeamRole_Id = 1, TeamRole_Name = "Leader", TeamRole_Level = TeamRoleLevel.Leader },
                new TeamRoles { TeamRole_Id = 2, TeamRole_Name = "SubLeader", TeamRole_Level = TeamRoleLevel.SubLeader },
                new TeamRoles { TeamRole_Id = 3, TeamRole_Name = "Member", TeamRole_Level = TeamRoleLevel.Member }
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