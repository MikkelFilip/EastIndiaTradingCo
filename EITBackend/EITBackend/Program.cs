
using EITBackend.Common.Adapters;
using EITBackend.Common.Adapters.IAdapters;
using EITBackend.Common.Services;
using EITBackend.Common.Services.IServices;

using EITBackend;
using EITBackend.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IConnectedCitiesService, ConnectedCitiesService>();
        builder.Services.AddScoped<IConnectedCitiesSegmentAdapter, ConnectedCitiesSegmentAdapter>();
        // DB Connection
        builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.ConnectionStrings));
        var connectionStringOptions = new ConnectionStringOptions();
        builder.Configuration.GetSection(ConnectionStringOptions.ConnectionStrings).Bind(connectionStringOptions);

        var connectionString = connectionStringOptions.ServiceDatabase;



        builder.Services.AddDbContext<DataContext>(
        dbContextOptions => dbContextOptions
            .UseSqlServer("Data Source=dbs-eit-dk1.database.windows.net; Initial Catalog=db-eit-dk1; User Id=admin-eit-dk1​; Password=Eastindia4thewin​"));

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

        
    }
}