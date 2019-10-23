using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private IList<int> _numbers;
        private readonly ILogger<NumbersController> _logger;

        public NumbersController(ILogger<NumbersController> logger, IList<int> numbers)
        {
            _numbers = numbers;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            return Ok(_numbers);
        }

        [HttpPut]
        public ActionResult AddNumber(int number = -1)
        {
            if (number == -1)
            {
                var random = new Random();
                number = random.Next(0, 1000);
            }

            _numbers.Add(number);
            return Ok();
        }

        [HttpGet("/api/[controller]/[action]")]
        public ActionResult<int> Sum()
        {
            var sum = _numbers.Sum();
            return Ok(sum);
        }

        [HttpDelete]
        public ActionResult Clear()
        {
            _numbers.Clear();
            return Ok();
        }
    }
}