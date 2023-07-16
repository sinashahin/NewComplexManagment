using Entities;
using NewComplexManagment.Services.Contracts;
using NewComplexManagment.Services.Units.Contracts.Dto;
using NewComplexManagment.Services.UsageType.Contracts;
using NewComplexManagment.Services.UsageType.Contracts.Dto;
using NewComplexManagment.Services.UsageType.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.UsageType
{
    public class UsageTypeAppService : UsageTypeService
    {
        private readonly UsageTypesRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public UsageTypeAppService(UsageTypesRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddUsageTypeDto dto)
        {
            var isExistName = _repository.UsageTypeNameIsExist(dto.Name);
            if (isExistName)
            {
                throw new DuplicateUsageTypeNameException();
            }
            var usageType = new Entities.UsageType()
            {
                Name = dto.Name,
            };
            _repository.Add(usageType);
            _unitOfWork.Complete();
            
        }

        public List<GetAllUsageTypeDto> GetAllUsageType()
        {
            return _repository.GetAllUsageTypes();
        }
    }
}
