using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAssignment.Models
{
    public class SBaccountContext : DbContext
    {
        public SBaccountContext(DbContextOptions<SBaccountContext> options) : base(options)
        { }
        public DbSet<SBaccount> Sbaccount { get; set; }
        
    }
}