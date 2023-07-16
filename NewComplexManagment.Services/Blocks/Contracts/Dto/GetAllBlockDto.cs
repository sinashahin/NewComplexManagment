using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts.Dto
{
    public class GetAllBlockDto
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int SubmitUnitCount { get; set; }
        public int RemainUnitCount { get; set; }
    }
}
