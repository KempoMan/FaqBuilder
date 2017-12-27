using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class InputMapConfiguration : EntityTypeConfiguration<InputMap>
    {
        public InputMapConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Input)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.ConvertedInput)
                .HasMaxLength(255)
                .IsRequired();

            HasRequired(t => t.Game)
                .WithMany(t => t.InputMaps)
                .WillCascadeOnDelete(false);
        }
    }
}