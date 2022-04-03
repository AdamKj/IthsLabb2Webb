namespace IthsLabb2Webb.Server.Services.UserService;

public interface IUserService
{
    public Task<List<Course>> GetUserCourses(int id);
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUser(int id);
    public Task<bool> CreateUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<bool> DeleteUser(int id);
    public Task<User> GetUserByEmail(string email);
}