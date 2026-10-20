using Midterms.Models;

namespace Midterms.Services;

public class MediaTrackerService
{
    private readonly List<MediaItem> _mediaLibrary = new()
    {
        new Movie 
        { 
            Title = "Dune: Part Two", 
            Director = "Denis Villeneuve", 
            RuntimeMinutes = 166, 
            Status = "Backlog" 
        },
        new VideoGame 
        { 
            Title = "Hollow Knight", 
            Platform = "PC", 
            Status = "In Progress" 
        },
        new Movie 
        { 
            Title = "Spirited Away", 
            Director = "Hayao Miyazaki", 
            RuntimeMinutes = 125, 
            Status = "Completed" 
        }
    };

    public IEnumerable<MediaItem> GetAllMedia() => _mediaLibrary;

    public void AddMedia(MediaItem item) => _mediaLibrary.Add(item);

    public MediaItem? GetRandomBacklogItem()
    {
        var backlog = _mediaLibrary.Where(m => m.Status == "Backlog").ToList();
        if (!backlog.Any()) return null;
        
        var random = new Random();
        return backlog[random.Next(backlog.Count)];
    }
}