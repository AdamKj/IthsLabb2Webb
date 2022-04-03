using Microsoft.AspNetCore.Mvc;

namespace IthsLabb2Webb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Course>>> GetCourses()
    {
        var result = await _courseService.GetAllCourses();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetSingleCourse(int id)
    {
        var result = await _courseService.GetCourse(id);
        return Ok(result);
    }

    [HttpGet("{id}/users")]
    public async Task<ActionResult<List<Course>>> GetCourseUsers(int id)
    {
        var result = await _courseService.GetCourseUsers(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        await _courseService.CreateCourse(course);
        return Ok(course);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<bool>> ListUserOnCourse([FromBody]User user, int id)
    {
        var result = await _courseService.ListUserOnCourse(user, id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<Course>> UpdateCourse(Course course)
    {
        var result = await _courseService.UpdateCourse(course);
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteCourse(int id)
    {
        var result = await _courseService.DeleteCourse(id);
        return Ok(result);
    }
}