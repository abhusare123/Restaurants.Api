using Application.Extensions;
using Infrastructure.Extensions;
using Restaurants.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddScoped<ErrorHandlingMiddleWare>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleWare>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
