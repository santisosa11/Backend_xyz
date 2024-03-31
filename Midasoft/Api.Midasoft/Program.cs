
using Infrastructure.Midasoft.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            //Get Secret Key and convert byte
            builder.Configuration.AddJsonFile("appsettings.json");
            var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}