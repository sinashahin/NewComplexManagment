using NewComplexManagment.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Complexes.Contracts
{
    public interface ComplexService
    {
        void Add(AddComplexDto dto);
        List<GetAllComplexDto> GetAllComplexes(int? id,string? name);
        GetOneComplexDto GetOneComplex(int id);
        GetOneComplexWithBlockDto GetOneComplexWithBlock(int id,string? name);
        List<GetOneComplexUsageTypeDto> GetOneComplexUsageType(int id);
        void Update(int id, UpdateComplexUnitCountDto dto);
    }
}
