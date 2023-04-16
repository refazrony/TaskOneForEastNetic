using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskOne.Shared;

namespace TaskOne.Server
{
    public class AppDbContext : DbContext
    {
       
        public DbSet<Orders> Orders { get; set; }
        public DbSet<windows> windows { get; set; }
        public DbSet<SubElement> SubElement { get; set; }     

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
