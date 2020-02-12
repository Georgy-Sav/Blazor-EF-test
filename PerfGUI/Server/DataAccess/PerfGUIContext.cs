using Microsoft.EntityFrameworkCore;

namespace PerfGUI.Server.DataAccess
{
    public partial class PerfGUIContext : DbContext
    {
        public PerfGUIContext(DbContextOptions<PerfGUIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Environment> Environments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PerfData");

            modelBuilder.Entity<Environment>(env =>
            {
                env.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(true);

                env.HasOne(e => e.Project)
                    .WithMany(p => p.Environments)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasForeignKey(e => e.ProjectId);

                env.ToTable("Environment");
            });

            modelBuilder.Entity<Project>(proj => {
                proj.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                proj.ToTable("Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
