using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.ComplexUsageType.Contracts.Dto
{
    public class AddComplexUsageTypeDto
    {
        public int ComplexId { get; set; }
        public int UsageTypeId { get; set; }
    }
}
