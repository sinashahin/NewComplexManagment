using NewComplexManagment.Services.ComplexUsageType.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.ComplexUsageType.Contracts
{
    public interface ComplexUsageTypeService
    {
        void Add(AddComplexUsageTypeDto dto);
    }
}
