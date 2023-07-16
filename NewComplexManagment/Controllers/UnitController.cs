using Microsoft.AspNetCore.Mvc;
using NewComplexManagment.Services.Units.Contracts;
using NewComplexManagment.Services.Units.Contracts.Dto;

namespace NewComplexManagment.RestApi.Controllers
{
    [Route("units")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly UnitService _service;

        public UnitController(UnitService service) 
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddUnitDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllUnitsDto> GetAllUnits()
        {
            return _service.GetAllUnits();
        }
    }
}
