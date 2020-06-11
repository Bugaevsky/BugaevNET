using System;
using System.Collections.Generic;
using Entities;

namespace BLL
{
    public interface IUserLogic
    {
        string AddUser(User user);
        string DeleteUser(int iDUser);
        List<string> GetUsers();
    }
}
