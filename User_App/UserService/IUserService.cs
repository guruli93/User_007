using User_Domain;

namespace User_App.UserService.UserService
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<IEnumerable<User>> GetAllUsersasync();
        Task<User> AddUser(User model);
        Task<User> UpdateUser(User model, int id);
        Task DeleteUser(int id);


    }
}
