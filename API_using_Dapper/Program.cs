using API_with_EntityFramework.Core.Implementation;
using API_with_EntityFramework.Core.Service;

var builder = WebApplication.CreateBuilder(args);


//connection
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//Services
builder.Services.AddScoped<ArtistServices, ArtistImplementation>(provider => new ArtistImplementation(connectionString));
builder.Services.AddScoped<SongServices, SongImplementation>(provider => new SongImplementation(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
