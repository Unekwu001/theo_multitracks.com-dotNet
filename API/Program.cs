using System.Configuration;
using System.Text.Json.Serialization;
using API.Repositories.Song;
using API.Repositories.Artist.SearchArtist;
using API.Repositories.Artist.AddArtist;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//Services
builder.Services.AddScoped<ISearchArtistRepository, SearchArtistRepository>(provider => new SearchArtistRepository(connectionString));
builder.Services.AddScoped<ISongsRepository, SongsRepository>(provider => new SongsRepository(connectionString));
builder.Services.AddScoped<IAddArtistRepository, AddArtistRepository>(provider => new AddArtistRepository(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
