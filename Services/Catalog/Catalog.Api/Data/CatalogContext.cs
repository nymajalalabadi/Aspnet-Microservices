using Catalog.Api.Entites;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var Client = new MongoClient(configuration.GetValue<string>("DataBaseSettings:ConnectionStrings"));
            var database = Client.GetDatabase(configuration.GetValue<string>("DataBaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DataBaseSettings:ColletionName"));
            CatalogContextSeed.SeedData(Products);
        }

    }
}
