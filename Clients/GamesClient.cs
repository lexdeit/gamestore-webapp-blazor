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

        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
        };

        games.Add(gameSummary);
    }

}
