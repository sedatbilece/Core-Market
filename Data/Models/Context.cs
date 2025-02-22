﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
    public class Context: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VLDSRET;database=CoreFood; integrated security=true");
        }


        public DbSet<Category> categories { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Admin> Admins{ get; set; }
    }
}
