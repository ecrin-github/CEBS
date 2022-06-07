using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Models.MDM.Study;

namespace CEBS.Interfaces.MDM.Repositories;

public interface IStudyRepository
{
    // Study
    Task<BaseResponse<Study>> GetStudies();
    Task<BaseResponse<Study>> GetStudyById(int id);
    Task<BaseResponse<Study>> GetStudyBySdSid(string sdSid);
    Task<BaseResponse<Study>> CreateStudy(Study study);
    Task<BaseResponse<Study>> BulkCreateStudy(Study[] studies);
    Task<BaseResponse<Study>> UpdateStudy(Study[] studies);
    Task<BaseResponse<Study>> BulkUpdateStudy(Study[] study);
    Task<int> DeleteStudy(string sdSid);
    
    // Study contributors
    Task<BaseResponse<StudyContributor>> GetStudyContributors(string sdSid);
    Task<BaseResponse<StudyContributor>> GetStudyContributor(int id);
    Task<BaseResponse<StudyContributor>> CreateStudyContributor(StudyContributor studyContributor);
    Task<BaseResponse<StudyContributor>> UpdateStudyContributor(StudyContributor studyContributor);
    Task<BaseResponse<StudyContributor>> BulkCreateStudyContributor(StudyContributor[] studyContributors);
    Task<BaseResponse<StudyContributor>> BulkUpdateStudyContributor(StudyContributor[] studyContributors);
    Task<int> DeleteStudyContributor(int id);
    Task<int> DeleteAllStudyContributors(string sdSid);

    // Study features
    Task<BaseResponse<StudyFeature>> GetStudyFeatures(string sdSid);
    Task<BaseResponse<StudyFeature>> GetStudyFeature(int id);
    Task<BaseResponse<StudyFeature>> CreateStudyFeature(StudyFeature studyFeature);
    Task<BaseResponse<StudyFeature>> UpdateStudyFeature(StudyFeature studyFeature);
    Task<BaseResponse<StudyFeature>> BulkCreateStudyFeature(StudyFeature[] studyFeatures);
    Task<BaseResponse<StudyFeature>> BulkUpdateStudyFeature(StudyFeature[] studyFeatures);
    Task<int> DeleteStudyFeature(int id);
    Task<int> DeleteAllStudyFeatures(string sdSid);

    // Study identifiers
    Task<BaseResponse<StudyIdentifier>> GetStudyIdentifiers(string sdSid);
    Task<BaseResponse<StudyIdentifier>> GetStudyIdentifier(int id);
    Task<BaseResponse<StudyIdentifier>> CreateStudyIdentifier(StudyIdentifier studyIdentifier);
    Task<BaseResponse<StudyIdentifier>> UpdateStudyIdentifier(StudyIdentifier studyIdentifier);
    Task<BaseResponse<StudyIdentifier>> BulkCreateStudyIdentifier(StudyIdentifier[] studyIdentifiers);
    Task<BaseResponse<StudyIdentifier>> BulkUpdateStudyIdentifier(StudyIdentifier[] studyIdentifiers);
    Task<int> DeleteStudyIdentifier(int id);
    Task<int> DeleteAllStudyIdentifiers(string sdSid);

    // Study references
    Task<BaseResponse<StudyReference>> GetStudyReferences(string sdSid);
    Task<BaseResponse<StudyReference>> GetStudyReference(int id);
    Task<BaseResponse<StudyReference>> CreateStudyReference(StudyReference studyReference);
    Task<BaseResponse<StudyReference>> UpdateStudyReference(StudyReference studyReference);
    Task<BaseResponse<StudyReference>> BulkCreateStudyReference(StudyReference[] studyReferences);
    Task<BaseResponse<StudyReference>> BulkUpdateStudyReference(StudyReference[] studyReferences);
    Task<int> DeleteStudyReference(int id);
    Task<int> DeleteAllStudyReferences(string sdSid);

    // Study relationships
    Task<BaseResponse<StudyRelationship>> GetStudyRelationships(string sdSid);
    Task<BaseResponse<StudyRelationship>> GetStudyRelationship(int id);
    Task<BaseResponse<StudyRelationship>> CreateStudyRelationship(StudyRelationship studyRelationship);
    Task<BaseResponse<StudyRelationship>> UpdateStudyRelationship(StudyRelationship studyRelationship);
    Task<BaseResponse<StudyRelationship>> BulkCreateStudyRelationship(StudyRelationship[] studyRelationships);
    Task<BaseResponse<StudyRelationship>> BulkUpdateStudyRelationship(StudyRelationship[] studyRelationships);
    Task<int> DeleteStudyRelationship(int id);
    Task<int> DeleteAllStudyRelationships(string sdSid);

    // Study titles
    Task<BaseResponse<StudyTitle>> GetStudyTitles(string sdSid);
    Task<BaseResponse<StudyTitle>> GetStudyTitle(int id);
    Task<BaseResponse<StudyTitle>> CreateStudyTitle(StudyTitle studyTitle);
    Task<BaseResponse<StudyTitle>> UpdateStudyTitle(StudyTitle studyTitle);
    Task<BaseResponse<StudyTitle>> BulkCreateStudyTitle(StudyTitle[] studyTitles);
    Task<BaseResponse<StudyTitle>> BulkUpdateStudyTitle(StudyTitle[] studyTitles);
    Task<int> DeleteStudyTitle(int id);
    Task<int> DeleteAllStudyTitles(string sdSid);

    // Study topics
    Task<BaseResponse<StudyTopic>> GetStudyTopics(string sdSid);
    Task<BaseResponse<StudyTopic>> GetStudyTopic(int id);
    Task<BaseResponse<StudyTopic>> CreateStudyTopic(StudyTopic studyTopic);
    Task<BaseResponse<StudyTopic>> UpdateStudyTopic(StudyTopic studyTopic);
    Task<BaseResponse<StudyTopic>> BulkCreateStudyTopic(StudyTopic[] studyTopics);
    Task<BaseResponse<StudyTopic>> BulkUpdateStudyTopic(StudyTopic[] studyTopics);
    Task<int> DeleteStudyTopic(int id);
    Task<int> DeleteAllStudyTopics(string sdSid);

    // Extensions
    Task<BaseResponse<Study>> PaginateStudies(PaginationRequest paginationRequest);
    Task<BaseResponse<Study>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalStudies();
}