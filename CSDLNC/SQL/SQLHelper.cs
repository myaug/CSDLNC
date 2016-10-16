using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CSDLNC.SQL
{
    public class SQLHelper
    {
        //public string connectionString = ConfigurationManager.ConnectionStrings["SQLDatabase"].ToString();
        private string connectionString = "Data Source =.; Initial Catalog = Soccer; Integrated Security = True";
        //public string connectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog = CSDLNC; Integrated Security = True";

        private SqlConnection connection;
        public long timeExecution = 0;

        public SQLHelper() {}

        public SqlConnection OpenConnection()
        {
            if(connection == null)
                connection = new SqlConnection(connectionString);
         
            if(connection.State == ConnectionState.Closed)
                connection.Open();

            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
                connection.Close();
        }

        public void Insert(Player player)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    var cmd = new SqlCommand("INSERT INTO PLAYER VALUES(@player_api_id, @player_name, @player_fifa_api_id, @birthday, @height, @weight)", connection);
                    cmd.Parameters.AddWithValue("@player_api_id", player.Player_api_id);
                    cmd.Parameters.AddWithValue("@player_name", player.Player_name);
                    cmd.Parameters.AddWithValue("@birthday", player.Birthday);
                    cmd.Parameters.AddWithValue("@height", player.Height);
                    cmd.Parameters.AddWithValue("@weight", player.Weight);

                    var sw = Stopwatch.StartNew();

                    cmd.ExecuteNonQuery();

                    sw.Stop();
                    timeExecution = sw.ElapsedMilliseconds;
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
            }
        }

        public long Delete(int player_id, int player_api_id)
        {
            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    var deleteMatchCmd = new SqlCommand("delete M from Match M"
                                                        + "where M.away_player_1 = @playerId"
                                                        + "OR M.away_player_2 = @playerId"
                                                        + "OR M.away_player_3 = @playerId"
                                                        + "OR M.away_player_4 = @playerId"
                                                        + "OR M.away_player_5 = @playerId"
                                                        + "OR M.away_player_6 = @playerId"
                                                        + "OR M.away_player_7 = @playerId"
                                                        + "OR M.away_player_8 = @playerId"
                                                        + "OR M.away_player_9 = @playerId"
                                                        + "OR M.away_player_10 = @playerId"
                                                        + "OR M.away_player_11 = @playerId"
                                                        + "OR M.home_player_1 = @playerId"
                                                        + "OR M.home_player_2 = @playerId"
                                                        + "OR M.home_player_3 = @playerId"
                                                        + "OR M.home_player_4 = @playerId"
                                                        + "OR M.home_player_5 = @playerId"
                                                        + "OR M.home_player_6 = @playerId"
                                                        + "OR M.home_player_7 = @playerId"
                                                        + "OR M.home_player_8 = @playerId"
                                                        + "OR M.home_player_9 = @playerId"
                                                        + "OR M.home_player_10 = @playerId"
                                                        + "OR M.home_player_11 = @playerId");
                    deleteMatchCmd.Parameters.AddWithValue("@playerId", player_id);

                    var deletePlayerStatCmd = new SqlCommand("delete PS from Player_Stats PS" 
                                                                + "where PS.player_api_id = @player_api_id");
                    deletePlayerStatCmd.Parameters.AddWithValue("@player_api_id", player_api_id);

                    var deletePlayerCmd = new SqlCommand("delete from Player where id = @playerId");
                    deletePlayerCmd.Parameters.AddWithValue("@playerId", player_id);

                    var sw = Stopwatch.StartNew();

                    deleteMatchCmd.ExecuteNonQuery();
                    deletePlayerStatCmd.ExecuteNonQuery();
                    deletePlayerCmd.ExecuteNonQuery();

                    sw.Stop();
                    return sw.ElapsedMilliseconds;
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
            }
            return 0;
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
            return 0;
        }

        public DataTable Select()
        {
            //var players = new List<Player>();

            try
            {
                SqlConnection connection = OpenConnection();
                string selectCmd = "select P.*, T.overal_rating from Player P"
                                            + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                                            + " from Player_Stats s"
                                            + " group by s.player_api_id"
                                            + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                var sw = Stopwatch.StartNew();

                dataAdapter.Fill(table);

                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;

                return table;

                    //var cmd = new SqlCommand("select P.*, T.overal_rating from Player P"
                    //                           + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                    //                           + " from Player_Stats s"
                    //                           + " group by s.player_api_id"
                    //                           + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id", connection);

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    int count = 0;
                    //    int player_api_id, height, weight, overal_rating;
                    //    string player_name, birthday;
                    //    while (reader.Read())
                    //    {
                    //        if (count == 1000) return players;

                    //        player_api_id = int.Parse(reader["player_api_id"].ToString());
                    //        player_name = reader["player_name"].ToString();
                    //        birthday = reader["birthday"].ToString();
                    //        height = int.Parse(reader["height"].ToString());
                    //        weight = int.Parse(reader["weight"].ToString());
                    //        overal_rating = int.Parse(reader["overal_rating"].ToString());

                    //        players.Add(new Player()
                    //        {
                    //            Player_api_id = player_api_id,
                    //            Player_name = player_name,
                    //            Birthday = birthday,
                    //            Height = height,
                    //            Weight = weight
                    //        });

                    //        count++;
                    //    }
                    //}
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

            return null;
        }

        public int NumberOfRecord(string tableName)
        {
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) AS [Count] FROM " + tableName, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader["Count"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                CloseConnection();
            }
            return 0;
        }
    }
}
