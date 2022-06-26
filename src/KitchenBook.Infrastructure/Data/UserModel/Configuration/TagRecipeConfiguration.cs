
using KitchenBook.Domain.RecipeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenBook.Infrastructure.Configuration
{
  public class TagRecipeConfiguration : IEntityTypeConfiguration<TagRecipe>
  {
    public void Configure( EntityTypeBuilder<TagRecipe> builder )
    {
      builder.HasKey( x => x.Id );

      builder.HasOne( tr => tr.Recipe )
        .WithMany( r => r.Tags )
        .HasForeignKey( tr => tr.RecipeId );

      builder.HasOne( tr => tr.Tag )
        .WithMany()
        .HasForeignKey( tr => tr.TagId );

    }
  }
}
