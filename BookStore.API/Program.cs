using BookStore.API.Data;
using BookStore.API.Features.Books;
using BookStore.API.Features.Genres;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidation();

builder.Services.AddSingleton<BookStoreData>();
builder.Services.AddBooks();
builder.Services.AddGenres();

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

app.MapBooks();
app.MapGenres();
app.Run();


