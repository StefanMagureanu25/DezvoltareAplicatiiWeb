using AutoMapper;
using IMDB.Models;
using IMDB.Models.DTOs.Directors;
using IMDB.Models.DTOs.Users;

namespace IMDB.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        { 
            CreateMap<DirectorRequestDTO, Director>()
                .ForMember(dest => dest.DirectorId,
                    opts => opts.NullSubstitute(Guid.NewGuid()));

            CreateMap<Director, DirectorResponseDTO>();

            CreateMap<User, UserResponseDTO>();
        }
    }
}
