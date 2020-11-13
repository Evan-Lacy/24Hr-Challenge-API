using _24Hr_Challenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Models
{
    public class LikeCreate
    {
        public Post LikedPost { get; set; }

        public Guid Liker { get; set; }
    }
}
