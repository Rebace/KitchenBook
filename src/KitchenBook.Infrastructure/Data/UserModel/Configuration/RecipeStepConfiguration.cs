using KitchenBook.Domain.RecipeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenBook.Infrastructure.Configuration
{
    public class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
    {
        public void Configure( EntityTypeBuilder<RecipeStep> builder )
        {
            builder.HasKey( x => x.Id );

            builder.HasOne( p => p.Recipe )
              .WithMany( b => b.RecipeSteps )
              .HasForeignKey( p => p.RecipeId );
        }
    }
}
