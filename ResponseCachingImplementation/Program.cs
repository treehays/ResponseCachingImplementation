using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//cahing f=for global use
builder.Services.AddControllers(
    options =>
    {
        //options.CacheProfiles.Add("Cache2Mins",
        //    new CacheProfile()
        //    {
        //        Duration = 120,
        //        Location = ResponseCacheLocation.Any
        //    });

        var cacheProfiles = builder.Configuration.GetSection("CacheProfiles").GetChildren();
        foreach (var cacheProfile in cacheProfiles)
        {
            options.CacheProfiles
            .Add(cacheProfile.Key,
            cacheProfile.Get<CacheProfile>());
        }
    });
builder.Services.AddResponseCaching();
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
app.UseResponseCaching();

app.Run();
