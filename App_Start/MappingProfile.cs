using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Start
{
    using AutoMapper;

    using WebApplication1.DTOs;
    using WebApplication1.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genres, GenreDto>();

        }
    }
}