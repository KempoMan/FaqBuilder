using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class MoveConfiguration : EntityTypeConfiguration<Move>
    {
        public MoveConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .HasMaxLength(100);

            Property(t => t.Motion)
                .HasMaxLength(250);

            HasRequired(t => t.MoveType);
        }
    }
}