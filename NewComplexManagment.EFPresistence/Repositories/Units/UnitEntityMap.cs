using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Units
{
    public class UnitEntityMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_=>_.ResidenceType).IsRequired();
            builder.Property(_ => _.BlockId).IsRequired();
            builder.HasOne(_=>_.Block)
                .WithMany(_=>_.Units).
                HasForeignKey(_ => _.BlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
