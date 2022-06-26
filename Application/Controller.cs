using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNameSpace;
using PostNamepace;
using NotificationNamespace;
using UserNamespace;
using DatabaseNameSpace;

namespace ControllerNamespace
{
    public class Controller
    {
        public static void Start()
        {
            DataBase database = new DataBase
            {
                Admins = new Admin[] { },
                Users = new User[] { }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ADMIN  [1] : ");
                Console.WriteLine("USER   [2] : ");

                bool IsInt = int.TryParse(Console.ReadLine(), out int select);
                if (select == 1)
                {
                    Console.WriteLine("Enter e-mail : ");
                    string email = Console.ReadLine();
                    Admin CurrentAdmin = database.GetAdminByEmail(email);
                    if (CurrentAdmin != null)
                    {
                        Console.WriteLine("Enter password : ");
                        string password = Console.ReadLine();
                        if(password == CurrentAdmin.Password)
                        {
                            //ADMINPAGE()
                        }
                        else
                        {
                            Console.WriteLine("Password is incorret!");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is not such email in Database");
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (select == 2)
                {
                    Console.WriteLine("Enter e-mail : ");
                    string email = Console.ReadLine();
                    User CurrentUser = database.GetUserByEmail(email);
                    if (CurrentUser != null)
                    {
                        Console.WriteLine("Enter password : ");
                        string password = Console.ReadLine();
                        if (password == CurrentUser.Password)
                        {
                            



                        }
                        else
                        {
                            Console.WriteLine("Password is incorret!");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is not such email in Database");
                        Console.ReadKey();
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
