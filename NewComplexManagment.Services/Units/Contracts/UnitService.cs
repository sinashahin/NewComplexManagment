using NewComplexManagment.Services.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Units.Contracts
{
    public interface UnitService
    {
        void Add(AddUnitDto dto);
        List<GetAllUnitsDto> GetAllUnits();
    }
}
