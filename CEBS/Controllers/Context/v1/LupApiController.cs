using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Context.DTO.v1;
using CEBS.Interfaces.Context.Services;
using CEBS.Models.Context.Lup;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CEBS.Controllers.Context.v1;

public class LupApiController : BaseContextApiController
{
    private readonly ILupService _lupService;

    public LupApiController(ILupService lupService)
    {
        _lupService = lupService ?? throw new ArgumentNullException(nameof(lupService));
    }

    [HttpGet("composite-hash-types")]
    [SwaggerOperation(Tags = new[] { "Context - Composite hash types" })]
    public async Task<IActionResult> GetCompositeHashTypes()
    {
        var data = await _lupService.GetCompositeHashTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("composite-hash-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Composite hash types" })]
    public async Task<IActionResult> GetCompositeHashType(int id)
    {
        var data = await _lupService.GetCompositeHashType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    
    [HttpGet("contribution-types")]
    [SwaggerOperation(Tags = new[] { "Context - Contribution types" })]
    public async Task<IActionResult> GetContributionTypes()
    {
        var data = await _lupService.GetContributionTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("contribution-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Contribution types" })]
    public async Task<IActionResult> GetContributionType(int id)
    {
        var data = await _lupService.GetContributionType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("dataset-consent-types")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset consent types" })]
    public async Task<IActionResult> GetDatasetConsentTypes()
    {
        var data = await _lupService.GetDatasetConsentTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("dataset-consent-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset consent types" })]
    public async Task<IActionResult> GetDatasetConsentType(int id)
    {
        var data = await _lupService.GetDatasetConsentType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = null
        });
    }
    
    [HttpGet("dataset-deidentification-types")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset deidentification types" })]
    public async Task<IActionResult> GetDatasetDeidentTypes()
    {
        var data = await _lupService.GetDatasetDeidentLevels();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("dataset-deidentification-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset deidentification types" })]
    public async Task<IActionResult> GetDatasetDeidentType(int id)
    {
        var data = await _lupService.GetDatasetDeidentLevel(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("dataset-recordkey-types")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset recordkey types" })]
    public async Task<IActionResult> GetDatasetRecordkeyTypes()
    {
        var data = await _lupService.GetDatasetRecordkeyTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("dataset-recordkey-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Dataset recordkey types" })]
    public async Task<IActionResult> GetDatasetRecordkeyType(int id)
    {
        var data = await _lupService.GetDatasetRecordkeyType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("date-types")]
    [SwaggerOperation(Tags = new[] { "Context - Date types" })]
    public async Task<IActionResult> GetDateTypes()
    {
        var data = await _lupService.GetDateTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("date-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Date types" })]
    public async Task<IActionResult> GetDateType(int id)
    {
        var data = await _lupService.GetDateType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("description-types")]
    [SwaggerOperation(Tags = new[] { "Context - Description types" })]
    public async Task<IActionResult> GetDescriptionTypes()
    {
        var data = await _lupService.GetDescriptionTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("description-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Description types" })]
    public async Task<IActionResult> GetDescriptionType(int id)
    {
        var data = await _lupService.GetDescriptionType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("doi-status-types")]
    [SwaggerOperation(Tags = new[] { "Context - DOI status types" })]
    public async Task<IActionResult> GetDoiStatusTypes()
    {
        var data = await _lupService.GetDoiStatusTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("doi-status-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - DOI status types" })]
    public async Task<IActionResult> GetDoiStatusType(int id)
    {
        var data = await _lupService.GetDoiStatusType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("gender-eligibility-types")]
    [SwaggerOperation(Tags = new[] { "Context - Gender eligibility types" })]
    public async Task<IActionResult> GetGenderEligTypes()
    {
        var data = await _lupService.GetGenderEligTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("gender-eligibility-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Gender eligibility types" })]
    public async Task<IActionResult> GetGenderEligType(int id)
    {
        var data = await _lupService.GetGenderEligType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("geog-entity-types")]
    [SwaggerOperation(Tags = new[] { "Context - Geographical entity types" })]
    public async Task<IActionResult> GetGeogEntityTypes()
    {
        var data = await _lupService.GetGeogEntityTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("geog-entity-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Geographical entity types" })]
    public async Task<IActionResult> GetGeogEntityType(int id)
    {
        var data = await _lupService.GetGeogEntityType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("identifier-types")]
    [SwaggerOperation(Tags = new[] { "Context - Identifier types" })]
    public async Task<IActionResult> GetIdentifierTypes()
    {
        var data = await _lupService.GetIdentifierTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("identifier-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Identifier types" })]
    public async Task<IActionResult> GetIdentifierType(int id)
    {
        var data = await _lupService.GetIdentifierType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("language-usage-types")]
    [SwaggerOperation(Tags = new[] { "Context - Language usage types" })]
    public async Task<IActionResult> GetLangUsageTypes()
    {
        var data = await _lupService.GetLangUsageTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("language-usage-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Language usage types" })]
    public async Task<IActionResult> GetLangUsageType(int id)
    {
        var data = await _lupService.GetLangUsageType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("link-types")]
    [SwaggerOperation(Tags = new[] { "Context - Link types" })]
    public async Task<IActionResult> GeLinkTypes()
    {
        var data = await _lupService.GetLinkTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("link-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Link types" })]
    public async Task<IActionResult> GetLinkType(int id)
    {
        var data = await _lupService.GetLinkType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-access-types")]
    [SwaggerOperation(Tags = new[] { "Context - Object access types" })]
    public async Task<IActionResult> GetObjectAccessTypes()
    {
        var data = await _lupService.GetObjectAccessTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-access-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object access types" })]
    public async Task<IActionResult> GetObjectAccessType(int id)
    {
        var data = await _lupService.GetObjectAccessType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-classes")]
    [SwaggerOperation(Tags = new[] { "Context - Object classes" })]
    public async Task<IActionResult> GetObjectClasses()
    {
        var data = await _lupService.GetObjectClasses();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-classes/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object classes" })]
    public async Task<IActionResult> GetObjectClass(int id)
    {
        var data = await _lupService.GetObjectClass(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-filter-types")]
    [SwaggerOperation(Tags = new[] { "Context - Object filter types" })]
    public async Task<IActionResult> GetObjectFilterTypes()
    {
        var data = await _lupService.GetObjectFilterTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-filter-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object filter types" })]
    public async Task<IActionResult> GetObjectFilterType(int id)
    {
        var data = await _lupService.GetObjectFilterType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-instance-types")]
    [SwaggerOperation(Tags = new[] { "Context - Object instance types" })]
    public async Task<IActionResult> GetObjectInstanceTypes()
    {
        var data = await _lupService.GetObjectInstanceTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-instance-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object instance types" })]
    public async Task<IActionResult> GetObjectInstanceType(int id)
    {
        var data = await _lupService.GetObjectInstanceType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-relationship-types")]
    [SwaggerOperation(Tags = new[] { "Context - Object relationship types" })]
    public async Task<IActionResult> GetObjectRelationTypes()
    {
        var data = await _lupService.GetObjectRelationshipTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-relationship-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object relationship types" })]
    public async Task<IActionResult> GetObjectRelationType(int id)
    {
        var data = await _lupService.GetObjectRelationshipType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-types")]
    [SwaggerOperation(Tags = new[] { "Context - Object types" })]
    public async Task<IActionResult> GetObjectTypes()
    {
        var data = await _lupService.GetObjectTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("object-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Object types" })]
    public async Task<IActionResult> GetObjectType(int id)
    {
        var data = await _lupService.GetObjectType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("resource-types")]
    [SwaggerOperation(Tags = new[] { "Context - Resource types" })]
    public async Task<IActionResult> GetResourceTypes()
    {
        var data = await _lupService.GetResourceTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("resource-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Resource types" })]
    public async Task<IActionResult> GetResourceType(int id)
    {
        var data = await _lupService.GetResourceType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms-user-types")]
    [SwaggerOperation(Tags = new[] { "Context - RMS user types" })]
    public async Task<IActionResult> GetRmsUserTypes()
    {
        var data = await _lupService.GetRmsUserTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("rms-user-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - RMS user types" })]
    public async Task<IActionResult> GetRmsUserType(int id)
    {
        var data = await _lupService.GetRmsUserType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("role-types")]
    [SwaggerOperation(Tags = new[] { "Context - Role types" })]
    public async Task<IActionResult> GetRoleTypes()
    {
        var data = await _lupService.GetRoleTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("role-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Role types" })]
    public async Task<IActionResult> GetRoleType(int id)
    {
        var data = await _lupService.GetRoleType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("size-units")]
    [SwaggerOperation(Tags = new[] { "Context - Size units" })]
    public async Task<IActionResult> GetSizeUnits()
    {
        var data = await _lupService.GetSizeUnits();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("size-units/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Size units" })]
    public async Task<IActionResult> GetSizeUnit(int id)
    {
        var data = await _lupService.GetSizeUnit(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-feature-categories")]
    [SwaggerOperation(Tags = new[] { "Context - Study feature categories" })]
    public async Task<IActionResult> GetStudyFeatureCategories()
    {
        var data = await _lupService.GetStudyFeatureCategories();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-feature-categories/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Study feature categories" })]
    public async Task<IActionResult> GetStudyFeatureCategory(int id)
    {
        var data = await _lupService.GetStudyFeatureCategory(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-feature-types")]
    [SwaggerOperation(Tags = new[] { "Context - Study feature types" })]
    public async Task<IActionResult> GetStudyFeatureTypes()
    {
        var data = await _lupService.GetStudyFeatureTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-feature-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Study feature types" })]
    public async Task<IActionResult> GetStudyFeatureType(int id)
    {
        var data = await _lupService.GetStudyFeatureType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-relationship-types")]
    [SwaggerOperation(Tags = new[] { "Context - Study relationship types" })]
    public async Task<IActionResult> GetStudyRelationTypes()
    {
        var data = await _lupService.GetStudyRelationshipTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-relationship-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Study relationship types" })]
    public async Task<IActionResult> GetStudyRelationType(int id)
    {
        var data = await _lupService.GetStudyRelationshipType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-statuses")]
    [SwaggerOperation(Tags = new[] { "Context - Study statuses" })]
    public async Task<IActionResult> GetStudyStatuses()
    {
        var data = await _lupService.GetStudyStatuses();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-statuses/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Study statuses" })]
    public async Task<IActionResult> GetStudyStatus(int id)
    {
        var data = await _lupService.GetStudyStatus(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("study-types")]
    [SwaggerOperation(Tags = new[] { "Context - Study types" })]
    public async Task<IActionResult> GetStudyTypes()
    {
        var data = await _lupService.GetStudyTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("study-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Study types" })]
    public async Task<IActionResult> GetStudyType(int id)
    {
        var data = await _lupService.GetStudyType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("time-units")]
    [SwaggerOperation(Tags = new[] { "Context - Time units" })]
    public async Task<IActionResult> GetTimeUnits()
    {
        var data = await _lupService.GetTimeUnits();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("time-units/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Time units" })]
    public async Task<IActionResult> GetTimeUnit(int id)
    {
        var data = await _lupService.GetTimeUnit(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("title-types")]
    [SwaggerOperation(Tags = new[] { "Context - Title types" })]
    public async Task<IActionResult> GetTitleTypes()
    {
        var data = await _lupService.GetTitlesTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("title-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Title types" })]
    public async Task<IActionResult> GetTitleType(int id)
    {
        var data = await _lupService.GetTitleType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("topic-types")]
    [SwaggerOperation(Tags = new[] { "Context - Topic types" })]
    public async Task<IActionResult> GetTopicTypes()
    {
        var data = await _lupService.GetTopicTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("topic-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Topic types" })]
    public async Task<IActionResult> GetTopicType(int id)
    {
        var data = await _lupService.GetTopicType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("lang-codes")]
    [SwaggerOperation(Tags = new[] { "Context - Language codes" })]
    public async Task<IActionResult> GetLangCodes()
    {
        var data = await _lupService.GetLanguageCodes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<LanguageCode>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<LanguageCode>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("lang-codes/{code}")]
    [SwaggerOperation(Tags = new[] { "Context - Language codes" })]
    public async Task<IActionResult> GetLangCode(string code)
    {
        var data = await _lupService.GetLanguageCode(code);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<LanguageCode>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<LanguageCode>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("organisation/attribute-datatypes")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgAttributeDatatypes()
    {
        var data = await _lupService.GetOrgAttributeDatatypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/attribute-datatypes/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgAttributeDatatype(int id)
    {
        var data = await _lupService.GetOrgAttributeDatatype(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/attribute-types")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgAttributeTypes()
    {
        var data = await _lupService.GetOrgAttributeTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/attribute-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgAttributeType(int id)
    {
        var data = await _lupService.GetOrgAttributeType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/classes")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgClasses()
    {
        var data = await _lupService.GetOrgClasses();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/classes/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgClass(int id)
    {
        var data = await _lupService.GetOrgClass(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/link-types")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgLinkTypes()
    {
        var data = await _lupService.GetOrgLinkTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/link-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgLinkType(int id)
    {
        var data = await _lupService.GetOrgLinkType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/name-qualifier-types")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgNameQualifierTypes()
    {
        var data = await _lupService.GetOrgNameQualifierTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/name-qualifier-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgNameQualifierType(int id)
    {
        var data = await _lupService.GetOrgNameQualifierType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/relationship-types")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgRelationshipTypes()
    {
        var data = await _lupService.GetOrgRelationshipTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/relationship-types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgRelationshipType(int id)
    {
        var data = await _lupService.GetOrgRelationshipType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }

    [HttpGet("organisation/types")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgTypes()
    {
        var data = await _lupService.GetOrgTypes();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("organisation/types/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Organisation related context" })]
    public async Task<IActionResult> GetOrgType(int id)
    {
        var data = await _lupService.GetOrgType(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }


    [HttpGet("topic-vocabularies")]
    [SwaggerOperation(Tags = new[] { "Context - Topic vocabularies" })]
    public async Task<IActionResult> GetTopicVocabularies()
    {
        var data = await _lupService.GetTopicVocabularies();
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = NotFound().StatusCode,
            Messages = new []{"There are no records."}
        });
        return Ok(new ApiResponse<ContextDto>
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
    
    [HttpGet("topic-vocabularies/{id:int}")]
    [SwaggerOperation(Tags = new[] { "Context - Topic vocabularies" })]
    public async Task<IActionResult> GetTopicVocabulary(int id)
    {
        var data = await _lupService.GetTopicVocabulary(id);
        if (data.Total == 0 && data.Data.Length == 0) return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            Messages = new []{"Not found."},
            StatusCode = NotFound().StatusCode
        });
        return Ok(new ApiResponse<ContextDto>()
        {
            Total = data.Total,
            Data = data.Data,
            StatusCode = Ok().StatusCode,
            Messages = Array.Empty<string>()
        });
    }
}