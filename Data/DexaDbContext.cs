using System;
using System.Collections.Generic;
using System.Text;
using DexaApps.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DexaApps.Data
{
    public class DexaDbContext : IdentityDbContext<AppUser>
    {
        public DexaDbContext(DbContextOptions<DexaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        public virtual DbSet<Outlets> Outlets { get; set; }

    }
}
