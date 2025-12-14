using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanceNote.Models;

namespace FinanceNote.Data
{
    public class FinanceNoteContext : DbContext
    {
        public FinanceNoteContext (DbContextOptions<FinanceNoteContext> options)
            : base(options)
        {
        }

        public DbSet<FinanceNote.Models.Tayra> Tayra { get; set; } = default!;
        public DbSet<FinanceNote.Models.Macha> Macha { get; set; } = default!;
        public DbSet<FinanceNote.Models.Requests> Requests { get; set; } = default!;
        public DbSet<FinanceNote.Models.Who> Who { get; set; } = default!;
    }
}
