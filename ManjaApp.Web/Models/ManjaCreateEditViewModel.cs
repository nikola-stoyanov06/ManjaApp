using Services.DTOs;

namespace ManjaApp.Web.Models
{
    public class ManjaCreateEditViewModel : ManjaCreateEditDTO
    {
        public IFormFile Picture { get; set; }
    }
}
