namespace Midterms.Models;

public abstract class MediaItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Backlog"; // Backlog, In Progress, Completed

    // NEW
    public string PosterUrl { get; set; } = string.Empty; // optional cover art
    public int Rating { get; set; }                       // 0 = unrated, 1-5 stars
    public DateTime AddedOn { get; set; } = DateTime.Now;

    public abstract string GetMediaBadge();
}
