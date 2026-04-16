using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        return post;
    }

    public async Task<Post?> GetByIdAsync(string id)
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Post post)
    {
        post.LastModified = DateTime.UtcNow;
        _context.Posts.Update(post);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string id)
    {
        var post = await GetByIdAsync(id);
        if (post != null)
        {
            // Soft delete instead of hard delete
            post.IsDeleted = true;
            post.IsActive = false;
            _context.Posts.Update(post);
        }
    }

    public async Task<List<Post>> GetPostsByUserIdAsync(string userId)
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .Where(p => p.UserId == userId && !p.IsDeleted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Post>> GetPostsByPetIdAsync(string petId)
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .Where(p => p.PetId == petId && !p.IsDeleted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<List<Post>> GetActivePostsAsync()
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .Where(p => p.IsActive && !p.IsDeleted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }

    public async Task<Post?> GetPostWithDetailsAsync(string postId)
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
                .ThenInclude(f => f.User)
            .FirstOrDefaultAsync(p => p.Id == postId && !p.IsDeleted);
    }

    public async Task<bool> ExistsAsync(string postId)
    {
        return await _context.Posts.AnyAsync(p => p.Id == postId && !p.IsDeleted);
    }

    public async Task<bool> UserOwnsPostAsync(string userId, string postId)
    {
        return await _context.Posts
            .AnyAsync(p => p.Id == postId && p.UserId == userId && !p.IsDeleted);
    }

    public async Task DeleteAllByUserIdAsync(string userId)
    {
        var posts = await _context.Posts
            .Where(p => p.UserId == userId && !p.IsDeleted)
            .ToListAsync();
        
        foreach (var post in posts)
        {
            post.IsDeleted = true;
            post.IsActive = false;
        }
        
        _context.Posts.UpdateRange(posts);
    }

    public async Task DeleteAllByPetIdAsync(string petId)
    {
        var posts = await _context.Posts
            .Where(p => p.PetId == petId && !p.IsDeleted)
            .ToListAsync();
        
        foreach (var post in posts)
        {
            post.IsDeleted = true;
            post.IsActive = false;
        }
        
        _context.Posts.UpdateRange(posts);
    }

    public async Task<int> GetPostCountByUserAsync(string userId)
    {
        return await _context.Posts
            .CountAsync(p => p.UserId == userId && !p.IsDeleted);
    }

    public async Task<int> GetPostCountByPetAsync(string petId)
    {
        return await _context.Posts
            .CountAsync(p => p.PetId == petId && !p.IsDeleted);
    }
    
    
    public async Task<List<Post>> GetAllPendingPosts()
    {
        return await _context.Posts
            .Include(p => p.Pet)
            .Include(p => p.User)
            .Include(p => p.Favourites)
            .Where(p => p.IsActive && !p.IsDeleted)
            .OrderByDescending(p => p.CreationDate)
            .ToListAsync();
    }
}
