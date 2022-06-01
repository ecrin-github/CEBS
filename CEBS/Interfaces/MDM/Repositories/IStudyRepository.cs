using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Models.MDM.Study;

namespace CEBS.Interfaces.MDM.Repositories;

public interface IStudyRepository
{
    // Study
    Task<BaseResponse<Study>> GetAllStudies();
    Task<BaseResponse<Study>> GetStudyById(string sdSid);
    Task<BaseResponse<Study>> CreateStudy(Study study);
    Task<BaseResponse<Study>> UpdateStudy(Study study);
    Task<int> DeleteStudy(string sdSid);
    
    // Study contributors
    Task<BaseResponse<StudyContributor>> GetStudyContributors(string sdSid);
    Task<BaseResponse<StudyContributor>> GetStudyContributor(int id);
    Task<BaseResponse<StudyContributor>> CreateStudyContributor(StudyContributor studyContributor);
    Task<BaseResponse<StudyContributor>> UpdateStudyContributor(StudyContributor studyContributor);
    Task<int> DeleteStudyContributor(int id);
    Task<int> DeleteAllStudyContributors(string sdSid);

    // Study features
    Task<BaseResponse<StudyFeature>> GetStudyFeatures(string sdSid);
    Task<BaseResponse<StudyFeature>> GetStudyFeature(int id);
    Task<BaseResponse<StudyFeature>> CreateStudyFeature(StudyFeature studyFeature);
    Task<BaseResponse<StudyFeature>> UpdateStudyFeature(StudyFeature studyFeature);
    Task<int> DeleteStudyFeature(int id);
    Task<int> DeleteAllStudyFeatures(string sdSid);

    // Study identifiers
    Task<BaseResponse<StudyIdentifier>> GetStudyIdentifiers(string sdSid);
    Task<BaseResponse<StudyIdentifier>> GetStudyIdentifier(int id);
    Task<BaseResponse<StudyIdentifier>> CreateStudyIdentifier(StudyIdentifier studyIdentifier);
    Task<BaseResponse<StudyIdentifier>> UpdateStudyIdentifier(StudyIdentifier studyIdentifier);
    Task<int> DeleteStudyIdentifier(int id);
    Task<int> DeleteAllStudyIdentifiers(string sdSid);

    // Study references
    Task<BaseResponse<StudyReference>> GetStudyReferences(string sdSid);
    Task<BaseResponse<StudyReference>> GetStudyReference(int id);
    Task<BaseResponse<StudyReference>> CreateStudyReference(StudyReference studyReference);
    Task<BaseResponse<StudyReference>> UpdateStudyReference(StudyReference studyReference);
    Task<int> DeleteStudyReference(int id);
    Task<int> DeleteAllStudyReferences(string sdSid);

    // Study relationships
    Task<BaseResponse<StudyRelationship>> GetStudyRelationships(string sdSid);
    Task<BaseResponse<StudyRelationship>> GetStudyRelationship(int id);
    Task<BaseResponse<StudyRelationship>> CreateStudyRelationship(StudyRelationship studyRelationship);
    Task<BaseResponse<StudyRelationship>> UpdateStudyRelationship(StudyRelationship studyRelationship);
    Task<int> DeleteStudyRelationship(int id);
    Task<int> DeleteAllStudyRelationships(string sdSid);

    // Study titles
    Task<BaseResponse<StudyTitle>> GetStudyTitles(string sdSid);
    Task<BaseResponse<StudyTitle>> GetStudyTitle(int id);
    Task<BaseResponse<StudyTitle>> CreateStudyTitle(StudyTitle studyTitle);
    Task<BaseResponse<StudyTitle>> UpdateStudyTitle(StudyTitle studyTitle);
    Task<int> DeleteStudyTitle(int id);
    Task<int> DeleteAllStudyTitles(string sdSid);

    // Study topics
    Task<BaseResponse<StudyTopic>> GetStudyTopics(string sdSid);
    Task<BaseResponse<StudyTopic>> GetStudyTopic(int id);
    Task<BaseResponse<StudyTopic>> CreateStudyTopic(StudyTopic studyTopic);
    Task<BaseResponse<StudyTopic>> UpdateStudyTopic(StudyTopic studyTopic);
    Task<int> DeleteStudyTopic(int id);
    Task<int> DeleteAllStudyTopics(string sdSid);

    // Extensions
    Task<BaseResponse<Study>> PaginateStudies(PaginationRequest paginationRequest);
    Task<BaseResponse<Study>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalStudies();
}