﻿using ASP.NET_WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_WebApi.Interfaces
{
    public interface IApiDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public Task<int> SaveChangesAsync();
    }
}
