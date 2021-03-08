using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PeopleDb : DbContext
    {
        public PeopleDb(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Models.Person> People { get; set; }
    }
}
