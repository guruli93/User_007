using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_App;
using User_Domain;
using User_Domain.Exseptions;

namespace User_Infrastructure
{
    public class UserRepository : UFrepository<User>, IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task<IEnumerable<User>> GetAllUsersasync()

        {

            var users = await _dbContext.Users.ToListAsync();


            return users;

        }

      

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);

        }



        public async Task<User> GetUserByName(string name)
        {
            //var query =  _dbContext.Set<User>()
            //.Where(c => c.Name.Contains(name));
            //List<User> users = await query.ToListAsync();
            //User? xxx = users.FirstOrDefault();
            //if (xxx== null)
            //{
            //    throw new UserNotFound();
            //}
            //else
            //{
            //    return xxx;
            //}

            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);

        }


    }
}
