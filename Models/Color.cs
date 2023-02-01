namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=data-annotations
public class Color{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
}