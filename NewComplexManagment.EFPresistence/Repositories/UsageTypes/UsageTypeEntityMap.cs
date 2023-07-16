﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.UsageTypes
{
    public class UsageTypeEntityMap : IEntityTypeConfiguration<UsageType>
    {
        public void Configure(EntityTypeBuilder<UsageType> builder)
        {
            builder.ToTable("UsageTypes");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_=> _.Name).HasMaxLength(50).IsRequired();
        }
    }
}
