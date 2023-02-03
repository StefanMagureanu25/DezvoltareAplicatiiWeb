using IMDB.Data;
using Microsoft.EntityFrameworkCore;
using IMDB.Helpers;
using IMDB.Helpers.Middleware;
using IMDB.Repositories.UserRepository;
using IMDB.Services.UserService;
using IMDB.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<IMDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSetings>(builder.Configuration.GetSection("AppSetings"));
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddUtils();


var app = builder.Build();

// I'll run Swagger here
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
