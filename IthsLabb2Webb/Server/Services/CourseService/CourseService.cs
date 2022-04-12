namespace IthsLabb2Webb.Server.Services.CourseService;

public class CourseService : ICourseService
{
    private readonly DataContext _context;

    public CourseService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateCourse(Course course)
    {
        if (_context.Courses.Any(c => c.Title == course.Title)) return;

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ListUserOnCourse(User user, int id)
    {
        var course = _context.Courses.Find(id);
        var getUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

        if (getUser == null || course == null) return false;

        course.Users.Add(getUser);
        getUser.Courses.Add(course);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetCourseUsers(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Users)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null) return null;

        return course.Users;
    }

    public async Task<List<Course>> GetAllCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourse(int id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public async Task<Course> UpdateCourse(Course course)
    {
        var dbCourse = await _context.Courses.FindAsync(course.Id);
        if (dbCourse == null) return null;

        dbCourse.Id = course.Id;
        dbCourse.Title = course.Title;
        dbCourse.Description = course.Description;
        dbCourse.CourseLength = course.CourseLength;
        dbCourse.Level = course.Level;
        dbCourse.Status = course.Status;
        dbCourse.Users = course.Users;

        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<bool> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }
}