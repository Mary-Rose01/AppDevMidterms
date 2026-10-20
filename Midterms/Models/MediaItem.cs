namespace Midterms.Models;

public abstract class MediaItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Backlog"; // Backlog, In Progress, Completed
    
    // Abstract method forcing child classes to supply their own badge UI details
    public abstract string GetMediaBadge(); 
}