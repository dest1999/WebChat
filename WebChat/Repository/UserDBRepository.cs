using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace WebChat;

public class UserDBRepository : IRepository<User>
{
    private string connectionString;
    private string collectionName = "UsersCollection";
    private static bool isIndexed = false;

    public UserDBRepository(string ConnectionString)
    {
        connectionString = ConnectionString;
    }
    public void Create(User item)
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<User>(collectionName);
        dbCollection.Insert(item);

        if (!isIndexed)
        {
            dbCollection.EnsureIndex(l => l.Login, true);
            dbCollection.EnsureIndex(n => n.UserName, true);
            isIndexed = true;
        }

        db.Commit();
    }

    public void Delete(int id)
    {
        //метод не используется
        throw new NotImplementedException();
    }

    public User Get(int id)
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<User>(collectionName);
        User user = dbCollection.FindById(id);
        return user;
    }

    public IEnumerable<User> GetAll()
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<User>(collectionName);
        var outData = dbCollection.FindAll().ToList();
        return outData;
    }

    public void Update(User item)
    {
        //метод не используется
        throw new NotImplementedException();
    }
}
