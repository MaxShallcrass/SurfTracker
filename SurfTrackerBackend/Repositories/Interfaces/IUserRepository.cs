using SurfTrackerBackend.Models.Domain;

namespace SurfTrackerBackend.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsByCognitoIdAsync(string cognitoId);
    Task AddAsync(User user);
}
