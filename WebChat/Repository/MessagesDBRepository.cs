﻿using LiteDB;

namespace WebChat;

public class MessagesDBRepository : IRepository<UserMessage>
{
    private string connectionString;
    private string collectionName = "MessagesCollection";

    public MessagesDBRepository(string ConnectionString)
    {
        connectionString = ConnectionString;
    }

    public void Create(UserMessage item)
    {
        using var db = new LiteDatabase(connectionString);
        var dbCollection = db.GetCollection<UserMessage>(collectionName);
        dbCollection.Insert(item);
        db.Commit();
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