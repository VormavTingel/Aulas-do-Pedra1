using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private double? M1;
        private double? M2;
        private double? M3;

        [HttpPost("add")]
        public IActionResult Add(double num1, double num2)
        {
            double result = num1 + num2;
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract(double num1, double num2)
        {
            double result = num1 - num2;
            return Ok(result);
        }

        [HttpPost("multiply")]
        public IActionResult Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                return BadRequest("Cannot divide by zero");
            }

            double result = num1 / num2;
            return Ok(result);
        }

        [HttpPost("storeM1")]
        public IActionResult StoreM1(double value)
        {
            M1 = value;
            return Ok();
        }

        [HttpPost("storeM2")]
        public IActionResult StoreM2(double value)
        {
            M2 = value;
            return Ok();
        }

        [HttpPost("storeM3")]
        public IActionResult StoreM3(double value)
        {
            M3 = value;
            return Ok();
        }

        [HttpGet("getM1")]
        public IActionResult GetM1()
        {
            return Ok(M1);
        }

        [HttpGet("getM2")]
        public IActionResult GetM2()
        {
            return Ok(M2);
        }

        [HttpGet("getM3")]
        public IActionResult GetM3()
        {
            return Ok(M3);
        }

        [HttpGet("memory")]
        public IActionResult Get()
        {
            var response = new MemoryRequestResponse();
            response.M1 = M1;
            response.M2 = M2;  
            response.M3 = M3;
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
            M1 = request.M1;
            M2 = request.M2;
            M3 = request.M3;
            return Ok();
        }
    }
}
