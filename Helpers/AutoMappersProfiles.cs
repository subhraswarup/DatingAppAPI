using System.Linq;
using AutoMapper;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using DatingAppAPI.Dtos;

namespace DatingAppAPI.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url);
            })
            .ForMember( dest => dest.Age, opt => {
                opt.MapFrom(d=>d.DateOfBirth.CalculateAge());
            });
            CreateMap<User,UserForDetailedDto>()
                   .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url);
            })
             .ForMember( dest => dest.Age, opt => {
                opt.MapFrom(d=>d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo,PhotosForDetailedDto>();
        }
    }
}