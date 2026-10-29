using Midterms.Models;

namespace Midterms.Services;

public class MediaTrackerService
{
    private static DateTime Ago(int days) => DateTime.Now.AddDays(-days);

    private readonly List<MediaItem> _mediaLibrary = new()
    {
        new Movie
        {
            Title = "Dune: Part Two", Director = "Denis Villeneuve", RuntimeMinutes = 166, Genre = "Sci-Fi",
            Status = "Backlog", Rating = 5, AddedOn = Ago(45),
            PosterUrl = "https://images.unsplash.com/photo-1534447677768-be436bb09401?q=80&w=600&auto=format&fit=crop"
        },
        new VideoGame
        {
            Title = "Hollow Knight", Platform = "PC", Genre = "Metroidvania",
            Status = "In Progress", Rating = 4, AddedOn = Ago(20), StartedOn = Ago(4),
            PosterUrl = "https://images.unsplash.com/photo-1550745165-9bc0b252726f?q=80&w=600&auto=format&fit=crop"
        },
        new Movie
        {
            Title = "Spirited Away", Director = "Hayao Miyazaki", RuntimeMinutes = 125, Genre = "Animation",
            Status = "Completed", Rating = 5, AddedOn = Ago(70), StartedOn = Ago(60), CompletedOn = Ago(60),
            PosterUrl = "https://images.unsplash.com/photo-1578632767115-351597cf2477?q=80&w=600&auto=format&fit=crop"
        },
        new VideoGame
        {
            Title = "Elden Ring", Platform = "PlayStation", Genre = "Action RPG",
            Status = "Backlog", Rating = 5, AddedOn = Ago(2),
            PosterUrl = "https://images.unsplash.com/photo-1542751371-adc38448a05e?q=80&w=600&auto=format&fit=crop"
        },
        new Movie
        {
            Title = "Interstellar", Director = "Christopher Nolan", RuntimeMinutes = 169, Genre = "Sci-Fi",
            Status = "In Progress", Rating = 4, AddedOn = Ago(10), StartedOn = Ago(1),
            PosterUrl = "https://images.unsplash.com/photo-1451187580459-43490279c0fa?q=80&w=600&auto=format&fit=crop"
        },
        new VideoGame
        {
            Title = "Celeste", Platform = "Nintendo Switch", Genre = "Platformer",
            Status = "Completed", Rating = 5, AddedOn = Ago(30), StartedOn = Ago(20), CompletedOn = Ago(15),
            PosterUrl = "https://images.unsplash.com/photo-1511512578047-dfb367046420?q=80&w=600&auto=format&fit=crop"
        },
        new Movie
        {
            Title = "Parasite", Director = "Bong Joon-ho", RuntimeMinutes = 132, Genre = "Thriller",
            Status = "Completed", Rating = 5, AddedOn = Ago(50), StartedOn = Ago(35), CompletedOn = Ago(35)
        },
        new VideoGame
        {
            Title = "Hades", Platform = "PC", Genre = "Roguelike",
            Status = "Completed", Rating = 4, AddedOn = Ago(90), StartedOn = Ago(75), CompletedOn = Ago(50)
        },
        new Movie
        {
            Title = "Whiplash", Director = "Damien Chazelle", RuntimeMinutes = 107, Genre = "Drama",
            Status = "Completed", Rating = 4, AddedOn = Ago(25), StartedOn = Ago(8), CompletedOn = Ago(8)
        }
    };

    public IEnumerable<MediaItem> GetAllMedia() => _mediaLibrary;

    public void AddMedia(MediaItem item)
    {
        item.SyncDates();
        _mediaLibrary.Add(item);
    }

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