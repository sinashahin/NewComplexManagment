using Entities;
using NewComplexManagment.Services.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts
{
    public interface BlockRepository
    {
        int GetTotalUnitCountByComplexId(int complexId);
        int GetTotalUnitCountByComplexIdWithOutThisBlockId(int id, int complexId);
        void Add(Block block);
        bool BlockNameIsExist(string name);
        void Update(Block blook);
        Block? FindById(int id);
        bool IsDuplicateNameByComplexId(int id, string name, int complexId);
        List<GetAllBlockDto > GetAllBlocks();
        GetOneBlockDto GetOneBlock(int id);
        bool BlockIdIsExist(int Blockid);
        List<Block> GetBlockCount(int complexId);
        
    }
}
