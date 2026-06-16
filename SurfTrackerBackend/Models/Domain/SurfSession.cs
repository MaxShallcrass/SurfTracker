namespace SurfTrackerBackend.Models.Domain;

public class SurfSession
{
    public int SurfSessionId { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int SurfboardId { get; set; }
    public int SurfSpotId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public Surfboard Surfboard { get; set; } = null!;
    public SurfSpot SurfSpot { get; set; } = null!;
    public ICollection<SurfSessionUserObservation> UserObservations { get; set; } = [];
    public ICollection<SurfSessionSwell> Swells { get; set; } = [];
    public ICollection<SurfSessionWeather> WeatherRecords { get; set; } = [];
}
