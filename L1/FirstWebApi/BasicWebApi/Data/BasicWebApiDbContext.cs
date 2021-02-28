using BasicWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApi.Data
{
    public class BasicWebApiDbContext : DbContext
    {
        public BasicWebApiDbContext( DbContextOptions<BasicWebApiDbContext > options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
