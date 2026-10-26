using BookStore.API.Data;
using BookStore.API.Features.Books;
using BookStore.API.Features.Genres;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "BookStore API v1");
    });
}

app.UseHttpsRedirection();

BookStoreData data = new();

app.MapBooks(data);
app.MapGenres(data);
app.Run();


