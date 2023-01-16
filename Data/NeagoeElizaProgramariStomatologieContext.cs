using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeagoeElizaProgramariStomatologie.Models;

namespace NeagoeElizaProgramariStomatologie.Data
{
    public class NeagoeElizaProgramariStomatologieContext : DbContext
    {
        public NeagoeElizaProgramariStomatologieContext (DbContextOptions<NeagoeElizaProgramariStomatologieContext> options)
            : base(options)
        {
        }

        public DbSet<NeagoeElizaProgramariStomatologie.Models.Pacient> Pacient { get; set; } = default!;

        public DbSet<NeagoeElizaProgramariStomatologie.Models.Procedura> Procedura { get; set; } = default!;
    }
}
