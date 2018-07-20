using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace test_webap_bd.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
       
    }
}