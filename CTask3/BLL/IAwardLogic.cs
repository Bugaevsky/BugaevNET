using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAwardLogic
    {
        string AddAward(Award award);
        List<Award> GetAwards();
    }
}
