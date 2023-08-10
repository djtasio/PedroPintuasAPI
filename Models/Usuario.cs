namespace API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(User), IsUnique = true)]
public class Usuario{
    [Key]
    public int Id { get; set; }
    public string? User { get; set; }
    public string? Contrasenia { get; set; }
    //[Required]
    public string? NombreApellidos { get; set; }
    //[Required]
    //[Range(8, 10)]
    public int Telefono { get; set; }
    public bool IsAdmin { get; set;}
    public ICollection<Pedido> ?Pedidos { get; set; }
    
}