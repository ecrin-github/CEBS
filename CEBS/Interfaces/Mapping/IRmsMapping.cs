using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Models.RMS;

namespace CEBS.Interfaces.Mapping;

public interface IRmsMapping
{
    // DTP mappers
    AccessPrereqDto[] AccessPrereqDtoBuilder(AccessPrereq[] accessPrereq);
    AccessPrereqDto AccessPrereqDtoMapper(AccessPrereq accessPrereq);

    DtaDto[] DtaDtoBuilder(Dta[] dtas);
    DtaDto DtaDtoMapper(Dta dta);

    DtpDto[] DtpDtoBuilder(Dtp[] dtps);
    DtpDto DtpDtoMapper(Dtp dtp);

    DtpDatasetDto[] DtpDatasetDtoBuilder(DtpDataset[] dtpDatasets);
    DtpDatasetDto DtpDatasetDtoMapper(DtpDataset dtpDataset);

    DtpObjectDto[] DtpObjectDtoBuilder(DtpObject[] dtpObjects);
    DtpObjectDto DtpObjectDtoMapper(DtpObject dtpObject);

    DtpStudyDto[] DtpStudyDtoBuilder(DtpStudy[] dtpStudies);
    DtpStudyDto DtpStudyDtoMapper(DtpStudy dtpStudy);
        
        
    // DUP mappers and builders
    DuaDto[] DuaDtoBuilder(Dua[] duas);
    DuaDto DuaDtoMapper(Dua dua);

    DupDto[] DupDtoBuilder(Dup[] dups);
    DupDto DupDtoMapper(Dup dup);

    DupObjectDto[] DupObjectDtoBuilder(DupObject[] dupObjects);
    DupObjectDto DupObjectDtoMapper(DupObject dupObject);

    DupPrereqDto[] DupPrereqDtoBuilder(DupPrereq[] dupPrereqs);
    DupPrereqDto DupPrereqDtoMapper(DupPrereq dupPrereq);

    ProcessNoteDto[] ProcessNoteDtoBuilder(ProcessNote[] processNotes);
    ProcessNoteDto ProcessNoteDtoMapper(ProcessNote processNote);

    ProcessPeopleDto[] ProcessPeopleDtoBuilder(ProcessPeople[] processPeople);
    ProcessPeopleDto ProcessPeopleDtoMapper(ProcessPeople processPeople);

    SecondaryUseDto[] SecondaryUseDtoBuilder(SecondaryUse[] secondaryUses);
    SecondaryUseDto SecondaryUseDtoMapper(SecondaryUse secondaryUse);
}