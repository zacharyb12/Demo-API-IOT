using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {

        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var users = new[]
           {
                new
                {
                    id = 1,
                    name = "bob",
                    age = 35
                },
                new
                {
                    id = 2,
                    name = "alice",
                    age = 28
                },
                new
                {
                    id = 3,
                    name = "bobby",
                    age = 54
                },
                new
                {
                    id = 4,
                    name = "justine",
                    age = 32
                }
            };

            return Ok(users);
        }


        [HttpPost]
        public IActionResult Create(string value)
        {
            if(value.Length < 2)
            {
                return BadRequest("Fournir au minimum deux caractère");
            }

                return Ok(new { response = "Ok", StatusCode = 201 , value = value});

        }


        [HttpPut]
        public IActionResult Update(string value)
        {
            if (value.Length < 2)
            {
                return BadRequest("Fournir au minimum deux caractère");
            }

            return Ok(new { response = "Ok", StatusCode = 201, value = value });
        }


        [HttpDelete]
        public IActionResult Delete(string value)
        {
            if (value.Length < 2)
            {
                return BadRequest("Fournir au minimum deux caractère");
            }

            return Ok(new { response = "Ok", StatusCode = 201, value = value });
        }


    }
}
