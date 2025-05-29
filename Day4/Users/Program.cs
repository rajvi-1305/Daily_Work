
using Microsoft.EntityFrameworkCore;
using Users.DataAccess;
using Users.DataAccess.Repositories;
using Users.Services.Services;


namespace Users
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Add Context with ConnectionString
            builder.Services.AddDbContext<UserDbContext>(db =>db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Add repository and services in scoped
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRepository>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
