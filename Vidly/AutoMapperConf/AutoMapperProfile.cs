using AutoMapper;

using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.AutoMapperConf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, Customer>();
            CreateMap<Movie, Movie>();

            // Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, CustomerDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, MovieDto>();
            CreateMap<MovieGenre, MovieGenreDto>();

            // Ignore Id when mapping updating values
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }

        public static void Map()
        {
            Mapper.Initialize(a => a.AddProfile<AutoMapperProfile>());
        }
    }
}