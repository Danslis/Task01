using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task01.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<Users1> Users { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        { }
    }
}
