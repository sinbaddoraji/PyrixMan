using PyrixMan.Model;

namespace PyrixMan.Helpers.Implementation;

public class UserDataMongoWriter : MongoWriter<User>
{
    public UserDataMongoWriter(string connectionString, string databaseName) : base(connectionString, databaseName)
    {
    }
}