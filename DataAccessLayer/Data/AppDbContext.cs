using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
                
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Identification> Identification { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
    }
}
