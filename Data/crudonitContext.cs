using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crudonit.Model;

namespace crudonit.Data
{
    public class crudonitContext : DbContext
    {
        public crudonitContext (DbContextOptions<crudonitContext> options)
            : base(options)
        {
        }

        public DbSet<crudonit.Model.Food> Food { get; set; } = default!;
    }
}
