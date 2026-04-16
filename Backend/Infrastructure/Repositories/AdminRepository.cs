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
        user.Status = AccountStatus.APPROVED;
        return await UpdateAsync(user);
    }

    public async Task<User> RejectUserCreation(User user)
    {
        user.Status = AccountStatus.REJECTED;
        return await UpdateAsync(user);
    }

    public async Task<User?> ApprovePostCreation(Post post)
    {
        post.Status = PostStatus.APPROVED;
        return await UpdateAsync(post);
    }

    public async Task<User?> RejectPostCreation(Post post)
    {
        post.Status = PostStatus.REJECTED;
        return await UpdateAsync(post);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<User>> GetAllPendingUsers()
    {
        return await _context.Users.Where(u => u.Status == AccountStatus.PENDING).ToListAsync();
    }

    public async Task<List<Post>> GetAllPendingPosts()
    {
        return await _context.Posts.Where(p => p.Status == PostStatus.PENDING).ToListAsync();
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