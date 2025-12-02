using Dogs.API.DataBase;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ConnectionDB>();
builder.Services.AddHttpClient<DogService>(client => client.BaseAddress = new Uri("https://localhost:7146/api/"));
builder.Services.AddScoped<DogService>();
builder.Services.AddScoped<DogRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
