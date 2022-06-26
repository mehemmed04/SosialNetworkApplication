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
    }
}
