using Entities;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.Complexes.Exceptions;
using NewComplexManagment.Services.ComplexUsageType.Contracts;
using NewComplexManagment.Services.ComplexUsageType.Contracts.Dto;
using NewComplexManagment.Services.Contracts;
using NewComplexManagment.Services.UsageType.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.ComplexUsageType
{
    public class ComplexUsageTypeAppService : ComplexUsageTypeService
    {
        private readonly ComplexUsageTypeRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        private readonly ComplexRepository _complexRepository;
        private readonly UsageTypesRepository _usageTypesRepository;

        public ComplexUsageTypeAppService(ComplexUsageTypeRepository repository,
            UnitOfWork unitOfWork,
            ComplexRepository complexRepository,
            UsageTypesRepository usageTypesRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _complexRepository = complexRepository;
            _usageTypesRepository = usageTypesRepository;
        }
        public void Add(AddComplexUsageTypeDto dto)
        {
            var isExistComplexId=_complexRepository.ComplexIdIsExist(dto.ComplexId);
            if (!isExistComplexId)
            {
                throw new ComplexIdNotFoundException();
            }
            var isExistUsageTypeId=_usageTypesRepository.UsageTypeIdIsExist(dto.UsageTypeId);
            if (!isExistUsageTypeId)
            {
                throw new UsageTypeIdNotFoundException();
            }
            var complexUsageType = new Entities.ComplexUsageType
            {
                ComplexId = dto.ComplexId,
                UsageTypeId = dto.UsageTypeId,
            };
            _repository.Add(complexUsageType);
            _unitOfWork.Complete();

        }
    }
}
