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
                Users = new User[] { },
                UserCount = 0,
                AdminCount = 0
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
                            AdminPage(ref CurrentAdmin);
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
                            UserPage(ref CurrentUser);
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
        public static void AdminPage(ref Admin CurrentAdmin)
        {
            Console.WriteLine("Show All Posts         [1] ");
            Console.WriteLine("Add Post               [2] ");
            Console.WriteLine("Show All Notifications [3] ");
            bool IsInt = int.TryParse(Console.ReadLine(), out int select);
            if (select == 1)
            {
                CurrentAdmin.ShowAllNotifications();
            }
            else if(select == 2)
            {
                Console.WriteLine("Enter Post Content : ");
                string content = Console.ReadLine();
                Post p = new Post()
                {
                    Content = content,
                    CreationDateTime = DateTime.Now,
                };
                CurrentAdmin.AddPost(ref p);
            }
            else if (select == 3)
            {
                CurrentAdmin.ShowAllNotifications();
            }
        }
        public static void UserPage(ref User CurrentUser)
        {
            
        }
    }
}
