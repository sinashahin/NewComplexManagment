using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Services.Blocks.Contracts.Dto
{
    public class UpdateBlockDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int UnitCount { get; set; }
    }
}
