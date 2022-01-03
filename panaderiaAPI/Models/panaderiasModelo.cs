using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace panaderiaAPI.Models
{
    public partial class panaderiasModelo : DbContext
    {
        public panaderiasModelo()
            : base("name=panaderiaAPI")
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Pans> Pans { get; set; }
        public virtual DbSet<Pastels> Pastels { get; set; }
        public virtual DbSet<Sucursals> Sucursals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
