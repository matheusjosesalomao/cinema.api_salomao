using Cinema.Usuario.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Usuario.Api.Data
{
    public class UsuarioDbContext : IdentityDbContext<User>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Usuarios");
        }
    }
}
