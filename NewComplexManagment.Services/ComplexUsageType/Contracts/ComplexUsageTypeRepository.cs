using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.ComplexUsageType.Contracts
{
    public interface ComplexUsageTypeRepository
    {
        void Add(Entities.ComplexUsageType complexUsageType);
    }
}
