using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual List<Post> Posts { get; set; }

        public int BlogID { get; set; }
    }
}