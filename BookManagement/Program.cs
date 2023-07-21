using BookManagement.Business;
using BookManagement.Model.Interfaces;
using BookManagement.Repository;
using BookManagement.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injection
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookBusiness, BookBusiness>();
builder.Services.AddTransient<ICoverRepository, CoverRepository>();
builder.Services.AddTransient<ICoverBusiness, CoverBusiness>();


builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;"));

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

app.Run();
