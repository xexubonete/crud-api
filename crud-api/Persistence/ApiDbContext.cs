using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASP.NET_WebApi.Entities;
using System.Reflection;
using ASP.NET_WebApi.Interfaces;
namespace ASP.NET_WebApi.Persistence
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Client> Clients { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // It is not necessary when using MSSQL; the default schema is public.
            // builder.HasDefaultSchema("public");

            // EntityConfigurations mapping: Applies entity configurations from the current assembly. 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Call the base class method to ensure any by default and additional configuration is applied.
            base.OnModelCreating(builder);
        }
    }
}
