using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Globalization;
using JapaneseLearning.Interfaces;
using JapaneseLearning.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var app = BuildApp(args);
        ConfigureApp(app);
        app.Run();
    }

    private static WebApplication BuildApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database connection string from environment variables
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
    ?? throw new InvalidOperationException("Connection string not found in environment variables.");


        // Add services, Use the connection string for your DbContext

        builder.Services.AddDbContext<LearningAppContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<IVocabService, VocabService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Learning App API", Version = "v1" });
        });

        return builder.Build();
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
