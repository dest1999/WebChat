namespace WebChat;

public interface IRepository<T> 
{
    int Create(T item);
    void Update(T item);
    T Get(int id);
    IEnumerable<T> GetAll();
    void Delete(int id);
}
