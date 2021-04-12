using IDLPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Persistencia
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Departamento> Departamento{ get; set; }
        public DbSet<Pais> Pais{ get; set; }
    }
}
