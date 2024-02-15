using MongoDB.Bson;
using MongoDB.Driver;

namespace PyrixMan.Helpers.Implementation;

public class MongoWriter<T>
{
    private readonly IMongoCollection<T> _collection;
    
    public MongoWriter(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<T>(typeof(T).Name);
    }
    
    public void Write(T obj)
    {
        _collection.InsertOne(obj);
    }

    public void Update(T obj, Guid id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        _collection.ReplaceOne(filter, obj);
    }

    public IEnumerable<T> Read()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }
}