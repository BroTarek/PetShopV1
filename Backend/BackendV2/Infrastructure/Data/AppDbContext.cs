using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<PetOwner> PetOwners { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Adoption> Adoptions { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User/PetOwner inheritance (TPT or TPH)
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("BasicUser")
            .HasValue<PetOwner>("PetOwner");

        // Relationships
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Pets)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Adoption>()
            .HasOne(a => a.Pet)
            .WithMany(p => p.AdoptionRequests)
            .HasForeignKey(a => a.PetId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Adoption>()
            .HasOne(a => a.Adopter)
            .WithMany(u => u.AdoptionRequests)
            .HasForeignKey(a => a.AdopterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Pet)
            .WithOne(p => p.Review)
            .HasForeignKey<Review>(r => r.PetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Favourite>()
            .HasIndex(f => new { f.UserId, f.PetId }).IsUnique();
    }
}
