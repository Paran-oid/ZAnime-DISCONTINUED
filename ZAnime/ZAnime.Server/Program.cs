using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using Zanime.Server.Data;
using Zanime.Server.Data.Services;
using Zanime.Server.Data.Services.Interfaces;
using Zanime.Server.Data.Services.Interfaces.Relationships;
using Zanime.Server.Data.Services.Relationships;
using Zanime.Server.Filters;
using Zanime.Server.Models.Core;
using Zanime.Server.Utilities.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //This is how to add filters to the program after creating them
    options.Filters.Add(new AppFilter());
});

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

//Need them to be able to fetch web api to react
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//We add authorization
//Then we add identityAPIEndpoints
//Then we map the api to our user model (ITS DOWN THERE IN app.MapIdentityApi)
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//APP SERVICES
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IGenreService, GenreService>();

// =====> APP SERVICES RELATIONSHIPS
builder.Services.AddScoped<IActorRelationshipsService, ActorRelationshipsService>();
builder.Services.AddScoped<IAnimeRelationshipsService, AnimeRelationshipsService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("AllowOrigin");
app.MapIdentityApi<User>();

//We created a minimal API which logs out the user and gets the email entered
app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization();

app.MapGet("/pingauth", (ClaimsPrincipal user) =>
{
    //Claims principal is meant to get the logged in user basically
    var email = user.FindFirstValue(ClaimTypes.Email);
    //We get the email of the current user this way
    return Results.Json(new { Email = email }); ;
    //We created a new json text that contains the email of the currently logged user
}).RequireAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();