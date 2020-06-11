using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            var awardsLogic = new AwardLogic();
            var userLogic = new UserLogic();
            var b = true;
            while (b)
            {
                Console.WriteLine(
                    "Choose option:\n" + "1 Add User\n" + "2 Show all users\n" + "3 Delete user\n" + "4 Add Award\n" + "5 Show all awards");
                var ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":
                        {
                            Console.Write("Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Birthday: ");
                            var date = DateTime.Parse(Console.ReadLine());
                            Console.Write("Age: ");
                            int.TryParse(Console.ReadLine(), out var age);
                            var user = new User(name, date, age);
                            var str = userLogic.AddUser(user);
                            Console.WriteLine(str);
                            Console.WriteLine();
                            break;
                        }

                    case "2":
                        {
                            var listUsers = userLogic.GetUsers();
                            foreach (var us in listUsers)
                            {
                                Console.WriteLine(us);
                            }
                            Console.WriteLine();
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("Enter Id");
                            var listUsers = userLogic.GetUsers();
                            foreach (var us in listUsers)
                            {
                                Console.WriteLine(us);
                            }
                            Console.Write("Id: ");
                            int.TryParse(Console.ReadLine(), out var usId);
                            var str = userLogic.DeleteUser(usId);
                            Console.WriteLine(str);
                            Console.WriteLine();
                            break;
                        }

                    case "4":
                        {
                            Console.WriteLine("Enter award type.");
                            Console.Write("Award name: ");
                            var title = Console.ReadLine();
                            var award = new Award(title);
                            var str = awardsLogic.AddAward(award);
                            Console.WriteLine(str);
                            Console.WriteLine();
                            break;
                        }

                    case "5":
                        {
                            foreach (var award in awardsLogic.GetAwards())
                            {
                                Console.WriteLine(award);
                            }
                            Console.WriteLine();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Неверно выбрано действие. Выберите одно из действий в диапазоне от 1 до 8.");
                            break;
                        }
                }
            }
        }
    }
}
