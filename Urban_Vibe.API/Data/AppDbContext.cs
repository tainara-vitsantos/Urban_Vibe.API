using Urban_Vibe.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Urban_Vibe.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "11111111-1111-1111-1111-111111111111",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "22222222-2222-2222-2222-222222222222",
               Name = "Usuario",
               NormalizedName = "USUARIO"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário Administrador
        Usuario admin = new()
        {
            Id = "33333333-3333-3333-3333-333333333333",
            Email = "gallojunior@gmail.com",
            NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
            UserName = "GalloJunior",
            NormalizedUserName = "GALLOJUNIOR",
            EmailConfirmed = true,
            LockoutEnabled = true,
            Name = "José Antonio Gallo Junior",
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        PasswordHasher<Usuario> pass = new();
        admin.PasswordHash = pass.HashPassword(admin, "123456");
        builder.Entity<Usuario>().HasData(admin);
        #endregion

        #region Vincular usuário ao perfil Administrador
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                UserId = admin.Id,
                RoleId = roles[0].Id
            }
        );
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            // Exemplos:
            // new Categoria { Id = 1, Nome = "Camisetas" },
            // new Categoria { Id = 2, Nome = "Tênis" },
            // new Categoria { Id = 3, Nome = "Acessórios" }
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            // Exemplos:
            // new Produto { Id = 1, Nome = "Camiseta Street", CategoriaId = 1, Preco = 129.90M }
        };
        builder.Entity<Produto>().HasData(produtos);
    }
}
