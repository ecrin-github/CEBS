using CEBS.Contracts.Requests.Context.v1.OrganisationRequests;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.Context.Services;
using CEBS.Models.Context.Ctx;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.Context.v1;

public class CtxApiController : BaseContextApiController
{
    private readonly ICtxService _ctxService;

    public CtxApiController(ICtxService ctxService)
    {
        _ctxService = ctxService ?? throw new ArgumentNullException(nameof(ctxService));
    }
    
    
    [HttpGet("organisations")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrganisations()
    {
        var data = await _ctxService.GetOrganisations();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<Organisation>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<Organisation>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrganisation(int id)
    {
        var data = await _ctxService.GetOrganisation(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<Organisation>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<Organisation>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpPost("organisations/search/by-title")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrganisationsByName(SearchByTitleRequest searchByTitleRequest)
    {
        var data = await _ctxService.GetOrganisationsByName(searchByTitleRequest.OrganisationName);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<Organisation>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<Organisation>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}/attributes")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation" })]
    public async Task<IActionResult> GetOrgAttributes(int id)
    {
        var data = await _ctxService.GetOrgAttributes(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgAttribute>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgAttribute>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}/links")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrgLinks(int id)
    {
        var data = await _ctxService.GetOrgLinks(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgLink>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgLink>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}/locations")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrgLocations(int id)
    {
        var data = await _ctxService.GetOrgLocations(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgLocation>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgLocation>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}/names")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrgNames(int id)
    {
        var data = await _ctxService.GetOrgNames(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgName>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgName>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisations/{id:int}/relationships")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrgRelationships(int id)
    {
        var data = await _ctxService.GetOrgRelationships(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgRelationship>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgRelationship>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("organisations/{id:int}/memberships")]
    [SwaggerOperation(Tags = new[] { "Context - Organisations" })]
    public async Task<IActionResult> GetOrgMemberships(int id)
    {
        var data = await _ctxService.GetOrgTypeMemberships(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<OrgTypeMembership>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<OrgTypeMembership>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    
    [HttpGet("people")]
    [SwaggerOperation(Tags = new[] { "Context - People" })]
    public async Task<IActionResult> GetPeople()
    {
        var data = await _ctxService.GetPeople();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<People>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<People>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("people/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - People" })]
    public async Task<IActionResult> GetPerson(int id)
    {
        var data = await _ctxService.GetPerson(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<People>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<People>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("people/{id:int}/links")]
    [SwaggerOperation(Tags = new[] { "Context - People" })]
    public async Task<IActionResult> GetPersonLinks(int id)
    {
        var data = await _ctxService.GetPersonLinks(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<PeopleLink>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<PeopleLink>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("people/{id:int}/roles")]
    [SwaggerOperation(Tags = new[] { "Context - People" })]
    public async Task<IActionResult> GetPersonRoles(int id)
    {
        var data = await _ctxService.GetPersonRoles(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<PeopleRole>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<PeopleRole>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    
    [HttpGet("geographical-entities")]
    [SwaggerOperation(Tags = new[] { "Context - Geographical entities" })]
    public async Task<IActionResult> GetGeogEntities()
    {
        var data = await _ctxService.GetGeogEntities();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<GeogEntity>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<GeogEntity>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("geographical-entities/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Geographical entities" })]
    public async Task<IActionResult> GetGeogEntity(int id)
    {
        var data = await _ctxService.GetGeogEntity(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<GeogEntity>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<GeogEntity>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("published-journals")]
    [SwaggerOperation(Tags = new[] { "Context - Published journals" })]
    public async Task<IActionResult> GetPublishedJournals()
    {
        var data = await _ctxService.GetPublishedJournals();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<PublishedJournal>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<PublishedJournal>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("published-journals/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Published journals" })]
    public async Task<IActionResult> GetPublishedJournal(int id)
    {
        var data = await _ctxService.GetPublishedJournal(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<PublishedJournal>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<PublishedJournal>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
}