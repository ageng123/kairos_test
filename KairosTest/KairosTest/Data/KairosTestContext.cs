using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KairosTest.Models;

namespace KairosTest.Data
{
    public class KairosTestContext : DbContext
    {
        public KairosTestContext (DbContextOptions<KairosTestContext> options)
            : base(options)
        {
        }

        public DbSet<KairosTest.Models.T_BARANG> T_BARANG { get; set; } = default!;

        public virtual DbSet<KairosTest.Models.crudBarang> crudBarang { get; set; }
    }
}
