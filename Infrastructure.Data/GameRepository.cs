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
            {
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
        }

        public IEnumerable<Game> GetGames()
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("RETRIEVE_GAMES", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DataTable dt = new DataTable();
                    List<Game> details = new List<Game>();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Game game = new Game();

                        game.GameId = int.Parse(dr["GameId"].ToString());
                        game.Title = dr["Title"].ToString();
                        game.SystemId = int.Parse(dr["SystemId"].ToString());

                        details.Add(game);
                    }


                    return details;
                }
            }
        }

        public Game GetGameById(int id)
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("RETRIEVE_GAME_BY_ID", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DataTable dt = new DataTable();
                    var detail = new Game();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Game game = new Game();

                        game.GameId = int.Parse(dr["GameId"].ToString());
                        game.Title = dr["Title"].ToString();
                        game.SystemId = int.Parse(dr["SystemId"].ToString());

                        detail = game;
                    }


                    return detail;
                }
            }
        }

        public IEnumerable<Game> GetGamesBySystem(GameSystem system)
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("RETRIEVE_GAMES_BY_SYSTEM", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DataTable dt = new DataTable();
                    List<Game> details = new List<Game>();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        Game game = new Game();

                        game.GameId = int.Parse(dr["GameId"].ToString());
                        game.Title = dr["Title"].ToString();
                        game.SystemId = int.Parse(dr["SystemId"].ToString());

                        details.Add(game);
                    }


                    return details;
                }
            }
        }
    }
}