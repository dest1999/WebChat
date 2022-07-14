using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace WebChat;

public class UserDBRepository : IUserRepository<User>
{
    private string connectionString;

    public UserDBRepository(string ConnectionString)
    {
        connectionString = ConnectionString;
    }
    public void Create(User item)
    {
        using var db = new LiteDatabase(connectionString);

        //throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        //метод не используется
        throw new NotImplementedException();
    }

    public User Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        using var db = new LiteDatabase(connectionString);

        var dbCollection = db.GetCollection<User>("UsersCollection");

        #region добавление пользователей для тестирования

        if (dbCollection.Count() == 0)
        {
            dbCollection.Insert(new User
            {
                UserName = "UserName",
                Login = "login",
                Password = "pass"
            });
        }

        dbCollection.Insert(new User
        {
            UserName = "UserName" + dbCollection.FindById(dbCollection.Count()).Id + 1,
            Login = "login",
            Password = "pass"
        });

        dbCollection.Insert(new User
        {
            UserName = "UserName" + dbCollection.FindById(dbCollection.Count()).Id + 1,
            Login = "login",
            Password = "pass"
        });
        #endregion
        
        var outData = dbCollection.FindAll().ToList();
        return outData;
    }

    public void Update(User item)
    {
        //метод не используется
        throw new NotImplementedException();
    }
}
