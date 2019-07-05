using AutoMapper;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Mapper
{
    public class MapperRepository : Profile
    {
        public MapperRepository()
        {
            #region User
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UserLeaderIdDto, opt => opt.MapFrom(src => src.UserLeaderId))
                .ForMember(dest => dest.UserLeaderDto, opt => opt.MapFrom(src => src.UserLeader))
                .ForMember(dest => dest.UserPermissionsDto, opt => opt.MapFrom(src => src.UserPermissions))
                .ForMember(dest => dest.FirstAccessCompany, opt => opt.MapFrom(src => src.Company.FirstAcess));
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.UserLeaderId, opt => opt.MapFrom(src => src.UserLeaderIdDto))
                .ForMember(dest => dest.UserPermissions, opt => opt.MapFrom(src => src.UserPermissionsDto));
            #endregion

            #region Company
            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UsersDto))
                .ForMember(dest => dest.UserCommercialId, opt => opt.MapFrom(src => src.UserCommercialId));
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.UsersDto, opt => opt.MapFrom(src => src.Users));
            #endregion

            #region Group
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
            #endregion

            #region Permission
            CreateMap<PermissionDto, Permission>();
            CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.GroupDto, opt => opt.MapFrom(src => src.Group));
            #endregion

            #region UserPermission
            CreateMap<UserPermissionDto, UserPermission>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.PermissionId));
            CreateMap<UserPermission, UserPermissionDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.PermissionId));
            #endregion
        }
    }
}