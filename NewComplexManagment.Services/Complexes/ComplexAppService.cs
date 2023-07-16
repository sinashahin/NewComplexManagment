using Entities;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.Complexes.Contracts.Dto;
using NewComplexManagment.Services.Complexes.Exceptions;
using NewComplexManagment.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Complex = Entities.Complex;

namespace NewComplexManagment.Services.Complexes
{
    public class ComplexAppService : ComplexService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly BlockRepository _blockRepository;
        private readonly ComplexRepository _repository;

        public ComplexAppService(ComplexRepository repository,
            UnitOfWork unitOfWork,BlockRepository blockRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _blockRepository = blockRepository;
        }
        public void Add(AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };
            _repository.Add(complex);
            _unitOfWork.Complete();
        }

        public List<GetAllComplexDto> GetAllComplexes(int? id, string name)
        {
            return _repository.GetAllComplexDto(id, name);
        }

        public GetOneComplexDto GetOneComplex(int id)
        {
            return _repository.GetOne(id);
        }

        public List<GetOneComplexUsageTypeDto> GetOneComplexUsageType(int id)
        {
            return _repository.GetOneComplexUsageType(id);
        }

        public GetOneComplexWithBlockDto GetOneComplexWithBlock(int id, string? name)
        {
            return _repository.GetOneComplexWithBlockDto(id, name);
        }

        public void Update(int id, UpdateComplexUnitCountDto dto)
        {
            var complex=_repository.FindById(id);
            var isExistComplexId=_repository.ComplexIdIsExist(id);
            if (!isExistComplexId)
            {
                throw new ComplexIdNotFoundException();
            }
            var complexHasUnit=_repository.ComplexHasUnit(id);
            if (!complexHasUnit)
            {
                throw new Exception("Cant");
            }
            
            complex.UnitCount=dto.UnitCount;
            var block=_blockRepository.GetBlockCount(id);
            foreach ( var item in block)
            {
                item.UnitCount = 0;
                _blockRepository.Update(item);
            }
            
            
            

            _repository.Update(complex);
            
            _unitOfWork.Complete();
        }
    }
}
