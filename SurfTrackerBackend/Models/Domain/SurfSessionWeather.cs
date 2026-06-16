namespace SurfTrackerBackend.Models.Domain;

public class SurfSessionWeather
{
    public int SurfSessionWeatherId { get; set; }
    public int SurfSessionId { get; set; }
    public DateTime Time { get; set; }
    public decimal? Temperature2m { get; set; }
    public int? WeatherCode { get; set; }
    public int? CloudCover { get; set; }
    public decimal? WindSpeed10m { get; set; }
    public int? WindDirection10m { get; set; }
    public decimal? UvIndex { get; set; }
    public decimal? Precipitation { get; set; }

    public SurfSession SurfSession { get; set; } = null!;
}
