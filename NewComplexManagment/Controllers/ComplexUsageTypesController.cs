using Microsoft.AspNetCore.Mvc;
using NewComplexManagment.Services.ComplexUsageType.Contracts;
using NewComplexManagment.Services.ComplexUsageType.Contracts.Dto;

namespace NewComplexManagment.RestApi.Controllers
{
    [Route("complex-usage-types")]
    [ApiController]
    public class ComplexUsageTypesController : Controller
    {
        private readonly ComplexUsageTypeService _service;

        public ComplexUsageTypesController(ComplexUsageTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddComplexUsageTypeDto dto)
        {
            _service.Add(dto);
        }
    }
}
