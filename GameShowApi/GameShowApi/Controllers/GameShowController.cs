using System;
using System.ComponentModel.DataAnnotations;
using GameShowApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameShowController : ControllerBase
    {

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
