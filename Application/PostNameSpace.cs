using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamepace
{
    public class Post
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;

    }
}
