using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Domain.Entites;
using Domain.Repositories;
using Service.Abstract;

namespace Infrastructure.Data
{
    public class GameRepository : IGameRepository
    {
        private IGameTranslator _gameTranslator;

        public GameRepository(IGameTranslator gameTranslator)
        {
            _gameTranslator = gameTranslator;
        }

        public void AddGames(IEnumerable<Game> games)
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            using (var command = new SqlCommand("INSERT_GAMES", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(games);
                command.ExecuteNonQuery();
            }
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