namespace Midterms.Models;

public class VideoGame : MediaItem
{
    public string Platform { get; set; } = string.Empty; // e.g., PC, PS5, Nintendo Switch

    public override string GetMediaBadge() => "🎮 Game";
}