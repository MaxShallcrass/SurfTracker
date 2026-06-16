namespace SurfTrackerBackend.Models.Domain;

public class SurfSessionUserObservation
{
    public int SurfSessionUserObservationId { get; set; }
    public int SurfSessionId { get; set; }
    public string? Notes { get; set; }

    public SurfSession SurfSession { get; set; } = null!;
}
