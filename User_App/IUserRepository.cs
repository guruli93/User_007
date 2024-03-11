using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Domain;

namespace User_App
{
    public interface IUserRepository : IAsyncRepository<User>
    {

        Task<User> GetUserByName(string name);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsersasync();

    }
}
