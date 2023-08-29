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

        public DbSet<alquilautos.Models.Vehiculos> Vehiculos { get; set; } = default!;

        public DbSet<alquilautos.Models.VehiculosDeportivos> VehiculosDeportivos { get; set; } = default!;

        public DbSet<alquilautos.Models.Usuarios> Usuarios { get; set; } = default!;

        public DbSet<alquilautos.Models.TipoDoc> TipoDoc { get; set; } = default!;
    }
}
