using AutoMapper;
using Dm = CompanyName.MyAppName.Model.Models;
using Et = CompanyName.MyAppName.Core.Entities;

namespace CompanyName.MyAppName.Domain.MappingProfiles
{
    /// <summary>
    /// Provides profile for mapping DTOs with db entities.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile" /> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Et.User, Dm.User>();

            CreateMap<Dm.User, Et.User>();

            CreateMap<Et.UserSetting, Dm.UserSetting>();

            CreateMap<Dm.UserSetting, Et.UserSetting>();
        }        
    }
}
