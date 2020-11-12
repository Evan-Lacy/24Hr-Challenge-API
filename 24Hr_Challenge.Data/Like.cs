using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Data
{
    public class Like
    {  
        [Required]
        public Post LikedPost { get; set; }
        [Key]
        public Guid Liker { get; set; }

    }
}
