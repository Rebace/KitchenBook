
using KitchenBook.Domain.RecipeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenBook.Infrastructure.Configuration
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure( EntityTypeBuilder<RecipeIngredient> builder )
        {
            builder.HasKey( x => x.Id );

            builder.HasOne( ingredient => ingredient.Recipe )
              .WithMany( recipe => recipe.RecipeIngredients )
              .HasForeignKey( ingredient => ingredient.RecipeId );
        }
    }
}
