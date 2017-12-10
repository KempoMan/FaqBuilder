using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class ControllerInputConfiguration : EntityTypeConfiguration<ControllerInput>
    {
        public ControllerInputConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .HasMaxLength(255);
        }
    }
}