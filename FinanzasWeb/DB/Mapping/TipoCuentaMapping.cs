using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanzasWeb.DB.Mapping;

public class TipoCuentaMapping: IEntityTypeConfiguration<TipoCuenta>
{
    public void Configure(EntityTypeBuilder<TipoCuenta> builder)
    {
        builder.ToTable("TipoCuenta", "dbo");
        builder.HasKey(o => o.Id);
    }
}