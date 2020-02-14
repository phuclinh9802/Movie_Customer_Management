using AutoMapper;
using Movie.Dtos;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Movie.Dtos.CustomerDto;

namespace Movie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomerDto>();
            //Mapper.CreateMap<CustomerDto, Customers>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}