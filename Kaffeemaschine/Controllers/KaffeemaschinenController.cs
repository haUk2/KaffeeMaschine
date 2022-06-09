using Microsoft.AspNetCore.Mvc;

namespace Kaffeemaschine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeemaschinenController : ControllerBase
    {

        public KaffeemaschieneClass kaffemaschine;
        private readonly ILogger<KaffeemaschinenController> _logger;
        
        public KaffeemaschinenController(ILogger<KaffeemaschinenController> iLogger, KaffeemaschieneClass _kaffemaschine)
        {
            kaffemaschine = _kaffemaschine;
            _logger = iLogger;
        }

        [HttpGet]
        [Route("getWasser")]
        public double GetWasser()
        {
            return kaffemaschine.Wasser;
        }

        [HttpGet]
        [Route("getBohnen")]
        public double GetBohnen()
        {
            return kaffemaschine.Wasser;
        }

        [HttpPost]
        [Route("wasserAuffuellen/{menge:double}")]
        public double SetWasser(double menge)
        {
            kaffemaschine.wasserAuffuellen(menge);
            return kaffemaschine.Wasser;
        }

        [HttpPost]
        [Route("bohnenAuffuellen/{menge:double}")]
        public double SetBohnen(double menge)
        {
            kaffemaschine.bohnenAuffuellen(menge);
            return kaffemaschine.Bohnen;
        }

        [HttpPost]
        [Route("kaffeeMachen/")]
        public IActionResult KaffeeMachen(decimal menge, decimal verhaeltnisWasserBohnen)
        {
            bool worked = kaffemaschine.macheKaffee(menge, verhaeltnisWasserBohnen);
            if (worked)
                return Ok("kaffee was made, " + kaffemaschine.Wasser + "kg Wasser sind übrig und " + kaffemaschine.Bohnen + "kg sind übrig");
            return Problem("couldn't make coffee");
        }
    }
}