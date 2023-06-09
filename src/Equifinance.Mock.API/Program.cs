using Equifinance.Mock.API.Repository;
using Equifinance.Mock.API.Services;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Interfaces.IService;
using Equifinance.Mock.Infrastructure.Data;
using Equifinance.Mock.Infrastructure.Helper;
using Equifinance.Mock.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IProblemService, ProblemService>();
builder.Services.AddScoped<IProblemRepository, ProblemRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddMemoryCache();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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
app.MapControllers();

app.Run();
