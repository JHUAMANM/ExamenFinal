using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanzasWeb.DB.Mapping;

public class TransaccionMapping: IEntityTypeConfiguration<Transaccion>
{
    public void Configure(EntityTypeBuilder<Transaccion> builder)
    {
        builder.ToTable("Transaccion", "dbo");
        builder.HasKey(o => o.Id);
    }
}