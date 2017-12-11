using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Description)
                .HasMaxLength(2000);

            Property(t => t.Name)
                .HasMaxLength(255);

            Property(t => t.ShortName)
                .HasMaxLength(10);

            HasRequired(t => t.Platform)
                .WithMany(t => t.Games)
                .WillCascadeOnDelete(false);
        }
    }
}