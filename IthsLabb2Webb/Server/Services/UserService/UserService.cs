namespace IthsLabb2Webb.Server.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<Course>> GetUserCourses(int id)
    {
        var user = await _context.Users
            .Include(u => u.Courses)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) return null;

        return user.Courses;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<bool> CreateUser(User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email)) return false;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> UpdateUser(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null) return null;

        existingUser.Id = user.Id;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Phone = user.Phone;
        existingUser.Address.Street = user.Address.Street;
        existingUser.Address.City = user.Address.City;
        existingUser.Address.Zip = user.Address.Zip;
        existingUser.Courses = user.Courses;
        existingUser.Role = user.Role;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}