﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using FaqBuilder.Models;

namespace FaqBuilder.EntityConfigurations
{
    public class MoveTypeConfiguration : EntityTypeConfiguration<MoveType>
    {
        public MoveTypeConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name)
                .HasMaxLength(255);

            Property(t => t.Description)
                .HasMaxLength(2000);
        }
    }
}