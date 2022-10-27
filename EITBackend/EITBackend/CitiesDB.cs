﻿namespace EITBackend;

using EITBackend.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        options.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Cities> cities { get; set; }
}