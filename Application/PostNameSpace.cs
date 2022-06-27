using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamepace
{
    public class Post
    {
        public int Id { get; set; }
        public static int ID = 1;
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;
        public Post()
        {
            Id = ID++;
        }
        public void ShowPostInfo()
        {
            Console.WriteLine($@"Id : {Id}
Content : {Content}");
        }
        public void ShowPost()
        {
            Console.WriteLine($@"Id : {Id}
CreationDateTime : {CreationDateTime}
LikeCount : {LikeCount}
ViewCount : {ViewCount}
Content : {Content}");

        }
    }
}
