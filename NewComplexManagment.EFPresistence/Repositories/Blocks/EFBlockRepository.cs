using Entities;
using Microsoft.EntityFrameworkCore;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Blocks
{
    public class EFBlockRepository : BlockRepository
    {
        private readonly DbSet<Block> _blocks;
        public EFBlockRepository(EFDataContext context) 
        {
            _blocks =context.Set<Block>();
        }
        public void Add(Block block)
        {
            _blocks.Add(block);
        }

        public bool BlockIdIsExist(int Blockid)
        {
            return _blocks.Any(_=>_.Id == Blockid);
        }

        public bool BlockNameIsExist(string name)
        {
            return _blocks.Any(_ => _.Name == name);
        }

        public Block? FindById(int id)
        {
            return _blocks.FirstOrDefault(_ => _.Id == id);
        }

        public List<GetAllBlockDto> GetAllBlocks()
        {
            return _blocks.Select(_=>new GetAllBlockDto
            {
                Name=_.Name,
                UnitCount=_.UnitCount,
                SubmitUnitCount=_.Units.Count(),
                RemainUnitCount=_.UnitCount - _.Units.Count(),
            }).ToList();
        }

        public List<Block> GetBlockCount(int complexId)
        {
            return _blocks.Where(_ => _.ComplexId == complexId).ToList();
        }

        public GetOneBlockDto? GetOneBlock(int id)
        {
            return _blocks.Where(_=>_.Id==id)
                .Select(_ => new GetOneBlockDto
            {
                Name = _.Name,
                GetUnitOfBlocks = _.Units.Select(_ => new GetUnitOfBlock
                {
                    Name = _.Name,
                    ResidenceType = _.ResidenceType,
                }).ToList()
            }).FirstOrDefault();
        }

        public int GetTotalUnitCountByComplexId(int complexId)
        {
            return _blocks
                .Where(_ => _.ComplexId == complexId)
                .Select(_ => _.UnitCount)
                .Sum();
        }

        public int GetTotalUnitCountByComplexIdWithOutThisBlockId(int id, int complexId)
        {
            return _blocks.Where(_ =>
               _.ComplexId == complexId &&
               _.Id != id)
              .Select(_ => _.UnitCount)
              .Sum();
        }

        public bool IsDuplicateNameByComplexId(int id, string name, int complexId)
        {
            return _blocks.Any(_ => _.Name == name &&
              _.ComplexId == complexId &&
              _.Id != id);
        }

        public void Update(Block block)
        {
            _blocks.Update(block);
        }
    }
}
