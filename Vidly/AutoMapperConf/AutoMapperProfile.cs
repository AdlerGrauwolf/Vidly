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
            CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, Movie>();
        }

        public static void Map()
        {
            Mapper.Initialize(a => a.AddProfile<AutoMapperProfile>());
        }
    }
}