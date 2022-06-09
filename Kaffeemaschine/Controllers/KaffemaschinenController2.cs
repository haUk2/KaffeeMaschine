using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaffeemaschine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaffemaschinenController2 : ControllerBase
    {

        public KaffeemaschieneClass kaffemaschine;
        private readonly ILogger<KaffeemaschinenController> _logger;

        public KaffemaschinenController2(ILogger<KaffeemaschinenController> iLogger, KaffeemaschieneClass _kaffemaschine)
        {
            kaffemaschine = _kaffemaschine;
            _logger = iLogger;
        }

        [HttpGet]
        public double getWater()
        {
            return kaffemaschine.Wasser;
        }

    }
}
