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
        public static DataBase database = new DataBase
        {
            Admins = new Admin[] { new Admin { Email = "admin1@gmail.com", Password = "1234", Username = "admin1", Posts = new Post[] { new Post {  Content = "Content1",CreationDateTime = DateTime.Now} , new Post { Content = "Content2", CreationDateTime = DateTime.Now } } },
            new Admin { Email = "admin2@gmail.com", Password = "0000", Username = "admin2", Posts = new Post[] { new Post {  Content = "Content3",CreationDateTime = DateTime.Now} , new Post { Content = "Content4", CreationDateTime = DateTime.Now } } }},

            Users = new User[] { new User { Age = 18, Email = "mehemmedbayramov2004@gmail.com", Name = "Mehemmed", Password = "0000", Surname = "Bayramov" } },
            UserCount = 0,
            AdminCount = 0
        };

        public static void Start()
        {

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
                        if (password == CurrentAdmin.Password)
                        {
                            AdminPage(ref CurrentAdmin);
                        }
                        else
                        {
                            Console.WriteLine("Password is incorret!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is not such email in Database");
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
                    }
                }
                Console.ReadKey();
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
                CurrentAdmin.ShowAllPosts();
                Console.ReadKey();
            }
            else if (select == 2)
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

            ConsoleKey key;
            Notification notification;
            foreach (var admin in database.Admins)
            {
                bool Break = false;
                foreach (var post in admin.Posts)
                {
                    Console.Clear();
                    Console.WriteLine("                 Enter         -  QUIT");
                    Console.WriteLine("                 DownArrow     -  LIKE");
                    Console.WriteLine("                 UpArrow       -  VIEW");
                    Console.WriteLine("                 RightArrow    -  Next");
                    Console.WriteLine();
                    post.ShowPostInfo();
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.DownArrow)
                    {
                        post.LikeCount++;
                        notification = new Notification { FromUser = CurrentUser.Name + " " + CurrentUser.Surname, Text = "liked your post" };

                        admin.AddNotification(ref notification);
                    }
                    else if (key == ConsoleKey.UpArrow)
                    {
                        Console.SetCursorPosition(0, 5);
                        post.ViewCount++;
                        notification = new Notification { FromUser = CurrentUser.Name + " " + CurrentUser.Surname, Text = "viewed to your post" };
                        admin.AddNotification(ref notification);
                        post.ShowPost();
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.DownArrow)
                        {
                            post.LikeCount++;
                            notification = new Notification { FromUser = CurrentUser.Name + " " + CurrentUser.Surname, Text = "liked your post" };
                            admin.AddNotification(ref notification);
                        }
                        else if (key == ConsoleKey.RightArrow)
                        {
                            continue;
                        }

                    }
                    else if (key == ConsoleKey.RightArrow)
                    {
                        continue;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        Break = true;
                        break;
                    }
                }
                if (Break) break;
            }

        }
    }
}
