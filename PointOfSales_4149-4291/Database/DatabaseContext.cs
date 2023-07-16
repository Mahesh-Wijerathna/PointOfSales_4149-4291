using Microsoft.EntityFrameworkCore;
using PointOfSales_4149_4291.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales_4149_4291.Database
{

    public class DatabaseContext : DbContext
    {
        public DbSet<User> UserAndAdmins_list { get; set; }
        public DbSet<Customer> Customers_table { get; set; }
        public DbSet<Item> Items_table { get; set; }
        // Property for the data table for person
        private readonly string _path = @"C:\Users\Mahesh_Wijerathna\Desktop\PointOfSales_4149-4291\data_base";

        //passing the db to the data context
        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={_path}");
    }
}

