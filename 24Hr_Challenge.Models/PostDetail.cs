﻿using _24Hr_Challenge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Comment> Comment { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
