using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDao
    {
        bool AddUser(User user);
        bool DeleteUser(int iDUser);
        List<string> GetUsers();
    }
}
