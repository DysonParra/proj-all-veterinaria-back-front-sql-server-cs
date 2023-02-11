using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Veterinaria.Data
{
    public class VeterinariaContext : DbContext
    {
        public VeterinariaContext (DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Chat> Chat { get; set; } = default!;

        public DbSet<Project.Models.ChatDetalle> ChatDetalle { get; set; }

        public DbSet<Project.Models.Foto> Foto { get; set; }

        public DbSet<Project.Models.Mascota> Mascota { get; set; }

        public DbSet<Project.Models.Persona> Persona { get; set; }
    }
}
