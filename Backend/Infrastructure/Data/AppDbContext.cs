using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;

namespace PetShop.BackendV2.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relationships
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Pets)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AdoptionRequest>()
            .HasOne(a => a.Pet)
            .WithMany(p => p.AdoptionRequests)
            .HasForeignKey(a => a.PetId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AdoptionRequest>()
            .HasOne(a => a.Initiator)
            .WithMany(u => u.AdoptionRequestsInitiated)
            .HasForeignKey(a => a.InitiatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AdoptionRequest>()
            .HasOne(a => a.Receiver)
            .WithMany(u => u.AdoptionRequestsReceived)
            .HasForeignKey(a => a.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Reviewer)
            .WithMany(u => u.ReviewsMade)
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Reviewee)
            .WithMany(u => u.ReviewsReceived)
            .HasForeignKey(r => r.RevieweeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Favourite>()
            .HasIndex(f => new { f.UserId, f.PostId }).IsUnique();

        modelBuilder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
