using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Domain.Entites;
using Domain.Repositories;


namespace Infrastructure.Data
{
    public class SystemRepository : ISystemRepository
    {
        public void AddGameSystem(GameSystem gameSystem)
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("INSERT_SYSTEM", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(gameSystem);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<GameSystem> GetGameSystems()
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("RETRIEVE_SYSTEMS", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DataTable dt = new DataTable();
                    var results = new List<GameSystem>();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        var gameSystem = new GameSystem();

                        gameSystem.SystemId = int.Parse(dr["SystemId"].ToString());
                        gameSystem.Name = dr["Name"].ToString();

                        results.Add(gameSystem);
                    }


                    return results;
                }
            }
        }

        public GameSystem GetGameSystemById(int id)
        {
            using (var conn = new SqlConnection(PrivateSettings.SQL_CONNECTION_STRING))
            {
                using (var command = new SqlCommand("RETRIEVE_SYSTEM_BY_ID", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DataTable dt = new DataTable();
                    var result = new GameSystem();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        var gameSystem = new GameSystem();

                        gameSystem.SystemId = int.Parse(dr["SystemId"].ToString());
                        gameSystem.Name = dr["Name"].ToString();

                        result = gameSystem;
                    }


                    return result;
                }
            }
        }
    }
}
