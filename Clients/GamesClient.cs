using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{

    private readonly List<GameSummary> games =
   [
   new(){
Id = 1,
Name = "Street Fighter 2",
Genre = "Fighting",
Price = 19.99M,
ReleaseDate = new DateOnly(1992, 7, 15)
},
new(){
Id = 2,
Name = "Fifa",
Genre = "Sports",
Price = 19.99M,
ReleaseDate = new DateOnly(1992, 7, 15)
},
new(){
Id = 3,
Name = "Valorant",
Genre = "Shooter",
Price = 19.99M,
ReleaseDate = new DateOnly(1992, 7, 15)
},
new(){
Id = 4,
Name = "Minecraft",
Genre = "Kids",
Price = 19.99M,
ReleaseDate = new DateOnly(1992, 7, 15)
},
new(){
Id = 5,
Name = "League Of Legends",
Genre = "MOBA",
Price = 19.99M,
ReleaseDate = new DateOnly(1992, 7, 15)
}
   ];


    private readonly Genre[] genres = new GenresClient().GetGenres();
    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
             genre.Name,
             game.Genre,
             StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }

    public void UpdateGame(GameDetails game)
    {
        var genre = GetGenreById(game.GenreId);

        GameSummary existingGame = GetGameSummaryById(game.Id);

        existingGame.Name = game.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;

    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));

    }

}
