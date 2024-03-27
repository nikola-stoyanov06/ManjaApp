using ManjaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IManjaService
    {
        Task<List<Manja>> GetManjasAsync();
        Task<Manja> GetManjaByIdAsync(int id);
        Task<List<Manja>> GetManjasByNameAsync(string name);
        Task AddManjaAsync (Manja manja);
        Task DeleteManjaByIdAsync (int id);
        Task UpdateManjaAsync(Manja manja);
    }
}
