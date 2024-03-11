using Castle.Core.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User_Domain;
using Microsoft.Extensions.Configuration;
using User_Domain.Exseptions;

namespace User_App.UserService.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;


        public UserService(IUserRepository repository)
        {
            _repository = repository;

        }

        public async Task<User> AddUser(User model)
        {
            var userExist = await _repository.GetUserByName(model.Name);

            if (userExist != null)
            {
                throw new UserAlreadyExistsException();
            }

            else
            {
                var user = new User
                {
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    Name = model.Name

                };

                var cUser = await _repository.AddAsync(model);


                return cUser;
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await _repository.GetUserById(id);

            await _repository.DeleteAsync(user);

        }


        public async Task<IEnumerable<User>> GetAllUsersasync()
        {
            var users = await _repository.GetAllUsersasync();
            var res = new List<User>();
            foreach (var user in users)
            {
                res.Add(user);

            }
            return res;
        }



        public async Task<User> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);
            return user;

        }

        public async Task<User> GetUserByName(string name)
        {
            var user = await _repository.GetUserByName(name);

            return user;
        }

        public async Task<User> UpdateUser(User model, int id)
        {
            var userUpdated = await _repository.GetByIdAsync(id);
            if (userUpdated == null)
            {
                throw new Exception("User does not exist");
            }
            userUpdated.Name = model.Name;
            userUpdated.Email = model.Email;
            var updatedUser = await _repository.UpdateAsync(userUpdated);
            return updatedUser;

        }


    }
}
