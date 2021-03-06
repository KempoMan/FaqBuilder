﻿using System.Data.Entity.ModelConfiguration;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class ControllerInputConfiguration : EntityTypeConfiguration<ControllerInput>
    {
        public ControllerInputConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Description)
                .HasMaxLength(2000);

            Property(t => t.Name)
                .HasMaxLength(255);

            HasRequired(t => t.Platform)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}