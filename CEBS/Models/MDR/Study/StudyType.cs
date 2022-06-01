using Nest;

namespace CEBS.Models.MDR.Study;

public class StudyType
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Text(Name = "name")]
    public string?Name { get; set; }
}