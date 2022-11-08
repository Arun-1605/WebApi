using AutoMapper;


namespace NZwalks.API.Profiles
{
    public class RegionProfile : Profile
    {

        public RegionProfile()
        {
            CreateMap<Model.Domain.Regions, Model.DTO.RegionDto>().ReverseMap();
        }

    }
}
