using L4_3_WebApi_Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L4_3_WebApi_Identity.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(  DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
