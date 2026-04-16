using Microsoft.EntityFrameworkCore;
using PetShop.BackendV2.Domain.Entities;
using PetShop.BackendV2.Domain.Enums;
using PetShop.BackendV2.Domain.Interfaces.Repositories;
using PetShop.BackendV2.Infrastructure.Data;

namespace PetShop.BackendV2.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> ApproveUserCreation(User user)
    {
        user.AccountStatus = AccountStatus.Approved;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> RejectUserCreation(User user)
    {
        user.AccountStatus = AccountStatus.Rejected;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> ApprovePostCreation(Post post)
    {
        post.IsActive = true;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        return null; // The old code returned User?, so leaving it as null
    }

    public async Task<User?> RejectPostCreation(Post post)
    {
        post.IsActive = false;
        post.IsDeleted = true;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        return null;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<User>> GetAllPendingUsers()
    {
        return await _context.Users.Where(u => u.AccountStatus == AccountStatus.Pending).ToListAsync();
    }

    public async Task<List<Post>> GetAllPendingPosts()
    {
        return await _context.Posts.Where(p => !p.IsActive && !p.IsDeleted).ToListAsync();
    }

    public async Task<List<Post>> DeletePostAsync(string postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
        return await _context.Posts.ToListAsync();
    }

    public async Task<List<Post>> DeleteUserAsync(string userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        return await _context.Posts.ToListAsync();
    }
}
