using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class Keywords:BaseEntityClass
    {
        public string Word { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}