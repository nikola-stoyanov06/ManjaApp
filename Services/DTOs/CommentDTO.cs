using ManjaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CommentDTO : BaseDTO
    {
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
