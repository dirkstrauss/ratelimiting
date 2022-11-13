
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using RateLimitAPI.Services;

namespace RateLimitAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
                
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IGetTimeService, GetTimeService>();
        builder.Services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: "LimiterPolicy", options =>
            {
                options.PermitLimit = 1;
                options.Window = TimeSpan.FromSeconds(10); // Only allow 1 request every 10 seconds
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 3; // Only queue 3 requests when we go over that limit
            }));

        var app = builder.Build();
        app.UseRateLimiter();

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

