using FinanzasWeb.DB.Mapping;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.DB;

public class DbEntities: DbContext
{
    public virtual DbSet<Cuenta> Cuentas { get; set; }
    public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }
    public static List<Transaccion> Transacciones = new();
    
    public DbEntities() { }
    public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CuentaMapping());
        modelBuilder.ApplyConfiguration(new TipoCuentaMapping());
    }
    
   

}