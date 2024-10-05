using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
 b => b.MigrationsAssembly("MainApp")));



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

