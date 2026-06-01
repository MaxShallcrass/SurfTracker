namespace SurfTrackerBackend.Services.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string cognitoId);
}
