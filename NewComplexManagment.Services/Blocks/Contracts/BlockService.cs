using Entities;
using NewComplexManagment.Services.Blocks.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts
{
    public interface BlockService
    {
        void Add(AddBlockDto dto);
        void Update(int id, UpdateBlockDto dto);
        List<GetAllBlockDto> GetAllBlocks();
        GetOneBlockDto GetOneBlock(int id);
        
    }
}
