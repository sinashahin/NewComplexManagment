using Entities;
using Microsoft.EntityFrameworkCore;
using NewComplexManagment.Services.ComplexUsageType.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.ComplexUsageTypes
{
    public class EFComplexUsageTypeRepository : ComplexUsageTypeRepository
    {
        private readonly DbSet<ComplexUsageType> _complexUsageTypes;
        public EFComplexUsageTypeRepository(EFDataContext context)
        {
            _complexUsageTypes=context.Set<ComplexUsageType>();
        }
        public void Add(ComplexUsageType complexUsageType)
        {
            _complexUsageTypes.Add(complexUsageType);
        }
    }
}
