
using Infrastructure.Midasoft.Data;

namespace Api.Midasoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Add Cors
            builder.Services.AddCors();

            //Call to repositories
            builder.Services.AddScoped<GrupoFamiliarRespository>();

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

            //Configure Cors
            app.UseCors(options =>
            {
                options.WithOrigins("http://192.168.3.230").AllowAnyMethod();
                options.WithOrigins("http://192.168.3.205").AllowAnyMethod();
                options.WithOrigins("http://192.168.3.205:81").AllowAnyMethod();
                options.WithOrigins("http://192.168.10.55:3001").AllowAnyMethod();
                options.WithOrigins("http://192.168.3.230:3000").AllowAnyMethod();
                options.WithOrigins("http://192.168.3.230:3001").AllowAnyMethod();
                options.WithOrigins("http://192.168.3.230:3002").AllowAnyMethod();
                options.WithOrigins("http://190.146.168.21:3000").AllowAnyMethod();
                options.WithOrigins("http://190.146.168.21:3001").AllowAnyMethod();
                options.WithOrigins("http://190.146.168.21:3002").AllowAnyMethod();
                options.WithOrigins("http://localhost:3000").AllowAnyMethod();
                options.WithOrigins("http://localhost:3001").AllowAnyMethod();
                options.WithOrigins("http://localhost:3002").AllowAnyMethod();
                options.WithOrigins("https://localhost:44305").AllowAnyMethod();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}