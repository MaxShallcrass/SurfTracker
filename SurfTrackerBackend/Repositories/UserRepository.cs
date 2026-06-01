using Microsoft.EntityFrameworkCore;
using SurfTrackerBackend.Data;
using SurfTrackerBackend.Models.Domain;
using SurfTrackerBackend.Repositories.Interfaces;

namespace SurfTrackerBackend.Repositories;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<bool> ExistsByCognitoIdAsync(string cognitoId)
        => await db.Users.AnyAsync(u => u.CognitoId == cognitoId);

    public async Task AddAsync(User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
    }
}
