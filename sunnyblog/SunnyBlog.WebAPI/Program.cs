using Microsoft.EntityFrameworkCore;
using Nest;
using SunnyBlog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    var dbconfig = builder.Configuration.GetSection("Database");
    string connStr = dbconfig.GetSection("ConnStr").Value;
    string severVersion = dbconfig.GetSection("ServerVersion").Value;
    opt.UseMySql(connStr, new MySqlServerVersion(severVersion));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "dev_policy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});
ModuleInitializer.Initialize(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("dev_policy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
