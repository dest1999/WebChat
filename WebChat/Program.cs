using Microsoft.EntityFrameworkCore;
using WebChat;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string connectionString = builder.Configuration.GetConnectionString("LiteDB");
//builder.Services.AddScoped<IRepository<User>> (usersDB => new UserDBRepository(connectionString));
//builder.Services.AddScoped<IRepository<UserMessage>>(messagesDB => new MessagesDBRepository(connectionString));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));
builder.Services.AddScoped<IRepository<User>, EFUserRepository>();
builder.Services.AddScoped<IRepository<UserMessage>, EFMessagesRepository>();



builder.Services.AddScoped<ChatCore>();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<MessageSpreader>("/messageSpreader");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
