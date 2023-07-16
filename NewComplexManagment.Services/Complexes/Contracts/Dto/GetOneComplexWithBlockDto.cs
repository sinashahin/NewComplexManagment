using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Complexes.Contracts.Dto
{
    public class GetOneComplexWithBlockDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetBlockForComplex> GetBlockForComplexes { get; set; }
    }

    public class GetBlockForComplex
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public int UnitCount { get; set; }
    }
}
