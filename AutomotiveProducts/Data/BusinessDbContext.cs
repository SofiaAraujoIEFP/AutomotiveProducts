﻿using AutomotiveProducts.Entities;
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
        DbSet<Products> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Provider=sqloledb;Data Source=SQL6033.site4now.net,1433;Initial Catalog=db_ab25e4_andreiaaraujoprog1;User Id=db_ab25e4_andreiaaraujoprog1_admin;Password=MyDataBase2025;");
        }
    }
}