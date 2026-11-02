using BookStore.API.Data;
using BookStore.API.Features.Books;
using BookStore.API.Features.Genres;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("BookStore")
    ?? throw new InvalidOperationException("Connection string 'BookStore' was not found.");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidation();

builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(connectionString));


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

    await app.MigrateDbAsync();
}

app.UseHttpsRedirection();

BookStoreData data = new();

app.MapBooks();
app.MapGenres();
app.Run();


