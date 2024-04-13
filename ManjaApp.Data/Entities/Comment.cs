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
        public virtual AppUser? User { get; set; }
        public string UserId { get; set; }
        public  virtual Manja? Manja { get; set; }
        public int ManjaId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
