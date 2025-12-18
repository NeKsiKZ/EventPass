using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}