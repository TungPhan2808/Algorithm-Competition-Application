using Equifinance.Mock.API.Middleware;
using Equifinance.Mock.API.ServiceConfig;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

//app.ConfigureBuiltInExceptionHandler();
app.ConfigureCustomExceptionHandler();

app.MapControllers();

app.Run();
