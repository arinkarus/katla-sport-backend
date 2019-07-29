namespace KatlaSport.Services.AwardManagement
{
    using AutoMapper;
    using DataAccessAward = KatlaSport.DataAccess.EmployeeAward.Award;

    public sealed class AwardManagementMappingProfile : Profile
    {
        public AwardManagementMappingProfile()
        {
            CreateMap<DataAccessAward, Award>();
            CreateMap<DataAccessAward, AwardListItem>();
            CreateMap<UpdateAwardRequest, DataAccessAward>();
        }
    }
}
