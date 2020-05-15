using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTask2
{
    class Employee : User
    {
        private int _experience;
        private string _position;

        public Employee( string surname, string name, string fathername, DateTime birthday, int age, int experience, string position)
            : base(surname, name, fathername, birthday, age)
        {
            _experience = experience;
            _position = position;
        }

        public int Experience { get => _experience;}
        public string Position { get => _position; }
    }
}
