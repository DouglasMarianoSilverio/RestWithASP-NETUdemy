using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected MySQLContext()
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
