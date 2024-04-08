using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ManjaCreateEditDTO : BaseDTO
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Instructions { get; set; }
        public string Picture { get; set; }
    }
}
