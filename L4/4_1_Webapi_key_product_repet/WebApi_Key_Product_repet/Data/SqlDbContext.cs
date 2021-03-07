using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace WebApi_Key_Product_repet.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(  DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
