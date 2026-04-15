using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Review> CreateAsync(Review review)
    {
        review.CreatedAt = DateTime.UtcNow;
        review.ModificationDate = DateTime.UtcNow;
        await _context.Reviews.AddAsync(review);
        return review;
    }

    public async Task<Review?> GetByIdAsync(string id)
    {
        return await _context.Reviews
            .Include(r => r.Reviewer)
            .Include(r => r.Reviewee)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task UpdateAsync(Review review)
    {
        review.ModificationDate = DateTime.UtcNow;
        _context.Reviews.Update(review);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var review = await GetByIdAsync(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
        }
    }

    public async Task<List<Review>> GetReviewsByReviewerIdAsync(string reviewerId)
    {
        return await _context.Reviews
            .Include(r => r.Reviewee)
            .Where(r => r.ReviewerId == reviewerId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Review>> GetReviewsByRevieweeIdAsync(string revieweeId)
    {
        return await _context.Reviews
            .Include(r => r.Reviewer)
            .Where(r => r.RevieweeId == revieweeId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<Review?> GetReviewByReviewerAndRevieweeAsync(string reviewerId, string revieweeId)
    {
        return await _context.Reviews
            .FirstOrDefaultAsync(r => r.ReviewerId == reviewerId && r.RevieweeId == revieweeId);
    }
    

    public async Task<int> GetReviewCountForUserAsync(string userId)
    {
        return await _context.Reviews
            .CountAsync(r => r.RevieweeId == userId);
    }

    public async Task<bool> UserHasReviewedUserAsync(string reviewerId, string revieweeId)
    {
        return await _context.Reviews
            .AnyAsync(r => r.ReviewerId == reviewerId && r.RevieweeId == revieweeId);
    }

    public async Task<bool> ExistsAsync(string reviewId)
    {
        return await _context.Reviews.AnyAsync(r => r.Id == reviewId);
    }

    public async Task DeleteAllReviewsByUserAsync(string userId)
    {
        var reviews = await _context.Reviews
            .Where(r => r.ReviewerId == userId)
            .ToListAsync();
        
        _context.Reviews.RemoveRange(reviews);
    }

    public async Task DeleteAllReviewsForUserAsync(string userId)
    {
        var reviews = await _context.Reviews
            .Where(r => r.RevieweeId == userId)
            .ToListAsync();
        
        _context.Reviews.RemoveRange(reviews);
    }
}