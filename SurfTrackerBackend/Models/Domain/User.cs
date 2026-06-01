namespace SurfTrackerBackend.Models.Domain;

public class User
{
    public int UserId { get; set; }
    public string CognitoId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
