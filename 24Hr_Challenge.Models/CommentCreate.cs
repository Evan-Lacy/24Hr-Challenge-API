using _24Hr_Challenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Models
{
    public class CommentCreate
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
    }
}
