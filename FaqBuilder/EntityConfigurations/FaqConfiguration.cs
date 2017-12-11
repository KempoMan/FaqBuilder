using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class FaqConfiguration: EntityTypeConfiguration<Faq>
    {
        public FaqConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Description)
                .HasMaxLength(2000);

            //HasRequired(t => t.Game)
            //    .WithOptional(t => t.Faq)
            //    .WillCascadeOnDelete(false);

            //HasRequired(t => t.Game)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);
        }
    }
}