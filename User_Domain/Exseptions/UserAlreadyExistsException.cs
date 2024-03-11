using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Domain.Exseptions
{
    public class UserAlreadyExistsException: Exception
    {
        public UserAlreadyExistsException() : base("User already Exist")
        { }
    }
}
