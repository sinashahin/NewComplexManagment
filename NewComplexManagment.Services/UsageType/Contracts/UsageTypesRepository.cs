using Entities;
using NewComplexManagment.Services.UsageType.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Contracts
{
    public interface UsageTypesRepository
    {
        void Add(Entities.UsageType usageType);
        bool UsageTypeNameIsExist(string name);
        bool UsageTypeIdIsExist(int id);
        List<GetAllUsageTypeDto> GetAllUsageTypes();
    }
}
