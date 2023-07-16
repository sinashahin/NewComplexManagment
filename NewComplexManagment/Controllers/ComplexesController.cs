using Microsoft.AspNetCore.Mvc;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.Complexes.Contracts.Dto;
using NewComplexManagment.Services.Contracts;

namespace NewComplexManagment.RestApi.Controllers
{
    [Route("complexes")]
    [ApiController]
    public class ComplexesController : Controller
    {
        
        private readonly ComplexService _service;

        public ComplexesController(ComplexService service)
        {
            _service = service;
            
        }
        [HttpPost]
        public void Add(AddComplexDto dto)
        {
            _service.Add(dto);
            
        }
        [HttpGet]
        public List<GetAllComplexDto> GetAll([FromQuery] int? id, [FromQuery]string? name)
        {
            return _service.GetAllComplexes(id,name);
        }
        [HttpGet("{id}")]
        public GetOneComplexDto GetOne([FromRoute]int id) 
        {
            return _service.GetOneComplex(id);
        }
        [HttpGet("{id}/block")]
        public GetOneComplexWithBlockDto GetOneComplexWithBlock([FromRoute]int id, [FromQuery]string? name)
        {
            return _service.GetOneComplexWithBlock(id,name);
        }
        [HttpGet("{id}/usage-types")]
        public List<GetOneComplexUsageTypeDto>
            GetOneComplexUsageType([FromRoute]int id)
        {
            return _service.GetOneComplexUsageType(id);
        }
        [HttpPatch("{id}")]
        public void Update([FromRoute]int id,UpdateComplexUnitCountDto dto)
        {
            _service.Update(id,dto);
        }
    }
}
