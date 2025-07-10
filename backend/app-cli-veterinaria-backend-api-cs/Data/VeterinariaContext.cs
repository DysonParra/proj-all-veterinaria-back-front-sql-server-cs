/*
 * @overview        {VeterinariaContext}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Veterinaria.Data {

    /**
     * TODO: Description of {@code VeterinariaContext}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class VeterinariaContext : DbContext {

        /**
         * TODO: Description of method {@code VeterinariaContext}.
         *
         */
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options) {
        }

        public DbSet<Project.Models.Chat> Chat { get; set; } = default!;

        public DbSet<Project.Models.ChatDetalle> ChatDetalle { get; set; }

        public DbSet<Project.Models.Foto> Foto { get; set; }

        public DbSet<Project.Models.Mascota> Mascota { get; set; }

        public DbSet<Project.Models.Persona> Persona { get; set; }
    }
}
