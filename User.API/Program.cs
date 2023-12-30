using System.Net;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using NetTopologySuite.IO.Converters;
using User.Data.Extensions;
using User.UseCases.Extensions;

var builder = WebApplication.CreateBuilder(args);

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
IdentityModelEventSource.ShowPII = true;
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogic().AddData(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

var authority = "https://securetoken.google.com/" + builder.Configuration["FireBase:ProjectId"];

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.Authority = authority;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authority,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["FireBase:ProjectId"],
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => { options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();