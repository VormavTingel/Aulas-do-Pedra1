using System;
using System.Collections.Generic;
using Calculadora_API;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("memory")]
        public IActionResult Get()
        {
            var response = new MemoryRequestResponse();
            var storage = MemoryStorage.Instance;
            response.M1 = storage.M1;
            response.M2 = storage.M2;
            response.M3 = storage.M3;
            return Ok(response);
        }

        public class MemoryRequestResponse
        {
            public double? M1 { get; set; }
            public double? M2 { get; set; }
            public double? M3 { get; set; }
        }

        [HttpPost("memory")]
        public IActionResult Post([FromBody] MemoryRequestResponse request)
        {
            var storage = MemoryStorage.Instance;
            storage.M1 = request.M1;
            storage.M2 = request.M2;
            storage.M3 = request.M3;
            return Ok();
        }
    }
}
