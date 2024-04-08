using AutoMapper;
using ManjaApp.Data.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class ManjaProfile : Profile
    {
        public ManjaProfile() 
        {
            CreateMap<Manja, ManjaDTO>()
                .ReverseMap();
            CreateMap<Manja, ManjaCreateEditDTO>()
                .ReverseMap();
            
        }
    }
}
