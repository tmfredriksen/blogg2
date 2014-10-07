using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string title { get; set; }
        public string  Text { get; set; }
        public string Author { get; set; }
        public bool CommentsAllowed { get; set; }
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual List<Comment> Comments { get; set; }


    }
}