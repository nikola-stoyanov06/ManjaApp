using ManjaApp.Data.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IManjaService
    {
        Task<List<ManjaDTO>> GetManjasAsync();
        Task<ManjaDTO> GetManjaByIdAsync(int id);
        Task<ManjaCreateEditDTO> GetManjaByIdEditAsync(int id);
        Task<List<ManjaDTO>> GetManjasByNameAsync(string name);
        Task AddManjaAsync (ManjaCreateEditDTO model);
        Task DeleteManjaByIdAsync (int id);
        Task UpdateManjaAsync(ManjaCreateEditDTO model);
    }
}
