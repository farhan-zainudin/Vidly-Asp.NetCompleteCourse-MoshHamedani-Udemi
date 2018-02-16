using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

                
            // Dto To Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(x => x.Id, otp => otp.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(x => x.Id, otp => otp.Ignore());
            Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(x => x.Id, otp => otp.Ignore());
            Mapper.CreateMap<Genre, GenreDto>()
                .ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}