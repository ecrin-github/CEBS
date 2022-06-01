using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.Context.Ctx;

[Table("mesh_lookup", Schema = "ctx")]
[Keyless]
public class MeshLookup
{
    [Column("entry")]
    public string? Entry {get; set;}

    [Column("code")]
    public string? Code {get; set;}

    [Column("term")]
    public string? Term {get; set;}

    [Column("source")]
    public string? Source {get; set;}
}