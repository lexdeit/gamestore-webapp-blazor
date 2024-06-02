using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task AddGameAsync(GameDetails game) =>
    await httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id)
    => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find game1");

    public async Task UpdateGameAsync(GameDetails game)
    => await httpClient.PutAsJsonAsync($"games/{game.Id}", game);

    public async Task DeleteGameByIdAsync(int id)
    => await httpClient.DeleteAsync($"games/{id}");

}
