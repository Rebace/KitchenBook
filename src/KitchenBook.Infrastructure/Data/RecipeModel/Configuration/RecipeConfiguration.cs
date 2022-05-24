using KitchenBook.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenBook.Infrastructure.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CookingTime).HasColumnType("byte");
            builder.Property(x => x.Portions).HasColumnType("byte");
            builder.Property(x => x.Stars).HasColumnType("byte");
            builder.Property(x => x.Likes).HasColumnType("byte");
        }
    }
}
