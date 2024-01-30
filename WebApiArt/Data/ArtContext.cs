using Microsoft.EntityFrameworkCore;
using WebApiArt.Models;

namespace WebApiArt.Data
{
    public class ArtContext : DbContext
    {
        public ArtContext(DbContextOptions<ArtContext> options)
            : base(options)
        {

        }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add a unique index to the OHIP Number
            modelBuilder.Entity<Artwork>()
            .HasIndex(aw => aw.ArtTypeID)
            .IsUnique();
        }
    }
}
