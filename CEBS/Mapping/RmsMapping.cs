using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.Mapping;
using CEBS.Models.RMS;

namespace CEBS.Mapping;

public class RmsMapping : IRmsMapping
{
    public DtaDto[] DtaDtoBuilder(Dta[] dtas)
    {
        return dtas.Select(DtaDtoMapper).ToArray();
    }

    public DtaDto DtaDtoMapper(Dta dta)
    {
        var dtaDto = new DtaDto
        {
            Id = dta.Id,
            DtpId = dta.DtpId,
            CreatedOn = dta.CreatedOn,
            ConformsToDefault = dta.ConformsToDefault,
            Variations = dta.Variations,
            RepoSignatory1 = dta.RepoSignatory1,
            RepoSignatory2 = dta.RepoSignatory2,
            ProviderSignatory1 = dta.ProviderSignatory1,
            ProviderSignatory2 = dta.ProviderSignatory2,
            Notes = dta.Notes
        };

        return dtaDto;
    }

    public DtpDto[] DtpDtoBuilder(Dtp[] dtps)
    {
        return dtps.Select(DtpDtoMapper).ToArray();
    }

    public DtpDto DtpDtoMapper(Dtp dtp)
    {
        var dtpDto = new DtpDto
        {
            Id = dtp.Id,
            CreatedOn = dtp.CreatedOn,
            OrgId = dtp.OrgId,
            DisplayName = dtp.DisplayName,
            StatusId = dtp.StatusId,
            InitialContactDate = dtp.InitialContactDate,
            SetUpCompleted = dtp.SetUpCompleted,
            MdAccessGranted = dtp.MdAccessGranted,
            MdCompleteDate = dtp.MdCompleteDate,
            DtaAgreedDate = dtp.DtaAgreedDate,
            UploadAccessRequested = dtp.UploadAccessRequested,
            UploadAccessConfirmed = dtp.UploadAccessConfirmed,
            UploadsComplete = dtp.UploadsComplete,
            QcChecksCompleted = dtp.QcChecksCompleted,
            MdIntegratedWithMdr = dtp.MdIntegratedWithMdr,
            AvailabilityRequested = dtp.AvailabilityRequested,
            AvailabilityConfirmed = dtp.AvailabilityConfirmed
        };

        return dtpDto;
    }

    public DtpDatasetDto[] DtpDatasetDtoBuilder(DtpDataset[] dtpDatasets)
    {
        return dtpDatasets.Select(DtpDatasetDtoMapper).ToArray();
    }

    public DtpDatasetDto DtpDatasetDtoMapper(DtpDataset dtpDataset)
    {
        var dtpDatasetDto = new DtpDatasetDto
        {
            Id = dtpDataset.Id,
            ObjectId = dtpDataset.ObjectId,
            CreatedOn = dtpDataset.CreatedOn,
            LegalStatusId = dtpDataset.LegalStatusId,
            LegalStatusText = dtpDataset.LegalStatusText,
            LegalStatusPath = dtpDataset.LegalStatusPath,
            DescmdCheckBy = dtpDataset.DescmdCheckBy,
            DescmdCheckDate = dtpDataset.DescmdCheckDate,
            DescmdCheckStatusId = dtpDataset.DescmdCheckStatusId,
            DeidentCheckBy = dtpDataset.DeidentCheckBy,
            DeidentCheckDate = dtpDataset.DeidentCheckDate,
            DeidentCheckStatusId = dtpDataset.DeidentCheckStatusId,
            Notes = dtpDataset.Notes
        };

        return dtpDatasetDto;
    }

    public DtpObjectDto[] DtpObjectDtoBuilder(DtpObject[] dtpObjects)
    {
        return dtpObjects.Select(DtpObjectDtoMapper).ToArray();
    }

    public DtpObjectDto DtpObjectDtoMapper(DtpObject dtpObject)
    {
        var dtpObjectDto = new DtpObjectDto
        {
            Id = dtpObject.Id,
            DtpId = dtpObject.DtpId,
            ObjectId = dtpObject.ObjectId,
            CreatedOn = dtpObject.CreatedOn,
            IsDataset = dtpObject.IsDataset,
            AccessTypeId = dtpObject.AccessTypeId,
            DownloadAllowed = dtpObject.DownloadAllowed,
            AccessDetails = dtpObject.AccessDetails,
            RequiresEmbargoPeriod = dtpObject.RequiresEmbargoPeriod,
            EmbargoEndDate = dtpObject.EmbargoEndDate,
            EmbargoStillApplies = dtpObject.EmbargoStillApplies,
            AccessCheckStatusId = dtpObject.AccessCheckStatusId,
            AccessCheckDate = dtpObject.AccessCheckDate,
            AccessCheckBy = dtpObject.AccessCheckBy,
            MdCheckStatusId = dtpObject.MdCheckStatusId,
            MdCheckBy = dtpObject.MdCheckBy,
            MdCheckDate = dtpObject.MdCheckDate,
            Notes = dtpObject.Notes
        };

        return dtpObjectDto;
    }

    public DtpStudyDto[] DtpStudyDtoBuilder(DtpStudy[] dtpStudies)
    {
        return dtpStudies.Select(DtpStudyDtoMapper).ToArray();
    }

    public DtpStudyDto DtpStudyDtoMapper(DtpStudy dtpStudy)
    {
        var dtpStudyDto = new DtpStudyDto
        {
            Id = dtpStudy.Id,
            DtpId = dtpStudy.DtpId,
            StudyId = dtpStudy.StudyId,
            CreatedOn = dtpStudy.CreatedOn,
            MdCheckStatusId = dtpStudy.MdCheckStatusId,
            MdCheckBy = dtpStudy.MdCheckBy,
            MdCheckDate = dtpStudy.MdCheckDate
        };

        return dtpStudyDto;
    }

    public DuaDto[] DuaDtoBuilder(Dua[] duas)
    {
        return duas.Select(DuaDtoMapper).ToArray();
    }

    public DuaDto DuaDtoMapper(Dua dua)
    {
        var duaDto = new DuaDto
        {
            Id = dua.Id,
            DupId = dua.DupId,
            CreatedOn = dua.CreatedOn,
            ConformsToDefault = dua.ConformsToDefault,
            Variations = dua.Variations,
            RepoAsProxy = dua.RepoAsProxy,
            RepoSignatory1 = dua.RepoSignatory1,
            RepoSignatory2 = dua.RepoSignatory2,
            ProviderSignatory1 = dua.ProviderSignatory1,
            ProviderSignatory2 = dua.ProviderSignatory2,
            RequesterSignatory1 = dua.RequesterSignatory1,
            RequesterSignatory2 = dua.RequesterSignatory2,
            Notes = dua.Notes
        };

        return duaDto;
    }

    public DupDto[] DupDtoBuilder(Dup[] dups)
    {
        return dups.Select(DupDtoMapper).ToArray();
    }

    public DupDto DupDtoMapper(Dup dup)
    {
        var dupDto = new DupDto
        {
            Id = dup.Id,
            CreatedOn = dup.CreatedOn,
            OrgId = dup.OrgId,
            DisplayName = dup.DisplayName,
            StatusId = dup.StatusId,
            InitialContactDate = dup.InitialContactDate,
            SetUpCompleted = dup.SetUpCompleted,
            PrereqsMet = dup.PrereqsMet,
            DuaAgreedDate = dup.DuaAgreedDate,
            AvailabilityRequested = dup.AvailabilityRequested,
            AvailabilityConfirmed = dup.AvailabilityConfirmed,
            AccessConfirmed = dup.AccessConfirmed
        };

        return dupDto;
    }

    public DupObjectDto[] DupObjectDtoBuilder(DupObject[] dupObjects)
    {
        return dupObjects.Select(DupObjectDtoMapper).ToArray();
    }

    public DupObjectDto DupObjectDtoMapper(DupObject dupObject)
    {
        var dupObjectDto = new DupObjectDto
        {
            Id = dupObject.Id,
            DupId = dupObject.DupId,
            CreatedOn = dupObject.CreatedOn,
            ObjectId = dupObject.ObjectId,
            AccessTypeId = dupObject.AccessTypeId,
            AccessDetails = dupObject.AccessDetails,
            Notes = dupObject.Notes
        };

        return dupObjectDto;
    }

    public DupPrereqDto[] DupPrereqDtoBuilder(DupPrereq[] dupPrereqs)
    {
        return dupPrereqs.Select(DupPrereqDtoMapper).ToArray();
    }

    public DupPrereqDto DupPrereqDtoMapper(DupPrereq dupPrereq)
    {
        var dupPrereqDto = new DupPrereqDto
        {
            Id = dupPrereq.Id,
            DupId = dupPrereq.DupId,
            CreatedOn = dupPrereq.CreatedOn,
            ObjectId = dupPrereq.ObjectId,
            MetNotes = dupPrereq.MetNotes,
            PreRequisiteId = dupPrereq.PreRequisiteId,
            PrerequisiteMet = dupPrereq.PrerequisiteMet
        };

        return dupPrereqDto;
    }

    public SecondaryUseDto[] SecondaryUseDtoBuilder(SecondaryUse[] secondaryUses)
    {
        return secondaryUses.Select(SecondaryUseDtoMapper).ToArray();
    }

    public SecondaryUseDto SecondaryUseDtoMapper(SecondaryUse secondaryUse)
    {
        var secondaryUseDto = new SecondaryUseDto
        {
            Id = secondaryUse.Id,
            DupId = secondaryUse.DupId,
            CreatedOn = secondaryUse.CreatedOn,
            SecondaryUseType = secondaryUse.SecondaryUseType,
            Publication = secondaryUse.Publication,
            Doi = secondaryUse.Doi,
            AttributionPresent = secondaryUse.AttributionPresent,
            Notes = secondaryUse.Notes
        };

        return secondaryUseDto;
    }

    public AccessPrereq[] ReverseAccessPrereqDtoBuilder(AccessPrereqDto[] accessPrereqDtos)
    {
        throw new NotImplementedException();
    }

    public AccessPrereq ReverseAccessPrereqDtoMapper(AccessPrereqDto accessPrereqDto)
    {
        throw new NotImplementedException();
    }

    public Dta[] ReverseDtaDtoBuilder(DtaDto[] dtaDtos)
    {
        throw new NotImplementedException();
    }

    public Dta ReverseDtaDtoMapper(DtaDto dtaDto)
    {
        throw new NotImplementedException();
    }

    public Dtp[] ReverseDtpDtoBuilder(DtpDto[] dtpDtos)
    {
        throw new NotImplementedException();
    }

    public Dtp ReverseDtpDtoMapper(DtpDto dtpDto)
    {
        throw new NotImplementedException();
    }

    public DtpDataset[] ReverseDtpDatasetDtoBuilder(DtpDatasetDto[] dtpDatasetDtos)
    {
        throw new NotImplementedException();
    }

    public DtpDataset ReverseDtpDatasetDtoMapper(DtpDatasetDto dtpDatasetDto)
    {
        throw new NotImplementedException();
    }

    public DtpObject[] ReverseDtpObjectDtoBuilder(DtpObjectDto[] dtpObjectDtos)
    {
        throw new NotImplementedException();
    }

    public DtpObject ReverseDtpObjectDtoMapper(DtpObjectDto dtpObjectDto)
    {
        throw new NotImplementedException();
    }

    public DtpStudy[] ReverseDtpStudyDtoBuilder(DtpStudyDto[] dtpStudyDtos)
    {
        throw new NotImplementedException();
    }

    public DtpStudy ReverseDtpStudyDtoMapper(DtpStudyDto dtpStudyDto)
    {
        throw new NotImplementedException();
    }

    public Dua[] ReverseDuaDtoBuilder(DuaDto[] duaDto)
    {
        throw new NotImplementedException();
    }

    public Dua ReverseDuaDtoMapper(DuaDto duaDto)
    {
        throw new NotImplementedException();
    }

    public Dup[] ReverseDupDtoBuilder(DupDto[] dupDtos)
    {
        throw new NotImplementedException();
    }

    public Dup ReverseDupDtoMapper(DupDto dupDto)
    {
        throw new NotImplementedException();
    }

    public DupObject[] ReverseDupObjectDtoBuilder(DupObjectDto[] dupObjectDtos)
    {
        throw new NotImplementedException();
    }

    public DupObject ReverseDupObjectDtoMapper(DupObjectDto dupObjectDto)
    {
        throw new NotImplementedException();
    }

    public DupPrereq[] ReverseDupPrereqDtoBuilder(DupPrereqDto[] dupPrereqDto)
    {
        throw new NotImplementedException();
    }

    public DupPrereq ReverseDupPrereqDtoMapper(DupPrereqDto dupPrereqDto)
    {
        throw new NotImplementedException();
    }

    public ProcessNote[] ReverseProcessNoteDtoBuilder(ProcessNoteDto[] processNoteDtos)
    {
        throw new NotImplementedException();
    }

    public ProcessNote ReverseProcessNoteDtoMapper(ProcessNoteDto processNoteDto)
    {
        throw new NotImplementedException();
    }

    public ProcessPeople[] ReverseProcessPeopleDtoBuilder(ProcessPeopleDto[] processPeopleDtos)
    {
        throw new NotImplementedException();
    }

    public ProcessPeople ReverseProcessPeopleDtoMapper(ProcessPeopleDto processPeopleDto)
    {
        throw new NotImplementedException();
    }

    public SecondaryUse[] ReverseSecondaryUseDtoBuilder(SecondaryUseDto[] secondaryUseDtos)
    {
        throw new NotImplementedException();
    }

    public SecondaryUse ReverseSecondaryUseDtoMapper(SecondaryUseDto secondaryUseDto)
    {
        throw new NotImplementedException();
    }


    public AccessPrereqDto[] AccessPrereqDtoBuilder(AccessPrereq[] accessPrereq)
    {
        return accessPrereq.Select(AccessPrereqDtoMapper).ToArray();
    }

    public AccessPrereqDto AccessPrereqDtoMapper(AccessPrereq accessPrereq)
    {
        var accessPrereqDto = new AccessPrereqDto
        {
            Id = accessPrereq.Id,
            ObjectId = accessPrereq.ObjectId,
            PreRequisiteId = accessPrereq.PreRequisiteId,
            PreRequisiteNotes = accessPrereq.PreRequisiteNotes,
            CreatedOn = accessPrereq.CreatedOn
        };
        return accessPrereqDto;
    }

    public ProcessNoteDto[] ProcessNoteDtoBuilder(ProcessNote[] processNotes)
    {
        return processNotes.Select(ProcessNoteDtoMapper).ToArray();
    }

    public ProcessNoteDto ProcessNoteDtoMapper(ProcessNote processNote)
    {
        var processNoteDto = new ProcessNoteDto
        {
            Id = processNote.Id,
            ProcessId = processNote.ProcessId,
            ProcessType = processNote.ProcessType,
            CreatedOn = processNote.CreatedOn
        };
        return processNoteDto;
    }

    public ProcessPeopleDto[] ProcessPeopleDtoBuilder(ProcessPeople[] processPeople)
    {
        return processPeople.Select(ProcessPeopleDtoMapper).ToArray();
    }

    public ProcessPeopleDto ProcessPeopleDtoMapper(ProcessPeople processPeople)
    {
        var processPeopleDto = new ProcessPeopleDto
        {
            Id = processPeople.Id,
            PersonId = processPeople.PersonId,
            ProcessId = processPeople.ProcessId,
            ProcessType = processPeople.ProcessType,
            IsAUser = processPeople.IsAUser,
            CreatedOn = processPeople.CreatedOn
        };
        return processPeopleDto;
    }
}