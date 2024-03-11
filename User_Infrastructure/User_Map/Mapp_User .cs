using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using User_Domain;
using AutoMapper;

namespace User_Infrastructure.User_Map
{
    public class Mapp_User : Profile
    {
        public Mapp_User()
        {
            CreateMap<UserDto, User>()
            .ForMember(dest => dest.CustoGenderMap, opt => opt.MapFrom(src => src.CustoGenderMap));
            //--------------------------------------------------------------------------------------------
         
            //--------------------------------------------------------------------------------------------
        }
    }
}
