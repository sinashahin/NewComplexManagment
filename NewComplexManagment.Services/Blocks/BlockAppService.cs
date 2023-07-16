using Entities;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Blocks.Contracts.Dto;
using NewComplexManagment.Services.Blocks.Exceptions;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.Complexes.Exceptions;
using NewComplexManagment.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks
{
    public class BlockAppService : BlockService
    {
        private readonly BlockRepository _repository;
        private readonly ComplexRepository _complexRepository;
        private readonly UnitOfWork _unitOfWork;

        public BlockAppService(BlockRepository repository,
            ComplexRepository complexRepository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _complexRepository = complexRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddBlockDto dto)
        {
            var isExistComplexId =_complexRepository.ComplexIdIsExist(dto.ComplexId);
            if (!isExistComplexId)
            {
                throw new ComplexIdNotFoundException();
            }
            var isExistBlockName = _repository.BlockNameIsExist(dto.Name);
            if (isExistBlockName)
            {
                throw new DuplicateBlockNameExcetion();
            }
            var totalBlockUnitCount = _repository
                     .GetTotalUnitCountByComplexId(dto.ComplexId);
            var complexUnitCount = _complexRepository
                .GetUnitCountById(dto.ComplexId);
            if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
            {
                throw new TotalBlockUnitCountException();
            }

            var block = new Block()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
                ComplexId = dto.ComplexId,
            };
            _repository.Add(block);
            _unitOfWork.Complete();
        }

        public List<GetAllBlockDto> GetAllBlocks()
        {
           return _repository.GetAllBlocks();
        }

        public GetOneBlockDto GetOneBlock(int id)
        {
            return _repository.GetOneBlock(id);
        }

        public void Update(int id, UpdateBlockDto dto)
        {
            var block = _repository.FindById(id);

            if (block == null)
            {
                throw new BlockIdNotFoundException();
            }

            var isDuplicateBlockName = _repository
                .IsDuplicateNameByComplexId(block.Id, dto.Name, block.ComplexId);
            if (isDuplicateBlockName)
            {
                throw new DuplicateBlockNameException();
            }

            var isExistUnit = _repository.BlockIdIsExist(block.Id);

            if (isExistUnit)
            {
                var totalBlockUnitCount = _repository
                    .GetTotalUnitCountByComplexIdWithOutThisBlockId(
                        block.Id,
                        block.ComplexId);
                var complexUnitCount = _complexRepository
                    .GetUnitCountById(block.ComplexId);
                if (totalBlockUnitCount + dto.UnitCount > complexUnitCount)
                {
                    throw new TotalBlockUnitCountException();
                }
                block.UnitCount = dto.UnitCount;
            }

            block.Name = dto.Name;

            _repository.Update(block);
            _unitOfWork.Complete();
        }
    }
}
