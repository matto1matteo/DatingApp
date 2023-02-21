using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Custom Extension methods for IServiceCollection
builder.Services.AddApplicationServices(builder.Configuration, builder.Environment);
builder.Services.AddIdentiteServices(builder.Configuration);

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:4200", "https://localhost:4200");
});

app.UseAuthentication();
app.UseAuthorization();

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
