using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class Category:BaseEntityClass
    {
        public string Title { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}