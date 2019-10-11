using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class Post:BaseEntityClass
    {
        [StringLength(50,ErrorMessage ="The length of the title must be between {1} and {2}",MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(int.MaxValue),AllowHtml]
        public string Body { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category Category { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Comment>Comments{ get; set; }
        public virtual ICollection<Keywords> Keywords { get; set; }
        public string Author { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter a valid Email")]
        public string AuthorEmail { get; set; }



    }
}