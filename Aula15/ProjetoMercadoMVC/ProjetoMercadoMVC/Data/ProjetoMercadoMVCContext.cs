using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMercadoMVC.Models;

namespace ProjetoMercadoMVC.Data
{
    public class ProjetoMercadoMVCContext : DbContext
    {
        public ProjetoMercadoMVCContext (DbContextOptions<ProjetoMercadoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoMercadoMVC.Models.Usuario> Usuario { get; set; }

        public DbSet<ProjetoMercadoMVC.Models.Produto> Produto { get; set; }

        public DbSet<ProjetoMercadoMVC.Models.Venda> Venda { get; set; }

        public DbSet<ProjetoMercadoMVC.Models.VendaItem> VendaItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var relationshitp in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationshitp.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        
    }
}
