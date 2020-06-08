using System;
using System.ComponentModel.DataAnnotations;
using GameShowApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameShowController : ControllerBase
    {

        // GET api/<GameShowController>/5
        [HttpGet("{numberOfSimulations}")]
        public ActionResult<int> Get(int numberOfSimulations, [FromQuery(Name = "switchDoor")] bool switchDoor)
        { 
            if (numberOfSimulations < 1 || numberOfSimulations > 100000) 
            {
                return BadRequest(ModelState);
            }


            int addition = GameShowCalcualationService.CalculateNumberOfWins(numberOfSimulations, switchDoor);
            return addition;
        }
    }
}
