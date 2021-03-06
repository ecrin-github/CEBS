using CEBS.Models.MDR.Object;
using Nest;

namespace CEBS.Models.MDR.Study;

[ElasticsearchType(RelationName = "study")]
public class Study
{
    [Number(Name = "id")] public int? Id { get; set; }

    [Text(Name = "display_title")] public string? DisplayTitle { get; set; }

    [Text(Name = "brief_description")] public string? BriefDescription { get; set; }

    [Text(Name = "data_sharing_statement")]
    public string? DataSharingStatement { get; set; }

    [Object] [PropertyName("study_type")] public StudyType? StudyType { get; set; }

    [Object]
    [PropertyName("study_status")]
    public StudyStatus? StudyStatus { get; set; }

    [Object]
    [PropertyName("study_gender_elig")]
    public StudyGenderElig? StudyGenderElig { get; set; }

    [Text(Name = "study_enrolment")] public string? StudyEnrolment { get; set; }

    [Object] [PropertyName("min_age")] public MinAge? MinAge { get; set; }

    [Object] [PropertyName("max_age")] public MaxAge? MaxAge { get; set; }

    [Nested]
    [PropertyName("study_identifiers")]
    public StudyIdentifier[]? StudyIdentifiers { get; set; }

    [Nested]
    [PropertyName("study_titles")]
    public StudyTitle[]? StudyTitles { get; set; }

    [Nested]
    [PropertyName("study_features")]
    public StudyFeature[]? StudyFeatures { get; set; }

    [Nested]
    [PropertyName("study_topics")]
    public StudyTopic[]? StudyTopics { get; set; }

    [Nested]
    [PropertyName("study_relationships")]
    public StudyRelation[]? StudyRelationships { get; set; }

    [Text(Name = "provenance_string")] public string? ProvenanceString { get; set; }

    [Nested]
    [PropertyName("linked_data_objects")]
    public DataObject[]? LinkedDataObjects { get; set; }
}