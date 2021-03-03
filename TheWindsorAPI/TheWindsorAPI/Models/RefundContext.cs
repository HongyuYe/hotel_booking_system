using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheWindsorAPI.Models
{
    public class RefundContext : DbContext
    {
        public RefundContext(DbContextOptions<RefundContext> options)
            : base(options)
        {
        }

        public DbSet<Refund> Refunds { get; set; }
    }
}
