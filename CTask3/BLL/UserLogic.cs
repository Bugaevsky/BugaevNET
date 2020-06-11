using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        public UserDao _userDao;

        public UserLogic()
        {
            _userDao = new UserDao();
        }

        public string AddUser(User user)
        {
            var number = _userDao.AddUser(user);
            if (number) { return  $"Success"; }
            else { return $"Error"; }
        }

        public string DeleteUser(int iDUser)
        {
            var number = _userDao.DeleteUser(iDUser);
            if (number) { return $"Success"; }
            else { return $"Error"; }
        }

        public List<string> GetUsers()
        {
            var listUsers = _userDao.GetUsers();
            return listUsers;
        }
    }
}
