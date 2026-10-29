namespace Midterms.Models;

public abstract class MediaItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Backlog"; // Backlog, In Progress, Completed
    public string Genre { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public int Rating { get; set; } // 0 = unrated, 1-5 stars
    public DateTime AddedOn { get; set; } = DateTime.Now;
    public DateTime? StartedOn { get; set; }
    public DateTime? CompletedOn { get; set; }

    public abstract string GetMediaBadge();

    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;
        SyncDates();
    }

    public void SyncDates()
    {
        switch (Status)
        {
            case "Backlog":
                StartedOn = null;
                CompletedOn = null;
                break;
            case "In Progress":
                StartedOn ??= DateTime.Now;
                CompletedOn = null;
                break;
            case "Completed":
                StartedOn ??= DateTime.Now;
                CompletedOn ??= DateTime.Now;
                break;
        }
    }
}