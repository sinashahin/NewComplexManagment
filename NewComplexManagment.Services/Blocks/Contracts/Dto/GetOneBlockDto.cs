using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts.Dto
{
    public class GetOneBlockDto
    {
        public string Name { get; set; }
        public List<GetUnitOfBlock> GetUnitOfBlocks { get; set; }
    }

    public class GetUnitOfBlock
    {
        public string Name { get; set; }
        public ResidenceType ResidenceType { get; set; }
    }
}
