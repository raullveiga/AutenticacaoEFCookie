using AutenticacaoEFCookie.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoEFCookie.Dados
{
    public class AutenticacaoContext : DbContext
    {
        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().ToTable("Permissoes");
            modelBuilder.Entity<Usuario>().ToTable("UsuarioPermissoes");

            base.OnModelCreating(modelBuilder);
        }
    }
}