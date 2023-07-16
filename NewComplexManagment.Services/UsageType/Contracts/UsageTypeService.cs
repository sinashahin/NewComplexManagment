using NewComplexManagment.Services.Units.Contracts.Dto;
using NewComplexManagment.Services.UsageType.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.UsageType.Contracts
{
    public interface UsageTypeService
    {
        void Add(AddUsageTypeDto dto);
        List<GetAllUsageTypeDto> GetAllUsageType();
    }
}
