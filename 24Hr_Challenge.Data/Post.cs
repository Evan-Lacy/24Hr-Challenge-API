using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public Guid Author { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        //public string Comment { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();




        //public int CommentId { get; set; }
        //[ForeignKey(nameof(CommentId))]
        //public virtual Comment CommentProp { get; set; }

    }
}
