using Entities;
using NewComplexManagment.Services.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Units.Contracts
{
    public interface UnitRepository
    {
        void Add(Unit unit);
        bool UnitNameIsExist(string name);
        List<GetAllUnitsDto> GetAllUnits();
    }
}
