namespace API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(Event), IsUnique = true)]
public class Evento{
    [Key]
    public int Id { get; set; }
    public string? Event { get; set; }
    public string? Lugar { get; set; }
    public string? Descripcion { get; set; }
    public string? Materiales { get; set; }
    public DateTime Fecha { get; set; }
    public bool AireLibre { get; set;}
}
