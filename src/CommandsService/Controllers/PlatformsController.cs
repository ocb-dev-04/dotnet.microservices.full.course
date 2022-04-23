using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("[controller]")]
    public class PlatformsController : Controller
    {
        public PlatformsController(ILogger<PlatformsController> logger)
        {
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

    }
}