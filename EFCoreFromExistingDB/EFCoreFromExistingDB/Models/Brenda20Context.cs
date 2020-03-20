using Microsoft.EntityFrameworkCore;

namespace EFCoreFromExistingDB.Models
{
    public partial class Brenda20Context : DbContext
    {
        public Brenda20Context()
        {
        }

        public Brenda20Context(DbContextOptions<Brenda20Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillLevel> SkillLevel { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserSkill> UserSkill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Brenda2.0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.HasOne(d => d.Level)
                    .WithMany(p => p.SkillLevel)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SkillLevel_LevelID");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SkillLevel)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SkillLevel_SkillID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.DesiredRole)
                    .WithMany(p => p.UserDesiredRole)
                    .HasForeignKey(d => d.DesiredRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_DesiredRoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_RoleID");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkill)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSkill_UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
