using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly AwardDao _awardsDao;

        public AwardLogic()
        {
            _awardsDao = new AwardDao();
        }

        public string AddAward(Award award)
        {
            var number = _awardsDao.AddAward(award);
            if (number) { return $"Success";  }
            else {return  $"Error"; }
        }

        public List<Award> GetAwards()
        {
            var listAwards = _awardsDao.GetAwards();
            return listAwards;
        }
    }
}
