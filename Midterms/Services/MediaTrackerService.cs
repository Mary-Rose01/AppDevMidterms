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
            Status = "Backlog", 
            Rating = 5,
            PosterUrl = "https://images.unsplash.com/photo-1534447677768-be436bb09401?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now.AddDays(-5) 
        },
        new VideoGame 
        { 
            Title = "Hollow Knight", 
            Platform = "PC", 
            Status = "In Progress", 
            Rating = 4, 
            PosterUrl = "https://images.unsplash.com/photo-1550745165-9bc0b252726f?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now.AddDays(-4) 
        },
        new Movie 
        { 
            Title = "Spirited Away", 
            Director = "Hayao Miyazaki", 
            RuntimeMinutes = 125, 
            Status = "Completed", 
            Rating = 5, 
            PosterUrl = "https://images.unsplash.com/photo-1578632767115-351597cf2477?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now.AddDays(-3) 
        },
        new VideoGame 
        { 
            Title = "Elden Ring", 
            Platform = "PlayStation", 
            Status = "Backlog", 
            Rating = 5,
            PosterUrl = "https://images.unsplash.com/photo-1542751371-adc38448a05e?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now.AddDays(-2) 
        },
        new Movie 
        { 
            Title = "Interstellar", 
            Director = "Christopher Nolan", 
            RuntimeMinutes = 169, 
            Status = "In Progress", 
            Rating = 4,
            PosterUrl = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now.AddDays(-1) 
        },
        new VideoGame 
        { 
            Title = "Celeste", 
            Platform = "Nintendo Switch", 
            Status = "Completed", 
            Rating = 5, 
            PosterUrl = "https://images.unsplash.com/photo-1511512578047-dfb367046420?q=80&w=600&auto=format&fit=crop", 
            AddedOn = DateTime.Now 
        }
    };

    public IEnumerable<MediaItem> GetAllMedia() => _mediaLibrary;

    public void AddMedia(MediaItem item) => _mediaLibrary.Add(item);

    public bool RemoveMedia(Guid id) => _mediaLibrary.RemoveAll(m => m.Id == id) > 0;

    public MediaItem? GetRandomBacklogItem(string? type = null)
    {
        var backlog = _mediaLibrary.Where(m =>
            m.Status == "Backlog" &&
            (type is null or "All"
                || (type == "Movie" && m is Movie)
                || (type == "Game" && m is VideoGame))).ToList();

        return backlog.Count == 0 ? null : backlog[Random.Shared.Next(backlog.Count)];
    }
}