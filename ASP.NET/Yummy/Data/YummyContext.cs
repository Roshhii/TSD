using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yummy.Models;

    public class YummyContext : DbContext
    {
        public YummyContext (DbContextOptions<YummyContext> options)
            : base(options)
        {
        }

        public DbSet<Yummy.Models.Recipes> Recipes { get; set; }
    }
