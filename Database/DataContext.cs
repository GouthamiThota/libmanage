
using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LibraryManagementDatabase.Entities;

namespace Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

      
    }
}
