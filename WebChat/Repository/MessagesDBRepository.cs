using LiteDB;

namespace WebChat;

public class MessagesDBRepository : IRepository<UserMessage>
{
    private string connectionString;
    private string collectionName = "MessagesCollection";
    private static bool isIndexed = false;

    public MessagesDBRepository(string ConnectionString)
    {
        connectionString = ConnectionString;
    }

    public int Create(UserMessage item)
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<UserMessage>(collectionName);
        int id = dbCollection.Insert(item);

        if (!isIndexed)
        {
            dbCollection.EnsureIndex(x => x.CreatedByUserId);
            dbCollection.EnsureIndex(t => t.Created);
            isIndexed = true;
        }

        db.Commit();
        return id;
    }

    public IEnumerable<UserMessage> GetAll()
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<UserMessage>(collectionName);
        var outData = dbCollection.FindAll().ToList();
        return outData;
    }



    public UserMessage Get(int id)
    {
        throw new NotImplementedException();
    }
    public void Update(UserMessage item)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
