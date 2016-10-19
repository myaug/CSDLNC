using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace CSDLNC.SQL
{
    public class NoSQLHelper
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public long timeExecution = 0;

        public NoSQLHelper() {
            _client = new MongoClient();
            _database = _client.GetDatabase("soccer");
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
            }
            return 0;
        }

        public List<mPlayer> Select()
        {
            var players = new List<mPlayer>();

            try
            {
                var sw = Stopwatch.StartNew();
                var collection = _database.GetCollection<BsonDocument>("Player");
                var response = collection.Aggregate()
                    .Unwind(x => x["Player_Stats"])
                    .Group(new BsonDocument { { "_id", "$_id" }, { "Player_id", new BsonDocument("$first", "$player_id") },
                        { "Player_name", new BsonDocument("$first", "$player_name") }, { "Birthday", new BsonDocument("$first", "$birthday") },
                        { "Height", new BsonDocument("$first", "$height") }, { "Weight", new BsonDocument("$first", "$weight") },
                        { "Overall_rating", new BsonDocument("$max", "$Player_Stats.overall_rating") } })
                    .Sort(new BsonDocument("Overall_rating", -1))
                    .Limit(1000).ToList();
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;

                foreach (BsonDocument item in response)
                {
                    players.Add(BsonSerializer.Deserialize<mPlayer>(item));
                }
            }
            catch (Exception ex)
            {
            }

            return players;
        }

        public List<mPlayer> Select(int player_id)
        {
            var players = new List<mPlayer>();

            try
            {
                var sw = Stopwatch.StartNew();
                var collection = _database.GetCollection<BsonDocument>("Player");
                var filter = Builders<BsonDocument>.Filter.Eq("player_id", player_id);
                var response = collection.Find(filter).ToList();
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;

                foreach (BsonDocument item in response)
                {
                    players.Add(new mPlayer { _id = item["_id"], Player_id = item["player_id"].ToInt32(),
                        Player_name = item["player_name"].ToString(), Birthday = item["birthday"].ToString(),
                        Height = item["height"].ToInt32(), Weight = item["weight"].ToInt32() });
                }
            }
            catch (Exception ex)
            {
            }

            return players;
        }

        public async Task<long> NumberOfRecord(string collectionName)
        {
            try
            {
                var collection = _database.GetCollection<BsonDocument>(collectionName);

                return await collection.CountAsync(new BsonDocument());
            }
            catch (Exception ex)
            {
            }

            return 0;
        }
    }
}
