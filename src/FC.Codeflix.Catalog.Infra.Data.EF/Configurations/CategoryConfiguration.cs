using FC.Codeflix.Catalog.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.Infra.Data.EF.Configurations;
internal class CategoryConfiguration
    : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);
        builder.Property(category => category.Name)
            .HasMaxLength(255);
        builder.Property(category => category.Description)
            .HasMaxLength(10_000);
        builder.Ignore(category => category.Events);
    }
}