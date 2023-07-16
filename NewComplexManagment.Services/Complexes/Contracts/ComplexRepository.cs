using Entities;
using NewComplexManagment.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Complex = Entities.Complex;

namespace NewComplexManagment.Services.Complexes.Contracts
{
    public interface ComplexRepository
    {
        void Add(Complex complex);
        List<GetAllComplexDto> GetAllComplexDto(int? id,string? name);
        GetOneComplexDto GetOne(int id);
        GetOneComplexWithBlockDto GetOneComplexWithBlockDto(int id,string? name);
        bool ComplexIdIsExist(int id);
        int GetUnitCountById(int id);
        List<GetOneComplexUsageTypeDto> GetOneComplexUsageType(int id);
        void Update(Complex complex);
        bool ComplexHasUnit(int id);
        Complex? FindById(int id);
    }
}
