using Entities;
using Microsoft.EntityFrameworkCore;
using NewComplexManagment.Services.Units.Contracts;
using NewComplexManagment.Services.Units.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Units
{
    public class EFUnitRepository : UnitRepository
    {
        private readonly DbSet<Unit> _units;
        public EFUnitRepository(EFDataContext context) 
        {
            _units=context.Set<Unit>();
        }
        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public List<GetAllUnitsDto> GetAllUnits()
        {
            return 
                _units.Select(_=> new GetAllUnitsDto
                {
                    Id = _.Id,
                    Name = _.Name,
                }).ToList();
        }

        public bool UnitNameIsExist(string name)
        {
            return _units.Any(_ => _.Name == name);
        }
    }
}
