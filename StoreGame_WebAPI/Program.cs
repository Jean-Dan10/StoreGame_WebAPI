using Microsoft.EntityFrameworkCore;
using StoreGame_WebAPI.Data;
using StoreGame_WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Pour configurer le gameContext et la connexion à localDB
builder.Services.AddDbContext<GameContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GameContext")));


// pour injection de dépendance du service
builder.Services.AddScoped<GameReviewService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
