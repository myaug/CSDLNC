﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CSDLNC.SQL
{
    public class SQLHelper
    {
        //public string connectionString = ConfigurationManager.ConnectionStrings["SQLDatabase"].ToString();
        //private string connectionString = "Data Source =.; Initial Catalog = Soccer; Integrated Security = True";
        private string connectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog = Soccer; Integrated Security = True";

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
                SqlConnection connection = OpenConnection();
                var cmd = new SqlCommand("INSERT INTO PLAYER(player_api_id, player_name, birthday, height, weight) VALUES(@player_api_id, @player_name, @birthday, @height, @weight)", connection);
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
            catch (Exception ex)
            {
                timeExecution = -1;
                CloseConnection();
            }
        }

        public void Delete(int player_id, int player_api_id)
        {
            try
            {
                SqlConnection connection = OpenConnection();
                //var deleteMatchCmd = new SqlCommand("delete from Match"
                //                                    + " where away_player_1 = @playerId"
                //                                    + " OR away_player_2 = @playerId"
                //                                    + " OR away_player_3 = @playerId"
                //                                    + " OR away_player_4 = @playerId"
                //                                    + " OR away_player_5 = @playerId"
                //                                    + " OR away_player_6 = @playerId"
                //                                    + " OR away_player_7 = @playerId"
                //                                    + " OR away_player_8 = @playerId"
                //                                    + " OR away_player_9 = @playerId"
                //                                    + " OR away_player_10 = @playerId"
                //                                    + " OR away_player_11 = @playerId"
                //                                    + " OR home_player_1 = @playerId"
                //                                    + " OR home_player_2 = @playerId"
                //                                    + " OR home_player_3 = @playerId"
                //                                    + " OR home_player_4 = @playerId"
                //                                    + " OR home_player_5 = @playerId"
                //                                    + " OR home_player_6 = @playerId"
                //                                    + " OR home_player_7 = @playerId"
                //                                    + " OR home_player_8 = @playerId"
                //                                    + " OR home_player_9 = @playerId"
                //                                    + " OR home_player_10 = @playerId"
                //                                    + " OR home_player_11 = @playerId", connection);
                //deleteMatchCmd.Parameters.AddWithValue("@playerId", player_id);

                //var deletePlayerStatCmd = new SqlCommand("delete from Player_Stats" 
                //                                            + " where player_api_id = @player_api_id", connection);
                //deletePlayerStatCmd.Parameters.AddWithValue("@player_api_id", player_api_id);

                var deletePlayerCmd = new SqlCommand("delete from Player where player_api_id = @player_api_id", connection);
                deletePlayerCmd.Parameters.AddWithValue("@player_api_id", player_api_id);

                var sw = Stopwatch.StartNew();

                //deleteMatchCmd.ExecuteNonQuery();
                //deletePlayerStatCmd.ExecuteNonQuery();
                deletePlayerCmd.ExecuteNonQuery();

                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
                CloseConnection();
            }
        }

        public void Update(Player player)
        {
            try
            {
                SqlConnection connection = OpenConnection();
                var cmd = new SqlCommand("update Player " 
                                            + "set player_name = @player_name, birthday = @birthday, weight = @weight, height = @height "
                                            + "where player_api_id = @player_api_id", connection);
                cmd.Parameters.AddWithValue("@player_name", player.Player_name);
                cmd.Parameters.AddWithValue("@birthday", player.Birthday);
                cmd.Parameters.AddWithValue("@weight", player.Weight);
                cmd.Parameters.AddWithValue("@height", player.Height);
                cmd.Parameters.AddWithValue("@player_api_id", player.Player_api_id);

                var sw = Stopwatch.StartNew();

                cmd.ExecuteNonQuery();

                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
        }
            catch (Exception ex)
            {
                timeExecution = -1;
                CloseConnection();
            }
        }

        public DataTable Select()
        {
            try
            {
                SqlConnection connection = OpenConnection();
                string selectCmd = "select P.id, P.player_api_id, P.player_name, P.birthday, P.height, P.weight, T.overal_rating from Player P"
                                            + " join (select top 1000 s.player_api_id, MAX(s.overall_rating) AS [overal_rating]"
                                            + " from Player_Stats s"
                                            + " group by s.player_api_id"
                                            + " order by MAX(s.overall_rating) desc) T on T.player_api_id = P.player_api_id"
                                            + " order by T.overal_rating desc";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                var sw = Stopwatch.StartNew();

                dataAdapter.Fill(table);

                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;

                return table;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
                CloseConnection();
            }

            return null;
        }

        public DataTable Select(int player_api_id)
        {
            try
            {
                SqlConnection connection = OpenConnection();
                string selectCmd = "select P.id, P.player_api_id, P.player_name, P.birthday, P.height, P.weight from Player P"
                                            + " where P.player_api_id = @player_api_id";
                var cmd = new SqlCommand(selectCmd, connection);
                cmd.Parameters.AddWithValue("@player_api_id", player_api_id);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                var sw = Stopwatch.StartNew();

                dataAdapter.Fill(table);

                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;

                return table;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
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
