using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CSDLNC.SQL
{
    public class SQLHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SQLDatabase"].ToString();

        SqlConnection connection;

        public SQLHelper() {
        }

        public SqlConnection OpenConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
                connection.Close();
        }

        public long Insert(Player player)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    var cmd = new SqlCommand("INSERT INTO PLAYER VALUES(@player_api_id, @player_name, @player_fifa_api_id, @birthday, @height, @weight)", connection);
                    cmd.Parameters.AddWithValue("@player_api_id", player.Player_api_id);
                    cmd.Parameters.AddWithValue("@player_name", player.Player_name);
                    cmd.Parameters.AddWithValue("@player_fifa_api_id", player.Player_fifa_api_id);
                    cmd.Parameters.AddWithValue("@birthday", player.Birthday);
                    cmd.Parameters.AddWithValue("@height", player.Height);
                    cmd.Parameters.AddWithValue("@weight", player.Weight);

                    var sw = Stopwatch.StartNew();

                    cmd.ExecuteNonQuery();

                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
            }
            finally
            {
                CloseConnection();
            }

            return 0;
        }

        public void Delete()
        {

        }

        public long Update(string playerName, string birthday, string preferredFoot)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    var cmd = new SqlCommand("UPDATE PS SET PS.preferred_foot = @preferred_foot from Player_Stats PS join Player P on P.player_api_id = PS.player_api_id where P.player_name like @player_name and P.birthday like @birthday", connection);
                    cmd.Parameters.AddWithValue("@preferred_foot", preferredFoot);
                    cmd.Parameters.AddWithValue("@player_name", playerName);
                    cmd.Parameters.AddWithValue("@birthday", birthday);

                    var sw = Stopwatch.StartNew();

                    cmd.ExecuteNonQuery();

                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }

            }
            catch (Exception ex)
            {
                CloseConnection();
            }
            finally
            {
                CloseConnection();
            }
            return 0;
        }

        public List<Player> Select()
        {
            var players = new List<Player>();

            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    var cmd = new SqlCommand("select P.*, T.overal_rating from Player P"
                                               + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                                               + " from Player_Stats s"
                                               + " group by s.player_api_id"
                                               + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id", connection);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int count = 0;
                        int player_api_id, player_fifa_api_id, height, weight, overal_rating;
                        string player_name, birthday;
                        while (reader.Read())
                        {
                            if (count == 1000) return players;

                            player_api_id = int.Parse(reader["player_api_id"].ToString());
                            player_fifa_api_id = int.Parse(reader["player_fifa_api_id"].ToString());
                            player_name = reader["player_name"].ToString();
                            birthday = reader["birthday"].ToString();
                            height = int.Parse(reader["height"].ToString());
                            weight = int.Parse(reader["weight"].ToString());
                            overal_rating = int.Parse(reader["overal_rating"].ToString());

                            players.Add(new Player()
                            {
                                Player_fifa_api_id = player_fifa_api_id,
                                Player_api_id = player_api_id,
                                Player_name = player_name,
                                Birthday = birthday,
                                Height = height,
                                Weight = weight
                            });

                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
            }
            finally
            {
                CloseConnection();
            }

            return players;
        }

        public int Count(string tableName, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) AS [Count] FROM " + tableName , connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return int.Parse(reader["Count"].ToString());
                }
            }

            return 0;
        }
    }
}
