namespace RubikCubeChallenge.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using RubikCubeChallenge.Application;

[Route("api/rubik-cube")]
[ApiController]
public class RubikCubeController(IRubikCube cube) : ControllerBase
{
    [HttpGet("state")]
    public ActionResult GetCubeState()
    {
        return Ok(cube.ToString());
    }

    [HttpPost("rotate/{face}")]
    public ActionResult RotateFace([FromRoute] RubikCubeFace face, [FromQuery] bool inverted = false)
    {
        switch (face)
        {
            case RubikCubeFace.Front:
                cube.MoveFront(inverted);
                break;
            case RubikCubeFace.Back:
                cube.MoveBack(inverted);
                break;
            case RubikCubeFace.Left:
                cube.MoveLeft(inverted);
                break;
            case RubikCubeFace.Right:
                cube.MoveRight(inverted);
                break;
            case RubikCubeFace.Up:
                cube.MoveUp(inverted);
                break;
            case RubikCubeFace.Down:
                cube.MoveDown(inverted);
                break;
            default:
                return BadRequest("Invalid face");
        }

        return Ok(cube.ToString());
    }

    [HttpPost("reset")]
    public ActionResult ResetCube()
    {
        cube.Reset();
        return Ok(cube.ToString());
    }
}
