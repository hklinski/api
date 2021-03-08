using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public IActionResult Get()
        {
            var people = new List<Models.Person>
            {
                new Models.Person
                {
                    FirstName = "Hubert",
                    LastName = "Klinski",
                    Id = 1
                }
            };
            return Ok(people);

        }
    
    }

}
