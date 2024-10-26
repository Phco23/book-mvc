﻿using book_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace book_mvc.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}