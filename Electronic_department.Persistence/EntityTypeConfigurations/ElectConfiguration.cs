using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Electronic_department.Domain;

namespace Electronic_department.Persistence.EntityTypeConfigurations
{
    public class ElectConfiguration : IEntityTypeConfiguration<Elect>
    {
        public void Configure(EntityTypeBuilder<Elect> builder)
        {
            builder.HasKey(elect => elect.Id);
            builder.HasIndex(elect => elect.Id).IsUnique();
            builder.Property(elect => elect.Title).HasMaxLength(25);
        }
    }
}
