namespace CEBS.Contracts.Responses.MDM.DTO.v1.Object;

public class DataObjectDto
{
    public int? Id { get; set; }
    
    public string? SdOid { get; set; }
    
    public string? SdSid { get; set; }
    
    public string? DisplayTitle { get; set; }
    
    public string? Version { get; set; }
    
    public string? Doi { get; set; }
    
    public int? DoiStatusId { get; set; }
    
    public int? PublicationYear { get; set; }
    
    public int? ObjectClassId { get; set; }
    
    public int? ObjectTypeId { get; set; }
    
    public int? ManagingOrgId { get; set; }
    
    public string? ManagingOrg { get; set; }
    
    public string? ManagingOrgRorId { get; set; }
    
    public string? LangCode { get; set; }
    
    public int? AccessTypeId { get; set; }
    
    public string? AccessDetails { get; set; }
    
    public string? AccessDetailsUrl { get; set; }
    
    public DateTime? UrlLastChecked { get; set; } 
    
    public int? EoscCategory { get; set; }
    
    public bool? AddStudyContribs { get; set; }
    
    public bool? AddStudyTopics { get; set; }
    
    public DateTime? CreatedOn { get; set; }
    
    public ObjectContributorDto[]? ObjectContributors { get; set; }
    
    public ObjectDatasetDto? ObjectDatasets { get; set; }
    
    public ObjectDateDto[]? ObjectDates { get; set; }
    
    public ObjectDescriptionDto[]? ObjectDescriptions { get; set; }
    
    public ObjectIdentifierDto[]? ObjectIdentifiers { get; set; }
    
    public ObjectInstanceDto[]? ObjectInstances { get; set; }
    
    public ObjectRelationshipDto[]? ObjectRelationships { get; set; }
    
    public ObjectRightDto[]? ObjectRights { get; set; }
    
    public ObjectTitleDto[]? ObjectTitles { get; set; }
    
    public ObjectTopicDto[]? ObjectTopics { get; set; }
}