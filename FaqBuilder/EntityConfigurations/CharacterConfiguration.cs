using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class CharacterConfiguration : EntityTypeConfiguration<Character>
    {
        public CharacterConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Description)
                .HasMaxLength(2000);

            Property(t => t.Name)
                .HasMaxLength(255);

            HasRequired(t => t.Game)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}