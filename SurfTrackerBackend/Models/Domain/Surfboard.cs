namespace SurfTrackerBackend.Models.Domain;

public class Surfboard
{
    public int SurfboardId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;

    public User User { get; set; } = null!;
    public ICollection<SurfSession> SurfSessions { get; set; } = [];
}
