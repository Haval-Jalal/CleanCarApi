using CleanCarApi.Application;
using CleanCarApi.Infrastructure;
using CleanCarApi.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Authentication måste komma FÖRE Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
