using SurfTrackerBackend.Models.Domain;
using SurfTrackerBackend.Models.Exceptions;
using SurfTrackerBackend.Repositories.Interfaces;
using SurfTrackerBackend.Services.Interfaces;

namespace SurfTrackerBackend.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task CreateUserAsync(string cognitoId)
    {
        if (await userRepository.ExistsByCognitoIdAsync(cognitoId))
            throw new ConflictException("User already exists.");

        var user = new User
        {
            CognitoId = cognitoId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await userRepository.AddAsync(user);
    }
}
