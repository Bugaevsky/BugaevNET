using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
namespace CTask2
{
    class FileManager
    {
        private const int UserRequiredSymbolsCount = 5;
        private const int EmployeeRequiredSymbolsCount = 7;
        public List<User> Reader(string path)
        {
            List<User> result = new List<User>(); 
            using (StreamReader sr = new StreamReader(path))
            {
                char[] definitions = { ',', ' ', '.', ':' };
                string[] users = sr.ReadToEnd().Split('\n');
                foreach (string user in users)
                {
                    string[] temp = user.Split(definitions, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length == UserRequiredSymbolsCount)
                    {

                        if ((DateTime.TryParse(temp[3], out DateTime DateValue)) && (int.TryParse(temp[4], out int AgeValue)))
                        {
                            result.Add(new User(temp[0], temp[1], temp[2], DateValue, AgeValue));
                        }
                        else
                        {
                            throw new ArgumentException("Data can't be parsed(values is not correct)");
                        }
                    }
                    else if (temp.Length == EmployeeRequiredSymbolsCount)
                    {
                        if ((DateTime.TryParse(temp[3], out DateTime DateValue)) && (int.TryParse(temp[4], out int AgeValue)) && (int.TryParse(temp[5], out int ExperienceValue)) && (ExperienceValue >= 0))
                        {
                            User user1 = new User(temp[0], temp[1], temp[2], DateValue, AgeValue);
                            result.Add(new Employee(temp[0], temp[1], temp[2], DateValue, AgeValue, ExperienceValue, temp[6]));
                        }
                        else
                        {
                            throw new ArgumentException("Data can't be parsed(values is not correct)");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Input string should be 5 or 7 length");
                    }
                }
                return result;
            }
        }
        
        public void Writer(User user, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("User:");
                sw.WriteLine("Surname: " + user.Surname);
                sw.WriteLine("Name: " + user.Name);
                sw.WriteLine("Fathername: " + user.Fathername);
                sw.WriteLine("Birthday: " + user.Birthday.ToShortDateString());
                sw.WriteLine("Age: " + user.Age);
            }
        }

        public void Writer(Employee employee, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Employee:");
                sw.WriteLine("Surname: " + employee.Surname);
                sw.WriteLine("Name: " + employee.Name);
                sw.WriteLine("Fathername: " + employee.Fathername);
                sw.WriteLine("Birthday: " + employee.Birthday.ToShortDateString());
                sw.WriteLine("Age: " + employee.Age);
                sw.WriteLine("Work Experience: " + employee.Experience);
                sw.WriteLine("Position: " + employee.Position);
            }
        }
    }
}
