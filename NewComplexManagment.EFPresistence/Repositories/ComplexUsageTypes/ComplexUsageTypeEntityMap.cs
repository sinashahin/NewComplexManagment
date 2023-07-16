using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewComplexManagment.Services.Complexes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.ComplexUsageTypes
{
    public class ComplexUsageTypeEntityMap : IEntityTypeConfiguration<ComplexUsageType>
    {
        public void Configure(EntityTypeBuilder<ComplexUsageType> builder)
        {
            builder.ToTable("ComplexUsageTypes");
            builder.HasKey(_ => new
            {
                _.UsageTypeId,
                _.ComplexId
            });
        }
    }
}
