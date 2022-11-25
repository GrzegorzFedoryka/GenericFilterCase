using GenericFilterCase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericFilterCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        

        private readonly ILogger<TestController> _logger;
        private readonly Context _context;

        public TestController(ILogger<TestController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("parents")]
        public async Task<IList<ParentMeasurement>> GetParentsFiltered([FromQuery]int[] values)
        {
            return await _context.ParentMeasurements.ApplyFilter(values).ToListAsync();    
        }
        [HttpGet("children")]
        public async Task<IList<ChildMeasurement>> GetChildrenFiltered([FromQuery] int[] values)
        {
            return await _context.ChildrenMeasurements.ApplyFilter(values).ToListAsync();
        }
    }
}