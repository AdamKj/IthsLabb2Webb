namespace IthsLabb2Webb.Server.Services.CourseService;

public interface ICourseService
{
    public Task CreateCourse(Course course);
    public Task<bool> ListUserOnCourse(User user, int id);
    public Task<List<Course>> GetAllCourses();
    public Task<Course> GetCourse(int id);
    public Task<Course> UpdateCourse(Course course);
    public Task<bool> DeleteCourse(int id);
    public Task<List<User>> GetCourseUsers(int id);
}