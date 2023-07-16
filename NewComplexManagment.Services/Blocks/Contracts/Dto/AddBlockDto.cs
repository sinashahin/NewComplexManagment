using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts.Dto
{
    public class AddBlockDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int UnitCount { get; set; }
        [Required]
        public int ComplexId { get; set; }
    }
}
