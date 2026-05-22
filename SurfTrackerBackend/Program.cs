using SurfTrackerBackend.Data;
using SurfTrackerBackend.Middleware;
using Microsoft.EntityFrameworkCore;

// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AWS Cognito JWT Auth
// Configure AWS:Cognito:Region and AWS:Cognito:UserPoolId in appsettings.json before uncommenting.
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         var cognito = builder.Configuration.GetSection("AWS:Cognito");
//         var region = cognito["Region"];
//         var userPoolId = cognito["UserPoolId"];
//         options.Authority = $"https://cognito-idp.{region}.amazonaws.com/{userPoolId}";
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             ValidateAudience = false,
//         };
//     });
// builder.Services.AddAuthorization();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
