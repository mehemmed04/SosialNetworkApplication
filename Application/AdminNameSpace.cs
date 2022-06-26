using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamepace;
using NotificationNamespace;
namespace AdminNameSpace
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Post[] Posts { get; set; }
        public int PostCount { get; set; } = 0;
        public Notification[] Notifications { get; set; }
        public int NotificationCount { get; set; } = 0;
        public void ShowAllPosts()
        {
            foreach (var post in Posts)
            {
                post.ShowPost();
                Console.WriteLine("================================");
            }
        }
        public void ShowAllNotifications()
        {
            foreach (var notification in Notifications)
            {
                notification.ShowNotification();
                Console.WriteLine("-------------------------------");
            }
        }
        public void AddPost(ref Post post)
        {
            Post[] temp = new Post[PostCount++];
            if (Posts != null)
            {
                Posts.CopyTo(temp, 0);
            }
            temp[PostCount - 1] = post;
            Posts = temp;
        }
        public void AddNotification(ref Notification notification)
        {
            Notification[] temp = new Notification[NotificationCount++];
            if (Notifications != null)
            {
                Notifications.CopyTo(temp, 0);
            }
            temp[NotificationCount - 1] = notification;
            Notifications = temp;
        }
    }
}
