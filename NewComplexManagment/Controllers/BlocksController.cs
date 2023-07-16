using Microsoft.AspNetCore.Mvc;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Blocks.Contracts.Dto;

namespace NewComplexManagment.RestApi.Controllers
{
    [Route("blocks")]
    [ApiController]
    public class BlocksController : Controller
    {
        private readonly BlockService _service;

        public BlocksController(BlockService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddBlockDto dto)
        {
            _service.Add(dto);
        }
        [HttpPatch("{id}")]
        public void Update([FromRoute] int id, [FromBody] UpdateBlockDto dto)
        {
            _service.Update(id, dto);
        }
        [HttpGet]
        public List<GetAllBlockDto> GetAllBlocks()
        {
            return _service.GetAllBlocks();
        }

        [HttpGet("{id}")]
        public GetOneBlockDto GetOneBlock([FromRoute]int id)
        {
            return _service.GetOneBlock(id);
        }
    }
}
