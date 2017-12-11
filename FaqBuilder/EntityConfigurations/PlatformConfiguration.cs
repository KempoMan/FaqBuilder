using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class PlatformConfiguration : EntityTypeConfiguration<Platform>
    {
        public PlatformConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Description)
                .HasMaxLength(2000);

            Property(t => t.Name)
                .HasMaxLength(255);

            Property(t => t.ShortName)
                .HasMaxLength(10);
        }
    }
}