using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Complexes
{
    public class ComplexEntityMap : IEntityTypeConfiguration<Complex>
    {
        public void Configure(EntityTypeBuilder<Complex> builder)
        {
            builder.ToTable("Complexes");
            builder.HasKey(_ => _.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.UnitCount).IsRequired();
        }
    }
}
