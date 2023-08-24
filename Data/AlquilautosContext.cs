using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using alquilautos.Models;

namespace alquilautos.Data
{
    public class AlquilautosContext : DbContext
    {
        public AlquilautosContext (DbContextOptions<AlquilautosContext> options)
            : base(options)
        {
        }

        public DbSet<alquilautos.Models.Alquiler> Alquiler { get; set; } = default!;
    }
}