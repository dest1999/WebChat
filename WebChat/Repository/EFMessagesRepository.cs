namespace WebChat;

public class EFMessagesRepository : IRepository<UserMessage>
{
    private readonly DataContext dataContext;

    public EFMessagesRepository(DataContext DataContext)
    {
        dataContext = DataContext;
    }

    public int Create(UserMessage item)
    {
        var db = dataContext;
        db.UserMessages.Add(item);
        db.SaveChanges();
        int lastIndex = db.UserMessages
            .OrderBy(m => m.Id)
            .Last().Id;

        return lastIndex;
    }

    public IEnumerable<UserMessage> GetAll()
    {
        var db = dataContext.UserMessages.ToArray();
        return db;
    }

    public void Update(UserMessage item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public UserMessage Get(int id)
    {
        throw new NotImplementedException();
    }
}
