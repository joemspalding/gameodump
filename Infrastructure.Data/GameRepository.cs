using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entites;
using Domain.Repositories;
using Service.Abstract;

namespace Infrastructure.Data
{
    public class GameRepository: IGameRepository
    {
        private IGameTranslator _gameTranslator;

        public GameRepository(IGameTranslator gameTranslator)
        {
            _gameTranslator = gameTranslator;
        }

        public void AddGames()
        {
            
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGamesBySystem(GameSystem system)
        {
            throw new NotImplementedException();
        }
    }
}
