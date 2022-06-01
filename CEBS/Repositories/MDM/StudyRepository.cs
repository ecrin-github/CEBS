using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.MDM.Repositories;
using CEBS.Models.MDM.Study;

namespace CEBS.Repositories.MDM;

public class StudyRepository : IStudyRepository
{
    public async Task<BaseResponse<Study>> GetAllStudies()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> GetStudyById(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> CreateStudy(Study study)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> UpdateStudy(Study study)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudy(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributor>> GetStudyContributors(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributor>> GetStudyContributor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributor>> CreateStudyContributor(StudyContributor studyContributor)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributor>> UpdateStudyContributor(StudyContributor studyContributor)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyContributor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyContributors(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeature>> GetStudyFeatures(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeature>> GetStudyFeature(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeature>> CreateStudyFeature(StudyFeature studyFeature)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeature>> UpdateStudyFeature(StudyFeature studyFeature)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyFeature(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyFeatures(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifier>> GetStudyIdentifiers(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifier>> GetStudyIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifier>> CreateStudyIdentifier(StudyIdentifier studyIdentifier)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifier>> UpdateStudyIdentifier(StudyIdentifier studyIdentifier)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyIdentifiers(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReference>> GetStudyReferences(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReference>> GetStudyReference(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReference>> CreateStudyReference(StudyReference studyReference)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReference>> UpdateStudyReference(StudyReference studyReference)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyReference(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyReferences(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationship>> GetStudyRelationships(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationship>> GetStudyRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationship>> CreateStudyRelationship(StudyRelationship studyRelationship)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationship>> UpdateStudyRelationship(StudyRelationship studyRelationship)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyRelationships(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitle>> GetStudyTitles(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitle>> GetStudyTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitle>> CreateStudyTitle(StudyTitle studyTitle)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitle>> UpdateStudyTitle(StudyTitle studyTitle)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyTitles(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopic>> GetStudyTopics(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopic>> GetStudyTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopic>> CreateStudyTopic(StudyTopic studyTopic)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopic>> UpdateStudyTopic(StudyTopic studyTopic)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyTopics(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> PaginateStudies(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalStudies()
    {
        throw new NotImplementedException();
    }
}