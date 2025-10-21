using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<GerenteModel>
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {
    }

    public DbSet<ClienteModel> Clientes { get; set; }
}
