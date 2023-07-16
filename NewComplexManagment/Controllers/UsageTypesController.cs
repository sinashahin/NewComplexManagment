using Microsoft.AspNetCore.Mvc;
using NewComplexManagment.Services.UsageType.Contracts;
using NewComplexManagment.Services.UsageType.Contracts.Dto;

namespace NewComplexManagment.RestApi.Controllers
{
    [Route("usage-types")]
    [ApiController]
    public class UsageTypesController : Controller
    {
        private readonly UsageTypeService _service;

        public UsageTypesController(UsageTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddUsageTypeDto dto)
        {
            _service.Add(dto);
        }
        [HttpGet]
        public List<GetAllUsageTypeDto> GetAll()
        {
            return _service.GetAllUsageType();
        }
    }
}
