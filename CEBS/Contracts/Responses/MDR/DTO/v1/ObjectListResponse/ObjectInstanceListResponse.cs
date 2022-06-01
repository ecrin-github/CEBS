using CEBS.Contracts.Responses.MDR.DTO.v1.Common;

namespace CEBS.Contracts.Responses.MDR.DTO.v1.ObjectListResponse;

public class ObjectInstanceListResponse
{
    public int? Id { get; set; }
        
    public string? RepositoryOrg { get; set; }
        
    public InstanceAccessDetails? AccessDetails { get; set; }
        
    public InstanceResourceDetails? ResourceDetails { get; set; }
}