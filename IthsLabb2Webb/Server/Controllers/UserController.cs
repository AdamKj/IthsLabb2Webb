using Microsoft.AspNetCore.Mvc;

namespace IthsLabb2Webb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var result = await _userService.GetAllUsers();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetSingleUser(int id)
    {
        var result = await _userService.GetUser(id);
        return Ok(result);
    }

    //[HttpGet("/users/email")]
    //public async Task<ActionResult<User>> GetUserByEmail(string email)
    //{
    //    var result = await _userService.GetUserByEmail(email);
    //    return Ok(result);
    //}

    [HttpGet("{id}/courses")]
    public async Task<ActionResult<List<User>>> GetUserCourses(int id)
    {
        var result = await _userService.GetUserCourses(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> CreateUser(User user)
    {
        var result = await _userService.CreateUser(user);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<User>> UpdateUser(User user)
    {
        var result = await _userService.UpdateUser(user);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        var result = await _userService.DeleteUser(id);
        return Ok(result);
    }
}