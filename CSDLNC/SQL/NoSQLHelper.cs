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

        public void Insert(mPlayer player)
        {
            try
            {
                var collection = _database.GetCollection<BsonDocument>("Player");
                var sw = Stopwatch.StartNew();
                collection.InsertOne(new BsonDocument { { "player_id", player.Player_id }, { "player_name", player.Player_name },
                    { "birthday", player.Birthday }, { "height", player.Height }, { "weight", player.Weight } });
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
            }
        }

        public void Delete(int player_id)
        {
            try
            {
                var collection = _database.GetCollection<BsonDocument>("Player");
                var filter = Builders<BsonDocument>.Filter.Eq("player_id", player_id);
                var sw = Stopwatch.StartNew();
                collection.DeleteMany(filter);
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
            }
        }

        public void Update(mPlayer player)
        {
            try
            {
                var collection = _database.GetCollection<BsonDocument>("Player");
                var filter = Builders<BsonDocument>.Filter.Eq("player_id", player.Player_id);
                var update = Builders<BsonDocument>.Update.Set("player_name", player.Player_name).
                    Set("birthday", player.Birthday).Set("height", player.Height).Set("weight", player.Weight);
                var sw = Stopwatch.StartNew();
                collection.UpdateMany(filter, update);
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                timeExecution = -1;
            }
        }

        public List<mPlayer> Select()
        {
            var players = new List<mPlayer>();

            try
            {
                var collection = _database.GetCollection<BsonDocument>("Player");
                var sw = Stopwatch.StartNew();
                var response = collection.Aggregate()
                    .Unwind(x => x["Player_Stats"])
                    .Group(new BsonDocument { { "_id", "$_id" }, { "Player_id", new BsonDocument("$first", "$player_id") },
                        { "Player_name", new BsonDocument("$first", "$player_name") }, { "Birthday", new BsonDocument("$first", "$birthday") },
                        { "Height", new BsonDocument("$first", "$height") }, { "Weight", new BsonDocument("$first", "$weight") },
                        { "Overall_rating", new BsonDocument("$max", "$Player_Stats.overall_rating") } })
                    .Sort(new BsonDocument("Overall_rating", -1))
                    .Limit(1000);
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
                var list = response.ToList();

                foreach (BsonDocument item in list)
                {
                    players.Add(BsonSerializer.Deserialize<mPlayer>(item));
                }
            }
            catch (Exception ex)
            {
                timeExecution = -1;
            }

            return players;
        }

        public List<mPlayer> Select(int player_id)
        {
            var players = new List<mPlayer>();

            try
            {
                var collection = _database.GetCollection<BsonDocument>("Player");
                var filter = Builders<BsonDocument>.Filter.Eq("player_id", player_id);
                var sw = Stopwatch.StartNew();
                var response = collection.Find(filter);
                sw.Stop();
                timeExecution = sw.ElapsedMilliseconds;
                var list = response.ToList();

                foreach (BsonDocument item in list)
                {
                    players.Add(new mPlayer { _id = item["_id"], Player_id = item["player_id"].ToInt32(),
                        Player_name = item["player_name"].ToString(), Birthday = item["birthday"].ToString(),
                        Height = item["height"].ToInt32(), Weight = item["weight"].ToInt32() });
                }
            }
            catch (Exception ex)
            {
                timeExecution = -1;
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
