using AutoMapper;
using CEBS.Contracts.Responses.Audit.DTO.v1;
using CEBS.Models.Audit;

namespace CEBS.Mapping;

public class AuditMapping : Profile
{
    public AuditMapping()
    {
        CreateMap<MdrRecordChange, AuditDto>();
        CreateMap<RmsRecordChange, AuditDto>();
    }
}