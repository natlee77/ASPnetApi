using L3_AzureFunction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace L3_AzureFunction.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext( DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        //++tabel
        public DbSet<Product> Products { get; set; }


        public class SqlDbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
        {
            public SqlDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\46735\\Documents\\AzureFunction.mdf;Integrated Security=True;Connect Timeout=30");

                return new SqlDbContext(optionsBuilder.Options);
            }
        }
    }
}
