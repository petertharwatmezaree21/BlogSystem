using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSystem.Models
{
    public class Comment:BaseEntityClass
    {
        public string Username { get; set; }
        [StringLength(100)]
        public string Body { get; set; }

        public DateTime? CommentDate { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }

}