using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class FavouriteRepository : IFavouriteRepository
{
    private readonly AppDbContext _context;

    public FavouriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Favourite> CreateAsync(Favourite favourite)
    {
        await _context.Favourites.AddAsync(favourite);
        return favourite;
    }

    public async Task<Favourite?> GetByIdAsync(string id)
    {
        return await _context.Favourites
            .Include(f => f.User)
            .Include(f => f.Post)
            .ThenInclude(p => p.Pet)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task DeleteAsync(string id)
    {
        var favourite = await GetByIdAsync(id);
        if (favourite != null)
        {
            _context.Favourites.Remove(favourite);
        }
    }

    public async Task UpdateAsync(Favourite favourite)
    {
        _context.Favourites.Update(favourite);
        await Task.CompletedTask;
    }

    public async Task<List<Favourite>> GetFavouritesByUserIdAsync(string userId)
    {
        return await _context.Favourites
            .Include(f => f.Post)
                .ThenInclude(p => p.Pet)
            .Include(f => f.User)
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Favourite>> GetFavouritesByPostIdAsync(string postId)
    {
        return await _context.Favourites
            .Include(f => f.User)
            .Where(f => f.PostId == postId)
            .ToListAsync();
    }

    public async Task<Favourite?> GetFavouriteByUserAndPostAsync(string userId, string postId)
    {
        return await _context.Favourites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.PostId == postId);
    }

    public async Task<bool> ExistsAsync(string userId, string postId)
    {
        return await _context.Favourites
            .AnyAsync(f => f.UserId == userId && f.PostId == postId);
    }

    public async Task<int> GetFavouriteCountByPostAsync(string postId)
    {
        return await _context.Favourites
            .CountAsync(f => f.PostId == postId);
    }

    public async Task<int> GetFavouriteCountByUserAsync(string userId)
    {
        return await _context.Favourites
            .CountAsync(f => f.UserId == userId);
    }

    public async Task DeleteAllByUserIdAsync(string userId)
    {
        var favourites = await _context.Favourites
            .Where(f => f.UserId == userId)
            .ToListAsync();
        
        _context.Favourites.RemoveRange(favourites);
    }

    public async Task DeleteAllByPostIdAsync(string postId)
    {
        var favourites = await _context.Favourites
            .Where(f => f.PostId == postId)
            .ToListAsync();
        
        _context.Favourites.RemoveRange(favourites);
    }

    public async Task<List<Favourite>> GetFavouritesWithIncludesAsync(string userId)
    {
        return await _context.Favourites
            .Include(f => f.Post)
                .ThenInclude(p => p.Pet)
            .Include(f => f.Post)
                .ThenInclude(p => p.User)  // Post owner
            .Include(f => f.User)
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }
}