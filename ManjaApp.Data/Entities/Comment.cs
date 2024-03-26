using ManjaApp.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class Comment : BaseEntity
    {
        public AppUser User { get; set; }
        public Manja Manja { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
