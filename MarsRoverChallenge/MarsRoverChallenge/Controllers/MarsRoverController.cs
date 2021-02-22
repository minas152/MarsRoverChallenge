using MarsRoverChallenge.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverChallenge.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MarsRoverController : Controller
    {

        [HttpPost]
        public IActionResult PlotRoversOnPlateau([FromBody] List<String> input)
        {
            try
            {
                Plateau plat = new Plateau();
                plat.InitialisePlateau(input[0]);

                for (int i = 1; i < input.Count - 1; i += 2)
                {
                    MarsRover rover = new MarsRover(input[i], plat);

                    rover.SendRoverCommand(input[i + 1]);
                    plat.Rovers.Add(rover);
                }

                List<string> response = new List<string>();
                foreach (var i in plat.Rovers)
                {
                    response.Add(i.RoverX + " " + i.RoverY + " " + i.RoverDirection.ToString());
                }

                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
