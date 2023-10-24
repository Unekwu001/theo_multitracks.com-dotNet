using API_with_EntityFramework.Core.Implementation;
using API_with_EntityFramework.Core.Service;
using API_with_EntityFramework.Data.MyMultitrackDbContext;
using Microsoft.EntityFrameworkCore;

namespace API_with_EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
 
            //Services
            builder.Services.AddScoped<ArtistServices, ArtistImplementation>();
            builder.Services.AddScoped<SongServices, SongImplementation>();

            builder.Services.AddDbContext<MultitrackDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });



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
        }
    }
}