using AutomotiveProducts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveProducts.Data
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Products> Product { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL6033.site4now.net,1433;Initial Catalog=db_ab25e4_andreiaaraujoprog1;User Id=db_ab25e4_andreiaaraujoprog1_admin;Password=MyDataBase2025;");
        }
    }
}