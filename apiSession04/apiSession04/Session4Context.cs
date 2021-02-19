using apiSession04.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSession04
{
    public class Session4Context : DbContext
    {
        public Session4Context(DbContextOptions<Session4Context> options) : base(options)
        {

        }

        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Relatos> Relatos { get; set; }
    }
}
