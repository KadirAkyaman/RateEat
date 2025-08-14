using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RateEat.Infrastructure.Data;
using RateEat.Infrastructure.Settings;
var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.SectionName));

builder.Services.AddDbContext<RateEatDbContext>((serviceProvider, options) =>
{
    var databaseSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    options.UseNpgsql(databaseSettings.DefaultConnection); 
});

var app = builder.Build();

app.Run();