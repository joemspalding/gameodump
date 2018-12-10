using Domain.Entites;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IGameRepository
    {
        void AddGames(IEnumerable<Game> games);
        IEnumerable<Game> GetGames();
        Game GetGameById(int id);
        IEnumerable<Game> GetGamesBySystem(GameSystem system);
    }
}
