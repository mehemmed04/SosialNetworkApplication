using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationNamespace
{
    public class Notification
    {
        public int Id { get; set; }
        public static int ID = 1;
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string FromUser { get; set; }
        public Notification()
        {
            Id = ID++;
        }
        public void ShowNotification()
        {
            Console.WriteLine($@"Id : {Id}
Text : {Text}
Time : {Time.ToString()}
User : {FromUser}");
        }
    }
}
