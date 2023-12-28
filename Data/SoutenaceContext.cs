using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionDesSoutenaces.Models;

namespace GestionDesSoutenaces.Data
{
    public class SoutenaceContext : DbContext
    {
        public SoutenaceContext (DbContextOptions<SoutenaceContext> options)
            : base(options)
        {
        }
        public DbSet<GestionDesSoutenaces.Models.ENSEIGNANT> ENSEIGNANT { get; set; } = default!;
        public DbSet<GestionDesSoutenaces.Models.ETUDIANT> ETUDIANT { get; set; } = default!;
        public DbSet<GestionDesSoutenaces.Models.PFE> PFE { get; set; } = default!;
        public DbSet<GestionDesSoutenaces.Models.PFE_ETUDIANT> PFE_ETUDIANT { get; set; } = default!;
        public DbSet<GestionDesSoutenaces.Models.SOCIETE> SOCIETE { get; set; } = default!;
  

       
    }
}
