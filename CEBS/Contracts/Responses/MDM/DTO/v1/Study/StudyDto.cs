namespace CEBS.Contracts.Responses.MDM.DTO.v1.Study;

public class StudyDto
{
    public int? Id { get; set; }
        
    public string? SdSid { get; set; }
        
    public string? MdrSdSid { get; set; }
        
    public int? MdrSourceId { get; set; }
        
    public string? DisplayTitle { get; set; }
        
    public string? TitleLangCode { get; set; }
        
    public string? BriefDescription { get; set; }
        
    public string? DataSharingStatement { get; set; }
        
    public int? StudyStartYear { get; set; }
        
    public int? StudyStartMonth { get; set; }
        
    public int? StudyTypeId { get; set; }
        
    public int? StudyStatusId { get; set; }
        
    public string? StudyEnrolment { get; set; }
        
    public int? StudyGenderEligId { get; set; }
        
    public int? MinAge { get; set; }
        
    public int? MinAgeUnitsId { get; set; }
        
    public int? MaxAge { get; set; }
        
    public int? MaxAgeUnitsId { get; set; }
        
    public string? CreatedOn { get; set; }
        
    public StudyContributorDto[]? StudyContributors { get; set; }
        
    public StudyFeatureDto[]? StudyFeatures { get; set; }
        
    public StudyIdentifierDto[]? StudyIdentifiers { get; set; }
        
    public StudyReferenceDto[]? StudyReferences { get; set; }
        
    public StudyRelationshipDto[]? StudyRelationships { get; set; }
        
    public StudyTitleDto[]? StudyTitles { get; set; }
        
    public StudyTopicDto[]? StudyTopics { get; set; }
}