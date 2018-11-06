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
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, CustomerDto>();

            CreateMap<Movie, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, MovieDto>();

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