namespace WebChat;

public interface IUserRepository<T> where T : User
{
    void Create(T item);
    void Update(T item);
    T Get(int id);
    IEnumerable<T> GetAll();
    void Delete(int id);
}
