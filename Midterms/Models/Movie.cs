namespace Midterms.Models;

public class Movie : MediaItem
{
    public int RuntimeMinutes { get; set; }
    public string Director { get; set; } = string.Empty;

    public override string GetMediaBadge() => "🎬 Movie";
}