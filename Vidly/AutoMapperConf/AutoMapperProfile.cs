using AutoMapper;

using Vidly.Models;

namespace Vidly.AutoMapperConf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, Customer>();
        }

        public static void Map()
        {
            Mapper.Initialize(a => a.AddProfile<AutoMapperProfile>());
        }
    }
}