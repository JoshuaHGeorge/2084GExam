using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace F2019Movies.Models
{
    public partial class f19Context : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public f19Context()
        {
        }

        public f19Context(DbContextOptions<f19Context> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Movie> Movie { get; set; }

        public virtual DbSet<Studio> Studio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add to get Identity to work so we don't get primary key errors. Bug fix for the identity library
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Poster).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.StudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Studio_Movie");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
    }
}
