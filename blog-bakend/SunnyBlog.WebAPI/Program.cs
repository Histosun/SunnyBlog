using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SunnyBlog.Domain.Entities;
using SunnyBlog.Infrastructure;
using SunnyCommons.Auth.Authentication;
using SunnyCommons.Auth.Token;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDbContext>(options =>
{
    var dbconfig = builder.Configuration.GetSection("Database");
    string connStr = dbconfig.GetSection("ConnStr").Value;
    string severVersion = dbconfig.GetSection("ServerVersion").Value;
    options.UseMySql(connStr, new MySqlServerVersion(severVersion));
});
builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;

    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});
builder.Services.AddDataProtection();
var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), builder.Services);
idBuilder.AddEntityFrameworkStores<BlogDbContext>()
        .AddDefaultTokenProviders()
        .AddRoleManager<RoleManager<Role>>()
        .AddUserManager<UserManager<User>>();
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
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options => options.DefaultScheme = JwtAuthenticationDefault.AuthenticationScheme)
                .AddScheme<JwtAuthenticaionOptions, JwtAuthenticationHandler>(JwtAuthenticationDefault.AuthenticationScheme, options => {
                    JWTOptions jwtOpt = builder.Configuration.GetSection("JWT").Get<JWTOptions>();
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtOpt.Issuer,
                        ValidAudience = jwtOpt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt.Key))
                    };
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
