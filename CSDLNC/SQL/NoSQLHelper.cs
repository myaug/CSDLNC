<<<<<<< Updated upstream
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CSDLNC.SQL
{
    public class NoSQLHelper
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        SqlConnection connection;

        public NoSQLHelper() {
            
        }

        public void OpenConnection()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("CSDLNC");

            //return connection;
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("INSERT INTO PLAYER VALUES(@player_api_id, @player_name, @player_fifa_api_id, @birthday, @height, @weight)", connection);
                //    cmd.Parameters.AddWithValue("@player_api_id", player.Player_api_id);
                //    cmd.Parameters.AddWithValue("@player_name", player.Player_name);
                //    cmd.Parameters.AddWithValue("@player_fifa_api_id", player.Player_fifa_api_id);
                //    cmd.Parameters.AddWithValue("@birthday", player.Birthday);
                //    cmd.Parameters.AddWithValue("@height", player.Height);
                //    cmd.Parameters.AddWithValue("@weight", player.Weight);

                //    var sw = Stopwatch.StartNew();

                //    cmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

            return 0;
        }

        public long Delete(int player_id, int player_fifa_api_id, int player_api_id)
        {
            try
            {
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var deleteMatchCmd = new SqlCommand("delete M from Match M"
                //                                        + "where M.away_player_1 = @playerId"
                //                                        + "OR M.away_player_2 = @playerId"
                //                                        + "OR M.away_player_3 = @playerId"
                //                                        + "OR M.away_player_4 = @playerId"
                //                                        + "OR M.away_player_5 = @playerId"
                //                                        + "OR M.away_player_6 = @playerId"
                //                                        + "OR M.away_player_7 = @playerId"
                //                                        + "OR M.away_player_8 = @playerId"
                //                                        + "OR M.away_player_9 = @playerId"
                //                                        + "OR M.away_player_10 = @playerId"
                //                                        + "OR M.away_player_11 = @playerId"
                //                                        + "OR M.home_player_1 = @playerId"
                //                                        + "OR M.home_player_2 = @playerId"
                //                                        + "OR M.home_player_3 = @playerId"
                //                                        + "OR M.home_player_4 = @playerId"
                //                                        + "OR M.home_player_5 = @playerId"
                //                                        + "OR M.home_player_6 = @playerId"
                //                                        + "OR M.home_player_7 = @playerId"
                //                                        + "OR M.home_player_8 = @playerId"
                //                                        + "OR M.home_player_9 = @playerId"
                //                                        + "OR M.home_player_10 = @playerId"
                //                                        + "OR M.home_player_11 = @playerId");
                //    deleteMatchCmd.Parameters.AddWithValue("@playerId", player_id);

                //    var deletePlayerStatCmd = new SqlCommand("delete PS from Player_Stats PS" 
                //                                                + "where PS.player_api_id = @player_api_id"
                //                                                + "and PS.player_fifa_api_id = @player_fifa_api_id");
                //    deletePlayerStatCmd.Parameters.AddWithValue("@player_api_id", player_api_id);
                //    deletePlayerStatCmd.Parameters.AddWithValue("@player_fifa_api_id", player_fifa_api_id);

                //    var deletePlayerCmd = new SqlCommand("delete from Player where id = @playerId");
                //    deletePlayerCmd.Parameters.AddWithValue("@playerId", player_id);

                //    var sw = Stopwatch.StartNew();

                //    deleteMatchCmd.ExecuteNonQuery();
                //    deletePlayerStatCmd.ExecuteNonQuery();
                //    deletePlayerCmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("UPDATE PS SET PS.preferred_foot = @preferred_foot from Player_Stats PS join Player P on P.player_api_id = PS.player_api_id where P.player_name like @player_name and P.birthday like @birthday", connection);
                //    cmd.Parameters.AddWithValue("@preferred_foot", preferredFoot);
                //    cmd.Parameters.AddWithValue("@player_name", playerName);
                //    cmd.Parameters.AddWithValue("@birthday", birthday);

                //    var sw = Stopwatch.StartNew();

                //    cmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
            }
            catch (Exception ex)
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("select P.*, T.overal_rating from Player P"
                //                               + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                //                               + " from Player_Stats s"
                //                               + " group by s.player_api_id"
                //                               + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id", connection);

                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        int count = 0;
                //        int player_api_id, player_fifa_api_id, height, weight, overal_rating;
                //        string player_name, birthday;
                //        while (reader.Read())
                //        {
                //            if (count == 1000) return players;

                //            player_api_id = int.Parse(reader["player_api_id"].ToString());
                //            player_fifa_api_id = int.Parse(reader["player_fifa_api_id"].ToString());
                //            player_name = reader["player_name"].ToString();
                //            birthday = reader["birthday"].ToString();
                //            height = int.Parse(reader["height"].ToString());
                //            weight = int.Parse(reader["weight"].ToString());
                //            overal_rating = int.Parse(reader["overal_rating"].ToString());

                //            players.Add(new Player()
                //            {
                //                Player_fifa_api_id = player_fifa_api_id,
                //                Player_api_id = player_api_id,
                //                Player_name = player_name,
                //                Birthday = birthday,
                //                Height = height,
                //                Weight = weight
                //            });

                //            count++;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

            return players;
        }

        public int NumberOfRecord(string tableName)
        {
            try
            {
                //SqlConnection connection = OpenConnection();
                //SqlCommand cmd = new SqlCommand("SELECT COUNT(1) AS [Count] FROM " + tableName, connection);
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        return int.Parse(reader["Count"].ToString());
                //    }
                //}
            }
            catch(Exception ex)
            {
                CloseConnection();
            }
            return 0;
        }
    }
}
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CSDLNC.SQL
{
    public class NoSQLHelper
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        SqlConnection connection;

        public NoSQLHelper() {
            
        }

        public void OpenConnection()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("Soccer");

            //return connection;
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("INSERT INTO PLAYER VALUES(@player_api_id, @player_name, @player_fifa_api_id, @birthday, @height, @weight)", connection);
                //    cmd.Parameters.AddWithValue("@player_api_id", player.Player_api_id);
                //    cmd.Parameters.AddWithValue("@player_name", player.Player_name);
                //    cmd.Parameters.AddWithValue("@player_fifa_api_id", player.Player_fifa_api_id);
                //    cmd.Parameters.AddWithValue("@birthday", player.Birthday);
                //    cmd.Parameters.AddWithValue("@height", player.Height);
                //    cmd.Parameters.AddWithValue("@weight", player.Weight);

                //    var sw = Stopwatch.StartNew();

                //    cmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

            return 0;
        }

        public long Delete(int player_id, int player_fifa_api_id, int player_api_id)
        {
            try
            {
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var deleteMatchCmd = new SqlCommand("delete M from Match M"
                //                                        + "where M.away_player_1 = @playerId"
                //                                        + "OR M.away_player_2 = @playerId"
                //                                        + "OR M.away_player_3 = @playerId"
                //                                        + "OR M.away_player_4 = @playerId"
                //                                        + "OR M.away_player_5 = @playerId"
                //                                        + "OR M.away_player_6 = @playerId"
                //                                        + "OR M.away_player_7 = @playerId"
                //                                        + "OR M.away_player_8 = @playerId"
                //                                        + "OR M.away_player_9 = @playerId"
                //                                        + "OR M.away_player_10 = @playerId"
                //                                        + "OR M.away_player_11 = @playerId"
                //                                        + "OR M.home_player_1 = @playerId"
                //                                        + "OR M.home_player_2 = @playerId"
                //                                        + "OR M.home_player_3 = @playerId"
                //                                        + "OR M.home_player_4 = @playerId"
                //                                        + "OR M.home_player_5 = @playerId"
                //                                        + "OR M.home_player_6 = @playerId"
                //                                        + "OR M.home_player_7 = @playerId"
                //                                        + "OR M.home_player_8 = @playerId"
                //                                        + "OR M.home_player_9 = @playerId"
                //                                        + "OR M.home_player_10 = @playerId"
                //                                        + "OR M.home_player_11 = @playerId");
                //    deleteMatchCmd.Parameters.AddWithValue("@playerId", player_id);

                //    var deletePlayerStatCmd = new SqlCommand("delete PS from Player_Stats PS" 
                //                                                + "where PS.player_api_id = @player_api_id"
                //                                                + "and PS.player_fifa_api_id = @player_fifa_api_id");
                //    deletePlayerStatCmd.Parameters.AddWithValue("@player_api_id", player_api_id);
                //    deletePlayerStatCmd.Parameters.AddWithValue("@player_fifa_api_id", player_fifa_api_id);

                //    var deletePlayerCmd = new SqlCommand("delete from Player where id = @playerId");
                //    deletePlayerCmd.Parameters.AddWithValue("@playerId", player_id);

                //    var sw = Stopwatch.StartNew();

                //    deleteMatchCmd.ExecuteNonQuery();
                //    deletePlayerStatCmd.ExecuteNonQuery();
                //    deletePlayerCmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("UPDATE PS SET PS.preferred_foot = @preferred_foot from Player_Stats PS join Player P on P.player_api_id = PS.player_api_id where P.player_name like @player_name and P.birthday like @birthday", connection);
                //    cmd.Parameters.AddWithValue("@preferred_foot", preferredFoot);
                //    cmd.Parameters.AddWithValue("@player_name", playerName);
                //    cmd.Parameters.AddWithValue("@birthday", birthday);

                //    var sw = Stopwatch.StartNew();

                //    cmd.ExecuteNonQuery();

                //    sw.Stop();
                //    return sw.ElapsedMilliseconds;
                //}
            }
            catch (Exception ex)
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
                //using (SqlConnection connection = OpenConnection())
                //{
                //    var cmd = new SqlCommand("select P.*, T.overal_rating from Player P"
                //                               + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                //                               + " from Player_Stats s"
                //                               + " group by s.player_api_id"
                //                               + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id", connection);

                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        int count = 0;
                //        int player_api_id, player_fifa_api_id, height, weight, overal_rating;
                //        string player_name, birthday;
                //        while (reader.Read())
                //        {
                //            if (count == 1000) return players;

                //            player_api_id = int.Parse(reader["player_api_id"].ToString());
                //            player_fifa_api_id = int.Parse(reader["player_fifa_api_id"].ToString());
                //            player_name = reader["player_name"].ToString();
                //            birthday = reader["birthday"].ToString();
                //            height = int.Parse(reader["height"].ToString());
                //            weight = int.Parse(reader["weight"].ToString());
                //            overal_rating = int.Parse(reader["overal_rating"].ToString());

                //            players.Add(new Player()
                //            {
                //                Player_fifa_api_id = player_fifa_api_id,
                //                Player_api_id = player_api_id,
                //                Player_name = player_name,
                //                Birthday = birthday,
                //                Height = height,
                //                Weight = weight
                //            });

                //            count++;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

            return players;
        }

        public int NumberOfRecord(string tableName)
        {
            try
            {
                //SqlConnection connection = OpenConnection();
                //SqlCommand cmd = new SqlCommand("SELECT COUNT(1) AS [Count] FROM " + tableName, connection);
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        return int.Parse(reader["Count"].ToString());
                //    }
                //}
            }
            catch(Exception ex)
            {
                CloseConnection();
            }
            return 0;
        }
    }
}
>>>>>>> Stashed changes
