namespace SurfTrackerBackend.Models.Domain;

public class SurfSessionSwell
{
    public int SurfSessionSwellId { get; set; }
    public int SurfSessionId { get; set; }
    public DateTime Time { get; set; }
    public decimal? WaveHeight { get; set; }
    public decimal? WavePeriod { get; set; }
    public int? WaveDirection { get; set; }
    public decimal? SwellWaveHeight { get; set; }
    public decimal? SwellWavePeriod { get; set; }
    public int? SwellWaveDirection { get; set; }
    public decimal? WindWaveHeight { get; set; }
    public decimal? WindWavePeriod { get; set; }
    public int? WindWaveDirection { get; set; }
    public decimal? SecondarySwellWaveHeight { get; set; }
    public decimal? SecondarySwellWavePeriod { get; set; }
    public int? SecondarySwellWaveDirection { get; set; }
    public decimal? SeaLevelHeightMsl { get; set; }
    public decimal? SeaSurfaceTemperature { get; set; }
    public decimal? OceanCurrentVelocity { get; set; }
    public int? OceanCurrentDirection { get; set; }

    public SurfSession SurfSession { get; set; } = null!;
}
