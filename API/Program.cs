using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Adding the service fot db
builder.Services.AddDbContext<DataContext>(opt =>
{
    // Connection string for the db from the app settings
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:4200", "https://localhost:4200");
});

// Configure the HTTP request pipeline.
// Do stuff for dev env
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middlewares
//app.UseHttpsRedirection();
//
//app.UseAuthorization();

app.MapControllers();

app.Run();
