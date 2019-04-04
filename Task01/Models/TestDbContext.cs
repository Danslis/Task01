using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task01.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        { }
    }
}
