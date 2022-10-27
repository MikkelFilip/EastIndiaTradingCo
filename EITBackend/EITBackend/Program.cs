using EITBackend.Common.Adapters;
using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Services;
using EITBackend.Common.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConnectedCitiesService, ConnectedCitiesService>();
builder.Services.AddScoped<IConnectedCitiesSegmentAdapter, ConnectedCitiesSegmentAdapter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
