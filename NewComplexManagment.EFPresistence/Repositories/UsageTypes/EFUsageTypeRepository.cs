using Entities;
using Microsoft.EntityFrameworkCore;
using NewComplexManagment.Services.Contracts;
using NewComplexManagment.Services.UsageType.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.UsageTypes
{
    public class EFUsageTypeRepository : UsageTypesRepository
    {
        private readonly DbSet<UsageType> _usageTypes;
        public EFUsageTypeRepository(EFDataContext context) 
        {
            _usageTypes=context.Set<UsageType>();
        }
        public void Add(UsageType usageType)
        {
            _usageTypes.Add(usageType);
        }

        public List<GetAllUsageTypeDto> GetAllUsageTypes()
        {
            return _usageTypes.Select(x => new GetAllUsageTypeDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public bool UsageTypeIdIsExist(int id )
        {
            return _usageTypes.Any(_ => _.Id == id);
        }

        public bool UsageTypeNameIsExist(string name)
        {
            return _usageTypes.Any(_ => _.Name == name);
        }
    }
}
