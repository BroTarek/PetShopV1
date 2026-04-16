using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PetShop.BackendV2.Application;
using PetShop.BackendV2.Infrastructure;
using PetShop.BackendV2.Infrastructure.Data;
using PetShop.BackendV2.API.Services;
using PetShop.BackendV2.Application.Interfaces.Services;
using PetShop.BackendV2.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add this with other service registrations
builder.Services.AddSignalR();
// Add Application and Infrastructure services
builder.Services.AddApplicationCore();
builder.Services.AddInfrastructureCore();
builder.Services.AddScoped<IAdoptionNotificationService, AdoptionNotificationService>();
builder.Services.AddAuthorization();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "super_secret_key_1234567890_min32chars!"))
        };

        // Handle SignalR authentication where tokens are sent in the query string
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

// CORS
// NOTE: AllowCredentials() is required for SignalR auth (JWT via accessTokenFactory).
// AllowAnyOrigin() is incompatible with AllowCredentials(), so we specify origins explicitly.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.WithOrigins(
                "http://localhost:3000",  // Next.js dev server
                "https://localhost:3000"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()); // Required for SignalR with Authorization header
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the OAuth2.0 / Bearer scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Make Swagger use the defined scheme globally
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Auto-migrate or ensure database is created on startup (solves local no-dotnet issue and Docker orchestration)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var dbContext = services.GetRequiredService<AppDbContext>();
    
    int maxRetries = 5;
    int retryCount = 0;
    bool success = false;

    while (retryCount < maxRetries && !success)
    {
        try
        {
            dbContext.Database.EnsureCreated();
            success = true;
        }
        catch (Exception ex)
        {
            retryCount++;
            logger.LogWarning($"Database initialization attempt {retryCount} failed. Error: {ex.Message}. Retrying in 5 seconds...");
            if (retryCount >= maxRetries)
            {
                logger.LogError(ex, "Database initialization failed after multiple attempts.");
                throw;
            }
            Thread.Sleep(5000);
        }
    }
    
    // Auto-seed default Super Admin
    if (success)
    {
        var adminEmail = "metarek257@gmail.com";
        if (!dbContext.Users.Any(u => u.Email == adminEmail))
        {
            var adminUser = new PetShop.BackendV2.Domain.Entities.User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Tarek",
                LastName = "Dibba",
                Email = adminEmail,
                Password = BCrypt.Net.BCrypt.HashPassword("oneiron9075"),
                Role = PetShop.BackendV2.Domain.Enums.Role.Admin,
                AccountStatus = PetShop.BackendV2.Domain.Enums.AccountStatus.Approved,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            dbContext.Users.Add(adminUser);
            dbContext.SaveChanges();
            Console.WriteLine("Successfully seeded initial Admin user.");
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Disabled because inside Docker, SSL termination is handled by proxy
app.UseCors("AllowAll");

// Authentication/Authorization MUST come before endpoint mapping so that
// [Authorize] on AdoptionHub is enforced when clients first connect.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<AdoptionHub>("/hubs/adoption");

app.Run();
