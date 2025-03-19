using TaskManager.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskManagerContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
