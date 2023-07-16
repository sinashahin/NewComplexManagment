using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Blocks
{
    public class BlockEntityMap : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("Blocks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.UnitCount).IsRequired();
            builder.HasOne(_ => _.Complex)
                .WithMany(_ => _.Blocks)
                .HasForeignKey(_ => _.ComplexId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
