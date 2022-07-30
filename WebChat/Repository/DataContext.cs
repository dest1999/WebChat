using Microsoft.EntityFrameworkCore;

namespace WebChat;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<UserMessage> UserMessages { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }


}
