namespace SurfTrackerBackend.Models.Domain;

public class SurfSpot
{
    public int SurfSpotId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public User User { get; set; } = null!;
    public ICollection<SurfSession> SurfSessions { get; set; } = [];
}
