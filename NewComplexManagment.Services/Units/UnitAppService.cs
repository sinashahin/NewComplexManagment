using Entities;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Blocks.Exceptions;
using NewComplexManagment.Services.Contracts;
using NewComplexManagment.Services.Units.Contracts;
using NewComplexManagment.Services.Units.Contracts.Dto;
using NewComplexManagment.Services.Units.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Units
{
    public class UnitAppService : UnitService
    {
        private readonly UnitRepository _unitRepository;
        private readonly BlockRepository _blockRepository;
        private readonly UnitOfWork _unitOfWork;

        public UnitAppService(UnitRepository unitRepository,
            BlockRepository blockRepository,
            UnitOfWork unitOfWork) 
        {
            _unitRepository = unitRepository;
            _blockRepository = blockRepository;
            _unitOfWork = unitOfWork;
        }

        public List<GetAllUnitsDto> GetAllUnits()
        {
            return _unitRepository.GetAllUnits();
        }

        void UnitService.Add(AddUnitDto dto)
        {
            var isExistBlockId=_blockRepository.BlockIdIsExist(dto.BlockId);
            if(!isExistBlockId) 
            {
                 throw new BlockIdNotFoundException();
            }
            var isExistName=_unitRepository.UnitNameIsExist(dto.Name); 
            if(isExistName) 
            {
                throw new DuplicateUnitNameException();
            }
            var unit = new Unit()
            {
                Name = dto.Name,
                ResidenceType = dto.ResidenceType,
                BlockId = dto.BlockId,
            };
            _unitRepository.Add(unit);
            _unitOfWork.Complete();

        }
    }
}
