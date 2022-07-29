using System.Linq;

namespace WebChat;

public class EFUserRepository : IRepository<User>
{
    private readonly DataContext dataContext;

    public EFUserRepository(DataContext DataContext)
    {
        dataContext = DataContext;
    }

    public int Create(User item)
    {
        var db = dataContext;
        db.Users.Add(item);
        db.SaveChanges();
        int lastIndex = db.Users
            .OrderBy(u => u.Id)
            .Last().Id;

        return lastIndex;
    }

    public User Get(int id)
    {
        var db = dataContext;

        User user = db.Users.FirstOrDefault(u => u.Id == id);
        return user;
    }

    public IEnumerable<User> GetAll()
    {
        var db = dataContext;
        var returnValue = db.Users;
        return returnValue;
    }

    public void Update(User item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
